using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository;
using RashakaGroupsAdmin.ViewModels;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RashakaGroupsAdmin.ViewModel;

namespace RashakaGroupsAdmin.Controllers
{
    [Authorize(Roles = "adminGroups")]
    public class CommentSystemController : Controller
    {
        private readonly IRashakaUniteOfWork repo;
        private readonly IAdminUsers iAdminUsers;
        private readonly ICommentSystemService iCommentSystemService;
        private readonly CommentRepo _objComRepo = new();
        public CommentSystemController(IAdminUsers _iAdminUsers, IRashakaUniteOfWork _repo, ICommentSystemService iCommentSystemService)
        {
            repo = new RashakaUniteOfWork();
            iAdminUsers = _iAdminUsers;
            repo = _repo;
            this.iCommentSystemService = iCommentSystemService;
        }


        // GET: CommentAdmin

        [HttpGet]
        public IActionResult PostComments(int? id, string commentArtGuid, string artGuid, string date)
        {
            try
            {
                GroupPost POSt = repo.iRashaka<GroupPost>().Find(id);
                string userRole = iAdminUsers.GetLoggedUserRole();
                if (userRole == "adminGroups")
                {
                    ViewBag.userRole = userRole;
                    ViewBag.accountId = iAdminUsers.GetLoggedUserId();
                }

                ViewBag.CommentArtGuid = POSt.commentArtGuid;
                ViewBag.description = POSt.description;
                ViewBag.postId = id;
                ViewBag.accountName = POSt.account != null ? POSt.account.name : "مجموعة رشاقة الرسمية";
                ViewBag.profileImage = POSt.account != null ? POSt.account.image : "rashaka.png";
                Comments result = iCommentSystemService.GetArticleCommentsFromCommentSystem(commentArtGuid, POSt.guid.ToString(), date);
                //ViewBag.CommentArtGuid = commentArtGuid;
                ViewBag.artGuid = artGuid;
                if (result.comments != null && result.comments.Count > 0)
                    ViewBag.date = result.comments.Last().date;
                else
                    ViewBag.date = (DateTime.Now).ToString("dd-MM-yyyy HH:mm:ss");

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return Json(result.comments);
                else
                    return View(result);
            }
            catch
            {
                return View();
            }

        }
        public IActionResult DeleteAllPostComment()
        {
            var posts = repo.iRashaka<GroupPost>().GetAll(x => x.commentSystemCommentsCount > 0).ToList();
            foreach (var item in posts)
            {
                Comments result1 = iCommentSystemService.GetArticleCommentsFromCommentSystem(item.commentArtGuid.ToString(), item.guid.ToString(), "");
                foreach (var c in result1.comments)
                {
                    var result = iCommentSystemService.deleteCommentFromCommentSystem(item.commentArtGuid.ToString(), c.guid);
                    if (result == "Success")
                    {
                        GroupPost post = repo.iRashaka<GroupPost>().Find(item.id);
                        post.commentSystemCommentsCount = post.commentSystemCommentsCount > 0 ? post.commentSystemCommentsCount - 1 : 0;
                        repo.Save();
                    }
                }
            }
            return Json(""/**/);
        }


