using Microsoft.AspNetCore.Mvc;
using RashakaAdmin.Models;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Services;
using RashakaGroupsAdmin.ViewModel;
using System.Data;

namespace RashakaGroupsAdmin.Controllers
{

    public class PostsController : Controller
    {
        IGroupPost iGroupPost;
        readonly IAdminUsers iAdminUsers;
        readonly IRashakaUniteOfWork repo;
        readonly IGroupPost groupPostService;
        readonly ICommentSystemService iICommentSystemService;
        public PostsController(IRashakaUniteOfWork _repo, IGroupPost _iGroupPost, IGroupPost _groupPostRepo, IAdminUsers _iAdminUsers, ICommentSystemService iICommentSystemService)
        {
            repo = _repo;
            iGroupPost = _iGroupPost;
            groupPostService = _groupPostRepo;
            iAdminUsers = _iAdminUsers;
            this.iICommentSystemService = iICommentSystemService;
        }
        public JsonResult Search(string key, int groupId)
        {
            var res = DapperService<GroupPost>.Query("SELECT top 10 id, SUBSTRING(description, 1, 100) AS description FROM GroupPosts  WHERE groupId=@groupId  and description LIKE N'%" + key + "%' ", new { groupId = groupId }, CommandType.Text);

            return Json(res.ToList());
        }