        [HttpGet]
        public IActionResult GetEventComments(int? id, string commentArtGuid, string artGuid, string date)
        {
            try
            {
                GroupEvent groupEvent = repo.iRashaka<GroupEvent>().Find(id);
                ViewBag.CommentArtGuid = groupEvent.commentArtGuid;
                ViewBag.description = groupEvent.name;
                ViewBag.eventId = id;
                ViewBag.accountName = groupEvent.admin != null ? groupEvent.admin.name : "";
                ViewBag.profileImage = groupEvent.admin != null ? groupEvent.admin.image : "";
                Comments result = iCommentSystemService.GetArticleCommentsFromCommentSystem(commentArtGuid, artGuid, date);
                //ViewBag.CommentArtGuid = commentArtGuid;
                ViewBag.artGuid = artGuid;
                ViewBag.date = result.comments.Count > 0 ? result.comments.Last().date : DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return Json(result.comments);
                else
                    return View(result);
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult ReportedComments(string date)
        {
            Comments result = iCommentSystemService.getReportedCommentsFromCommentSystem(date);
            ViewBag.date = result.comments.Count > 0 ? result.comments.Last().date : DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return Json(result.comments);
            else
                return View(result);
        }

        [HttpGet]
        public IActionResult ReportedReplies(string date)
        {
            GetReplies result = iCommentSystemService.getReportedRepliesFromCommentSystem(date);
            ViewBag.date = result.replies.Count > 0 ? result.replies.Last().date : DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return Json(result.replies);
            else
                return View(result);
        }

        [HttpGet]
        public IActionResult GetReplies(string commentGuid, string accountGuid, string date)
        {
            GetReplies result = iCommentSystemService.getRepliesFromCommentSystem(commentGuid, accountGuid, date);
            ViewBag.commentGuid = commentGuid; ViewBag.accountGuid = accountGuid;
            ViewBag.date = result.replies.Count > 0 ? result.replies.Last().date : DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            //if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //    return Json(result.replies);
            //else
            return View(result.replies);
        }

        [HttpPost]
        public IActionResult DeletePostComment(int postId, string commentGuid)
        {
            try
            {
                GroupPost post = repo.iRashaka<GroupPost>().Find(postId);
                var result = iCommentSystemService.deleteCommentFromCommentSystem(post.commentArtGuid.ToString(), commentGuid);
                if (result == "success")
                {
                    post.commentSystemCommentsCount = post.commentSystemCommentsCount > 0 ? post.commentSystemCommentsCount - 1 : 0;
                    repo.Save();
                }
                return Json(result/**/);
            }
            catch (Exception)
            {
                return Json("failed"/**/);
            }



        }

        [HttpPost]
        public IActionResult DeleteEventComment(string commentArtGuid, string commentGuid)
        {
            var result = iCommentSystemService.deleteCommentFromCommentSystem(commentArtGuid, commentGuid);
            if (result == "Success")
            {
                GroupEvent post = repo.iRashaka<GroupEvent>().GetBy(x => x.commentArtGuid == new Guid(commentArtGuid));
                post.commentSystemCommentsCount = post.commentSystemCommentsCount > 0 ? post.commentSystemCommentsCount - 1 : 0;
                repo.Save();
            }

            return Json(result);
        }
        [HttpPost]
        public IActionResult unReportComment(string commentGuid)
        {
            var result = iCommentSystemService.unReportCommentFromCommentSystem(commentGuid);
            return Json(result);
        }
        public IActionResult PartialClass(string searchText = "")
        {
            //if (Session["user"] != null)
            //{
            //    List<CommentSystemVM> comments = new List<CommentSystemVM>();
            //    comments = _objComRepo.CommentSearch(searchText);
            //    return Json(comments);
            //}
            //else
                return RedirectToAction("Login", "Account");
        }
       
        [HttpPost]
        public IActionResult AddReply(string commentGuid, string text, string commentArtGuid)
        {
            string accountGUID = "fef4f5d8-abeb-460b-a685-58bac4c2a47d";
            int? accountId = iAdminUsers.GetLoggedUserId();
            if (accountId > 0)
            {
                Guid? guid = repo.iRashaka<Account>().Find(accountId).guid;
                accountGUID = guid.ToString();
            }
            var result = iCommentSystemService.AddReplyToCommentSystem(commentGuid, text, accountGUID);
            return Json(result);
        }
        [HttpPost]
        public IActionResult AddPostComment(Guid? accountGUID, int postId, string text)
        {
            try
            {
                GroupPost groupPost = repo.iRashaka<GroupPost>().Find(postId);
                if (accountGUID == Guid.Empty || accountGUID == null)
                {
                    int? accountId = iAdminUsers.GetLoggedUserId();
                    accountGUID = repo.iRashaka<Account>().Find(accountId).guid;
                }
                var result = iCommentSystemService.AddComment(accountGUID, text, groupPost.commentArtGuid, groupPost.guid, 2);
                groupPost.commentArtGuid = Guid.Parse(result.ArtGuid);
                //groupPost.CommentsCount = groupPost.CommentsCount == null ? 1 : groupPost.CommentsCount + 1;
                groupPost.commentSystemCommentsCount = groupPost.commentSystemCommentsCount == null ? 1 : groupPost.commentSystemCommentsCount + 1;
                repo.Save();
                return Json(true);
            }
            catch
            {
                return Json(false);
            }

        }

        [HttpPost]
        public IActionResult AddEventComment(Guid accountGUID, int eventId, string text)
        {
            try
            {
                GroupEvent groupEvent = repo.iRashaka<GroupEvent>().Find(eventId);
                var result = iCommentSystemService.AddComment(accountGUID, text, groupEvent.commentArtGuid, groupEvent.guid, 7);
                groupEvent.commentArtGuid = Guid.Parse(result.ArtGuid);
                //groupEvent.CommentsCount = groupEvent.CommentsCount == null ? 1 : groupEvent.CommentsCount + 1;
                groupEvent.commentSystemCommentsCount = groupEvent.commentSystemCommentsCount == null ? 1 : groupEvent.commentSystemCommentsCount + 1;
                repo.Save();
                return Json(true);
            }
            catch
            {
                return Json(false);
            }

        }
        [HttpPost]
        public IActionResult DeleteReply(string replyGuid)
        {
            var result = iCommentSystemService.deleteReplyFromCommentSystem(replyGuid);
            return Json(result);
        }
        [HttpPost]
        public IActionResult UnReportReply(string replyGuid)
        {
            var result = iCommentSystemService.unReportReplyFromCommentSystem(replyGuid);
            return Json(result);
        }
    }
}