        public ActionResult Details(int id, int? accountId)
        {
            try
            {
                GroupPostsModel post;
                post = DapperService<GroupPostsModel>.QuerySingle("SELECT  gp.isPinned,gp.id,gp.guid, groupname=g.name,  gp.viewscount, gp.commentartguid, gp.groupid, postownerid=gp.accountid, ownername=acc.name, accountGuid= acc.guid, ownerprofileimage=acc.image, gp.title,   gp.[description], gp.totallikes,  gp.commentsystemcommentscount,gp.image, gp.image2,gp.image3,	 gp.date, [shareimageurl],gp.[type] FROM dbo.groupposts gp LEFT JOIN dbo.accounts acc ON gp.accountid=acc.id JOIN dbo.groups g ON g.id=gp.groupid WHERE gp.id=@id", new { id });
                return View(post);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult GetPostComments(CommentModel model)
        {
            //GroupPost POSt = repo.iRashaka<GroupPost>().Find(model.id);
            //ViewBag.commentArtGuid = POSt.commentArtGuid;
            //ViewBag.description = POSt.description;
            //ViewBag.postId = model.id;
            //ViewBag.accountName = POSt.account != null ? POSt.account.name : "مجموعة رشاقة الرسمية";
            //ViewBag.profileImage = POSt.account != null ? POSt.account.image : "rashaka.png";
            //Comments result = iICommentSystemService.GetArticleCommentsFromCommentSystem(model.commentArtGuid, POSt.guid.ToString(), model.date);
            //result.postId = model.id;
            //result.groupId = POSt.groupId ?? 0;
            //ViewBag.artGuid = model.artGuid;
            //if (result.comments != null && result.comments.Count > 0)
            //    ViewBag.date = result.comments.Last().date;
            //else
            //    ViewBag.date = (DateTime.Now).ToString("dd-MM-yyyy HH:mm:ss");
            Comments result = groupPostService.GetPostComments(model);  
            return PartialView("_PostComments", result);
        }

        [HttpGet]
        public ActionResult GetCommentReplies(string commentGuid, string accountGuid, string date)
        {
            GetReplies result = iICommentSystemService.getRepliesFromCommentSystem(commentGuid, accountGuid, date);
            ViewBag.commentGuid = commentGuid; ViewBag.accountGuid = accountGuid;
            ViewBag.date = result.replies.Count > 0 ? result.replies.Last().date : DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            return PartialView("_CommentReplies", result);
        }
        [HttpPost]
        public ActionResult PinPost(int id, int groupId)
        {
            try
            {
                var res = groupPostService.PinnPost(id, groupId);               
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
        public ActionResult GroupPosts(int? groupId, int? page, int? accountId, string filter)
        {
            try
            {
                IEnumerable<GroupPostsModel> posts;
                posts = DapperService<GroupPostsModel>.Query("GetGroupPostsForGroupAdminDashBoard",
                    new { RowsOfPage = 20, PageNumber = page ?? 1, groupId, filter = filter ?? "" }, CommandType.StoredProcedure);
                ViewBag.groupId = groupId;
                ViewBag.page = page + 1;
                ViewBag.groupName = groupId > 0 ? repo.iRashaka<Group>().Find(groupId).name : "";
                return View(posts);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult GetGroupPosts(int? groupId, int? page, string filter)
        {
            try
            {
                ViewBag.groupId = groupId;
               IEnumerable<GroupPostsModel>  posts = DapperService<GroupPostsModel>.Query("GetGroupPostsForGroupAdminDashBoard", new { RowsOfPage = 20, PageNumber = page ?? 1, groupId = groupId, filter = filter ?? "" }, CommandType.StoredProcedure);
                return PartialView("_GroupPosts", posts);
            }
            catch
            {
                return PartialView("_GroupPosts");
            }
        }
        [HttpGet]
        public ActionResult UserPosts(int? groupId,int accountId, int? page, string filter)
        {
            try
            {
                IEnumerable<GroupPostsModel> posts;
                posts = DapperService<GroupPostsModel>.Query("GetGroupPostsForGroupAdminDashBoard_ByAccountId",
                    new { RowsOfPage = 20, PageNumber = page ?? 1, groupId, accountId, filter = filter ?? "" }, CommandType.StoredProcedure);
                ViewBag.groupId = groupId;
                ViewBag.accountId = accountId;
                ViewBag.page = page + 1;
                ViewBag.groupName = groupId > 0 ? repo.iRashaka<Group>().Find(groupId).name : "";
                return View(posts);
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult GetUserPosts(int? groupId, int accountId, int? page, string filter)
        {
            try
            {
                ViewBag.groupId = groupId;
                IEnumerable<GroupPostsModel> posts;
                posts = DapperService<GroupPostsModel>.Query("GetGroupPostsForGroupAdminDashBoard_ByAccountId", new { RowsOfPage = 20, PageNumber = page ?? 1, groupId = groupId, filter = filter ?? "" }, CommandType.StoredProcedure);

                return PartialView("_UserPosts", posts);
            }
            catch
            {
                return PartialView("_UserPosts");
            }
        }





        public ActionResult GetMostInteractivePosts(int? groupId)
        {
            try
            {
                var posts = repo.iRashaka<GroupPost>().GetAll(x => x.groupId == groupId && x.isAllowed == true, x => x.commentSystemCommentsCount, 1, 2, "account");
                return PartialView("_MostInteractivePost", posts);
            }
            catch
            {
                return PartialView("_GroupPosts");
            }
        }
        [HttpPost]
        public ActionResult AddPostComment(Guid? accountGUID, int postId, string text)
        {
            try
            {
                bool res = iGroupPost.AddComment(accountGUID, postId, text);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }

        }
        [HttpPost]
        public ActionResult DeletePostComment(string commentArtGuid, string commentGuid)
        {
            var result = iICommentSystemService.deleteCommentFromCommentSystem(commentArtGuid, commentGuid);
            if (result == "Success")
            {
                GroupPost post = repo.iRashaka<GroupPost>().GetBy(x => x.commentArtGuid == new Guid(commentArtGuid));
                post.commentSystemCommentsCount = post.commentSystemCommentsCount > 0 ? post.commentSystemCommentsCount - 1 : 0;
                repo.Save();
            }

            return Json(result);
        }


        [Route("Groups/PostsByGroup/{id}/{page}")]
        public ActionResult PostsByGroup(int? id, int? page)
        {
            try
            {
                var posts = repo.iRashaka<GroupPost>().GetAll(x => x.groupId == id, x => x.isPinned == true, x => x.id, page ?? 1, 30);
                return View(posts);
            }
            catch (Exception)
            {
                return View();
            }

        }

        [Route("Groups/PostsByGrpupId/{id}/{page}")]
        public ActionResult PostsByGrpupId(int? id, int? page)
        {
            try
            {
                var posts = repo.iRashaka<GroupPost>().GetAll(x => x.commentSystemCommentsCount > 0, x => x.commentSystemCommentsCount, page ?? 1, 30);
                return View(posts);
            }
            catch (Exception)
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddPost(PostModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.description))
                {
                    ViewBag.message = "بيانات غير مكتمله";
                    return View();
                }
                int postId = await iGroupPost.AddEditGroupPost(model);
                return RedirectToAction("GroupPosts", "posts", new { groupId = GlobalValues.GroupId });
            }
            catch (Exception ex)
            {
                return Json("");
            }
        }


        public ActionResult EditPost(string id)
        {
            GroupPost post = repo.iRashaka<GroupPost>().GetByIncluding(x => x.id == Convert.ToInt32(id), "group");
            ViewBag.groupId = post.groupId;
            ViewBag.groupName = post.group.name;
            return View(post);
        }


        public ActionResult AllowDisAllow(int id, bool allow)
        {
            try
            {
                var post = repo.iRashaka<GroupPost>().Find(id);
                post.isAllowed = allow;
                repo.Save();
                //NotificationCenter.AcceptPostIngroup(post);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }

        }
        //public ActionResult comments(string id)
        //{
        //    try
        //    {
        //        int postId = Convert.ToInt32(id);
        //        ViewBag.postId = postId;
        //        var post = repo.iRashaka<GroupPost>().GetByIncluding(x => x.id == postId, "account");
        //        Account account = post.account;
        //        ViewBag.accountName = account != null ? account.name : (account == null && post.groupId == 4) ? "مجموعة رشاقة الرسمية" : (account == null && post.groupId == 868) ? "مسابقة رشاقة" : "";
        //        ViewBag.image = account != null ? account.image : "rashaka.png";
        //        ViewBag.title = !string.IsNullOrEmpty(post.description) ? post.description : post.title;
        //        ViewBag.description = post.description;
        //        var comments = repo.iRashaka<GroupPostComment>().GetAll(x => x.groupPostId == postId).OrderByDescending(x => x.id);

        //        return View(comments);
        //    }
        //    catch (Exception)
        //    {
        //        ViewBag.status = "error";
        //        return View();
        //    }
        //}

        [HttpPost, /*ValidateInput(false)*/]
        public ActionResult AddComment(int accountId, int groupPostId, string comment)
        {
            var commentId = groupPostService.AddPostComment(new AddGroupPostCommentModel { accountId = accountId, comment = comment, groupPostId = groupPostId });
            if (Convert.ToInt32(commentId) > 0)
            {
                return Json(true);
            }
            return Json(false);
        }


        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            try
            {
                var comment = repo.iRashaka<GroupPostComment>().Find(id);
                GroupPost post = repo.iRashaka<GroupPost>().Find(comment.groupPostId);
                post.commentsCount = post.commentsCount > 0 ? post.commentsCount - 1 : 0;
                repo.iRashaka<GroupPostComment>().Delete(comment);
                repo.Save();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);

            }


        }
        [HttpPost]
        public ActionResult AddReply(string commentGuid, string text, string commentArtGuid, string commentOwnerGuid)
        {
            //string accountGUID = "fef4f5d8-abeb-460b-a685-58bac4c2a47d";
            int accountId = iAdminUsers.GetLoggedUserId();
            Account account = repo.iRashaka<Account>().Find(accountId);
            ReplyJson replyJson = new()
            {
                accountGuid = account.guid.ToString(),
                commentArtGuid = commentArtGuid,
                commentGuid = commentGuid,
                text = text,
                commentOwnerAccountGuid = commentOwnerGuid
            };
            var result = iICommentSystemService.AddReplyToCommentSystem(account, replyJson, commentGuid, text);
            return Json(result);
        }



        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            try
            {
               bool res=iGroupPost.DeletePost(id);
                return Json(false);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize(Roles = "admin,groups,adminGroups,superAdmin")]

        //public ActionResult GroupPostRports(int id, int? page)
        //{
        //    try
        //    {
        //        var groupPostReport = repo.iRashaka<GroupPost>().GetAll(X => X.groupId == id && X.reportsCount > 0, X => X.id, page ?? 1, 40, "group");
        //        ViewBag.groupName = groupPostReport.Select(x => x.group.name).FirstOrDefault();
        //        ViewBag.groupId = id;
        //        return View(groupPostReport);
        //    }
        //    catch (Exception)
        //    {
        //        return View();
        //    }

        //}
    }
}