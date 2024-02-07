using Microsoft.AspNetCore.Mvc;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using RashakaGroupsAdmin.ViewModel;
using System.Data;
using System.Text.Json;
using X.PagedList;

namespace RashakaGroupsAdmin.Services
{
    public class GroupPostService : IGroupPost
    {
        IRashakaUniteOfWork repo;
        ICommentSystemService commentSystemService;
        IAdminUsers iAdminUsers;
        readonly ICommentSystemService iCommentSystem;
        public GroupPostService(IRashakaUniteOfWork _repo, IAdminUsers _iAdminUsers, ICommentSystemService commentSystemService, ICommentSystemService iCommentSystem)
        {
            repo = _repo;
            this.commentSystemService = commentSystemService;
            iAdminUsers = _iAdminUsers;
            this.iCommentSystem = iCommentSystem;
        }
        public async Task<int> AddEditGroupPost(PostModel model)
        {
            int? groupId = GlobalValues.GroupId ?? iAdminUsers.GetLoggedGroupId();
            int accountId = iAdminUsers.GetLoggedUserId();
            GroupPost post = new GroupPost
            {
                accountId = accountId,
                groupId = groupId,
                description = model.description
            };
            string jsonData = JsonSerializer.Serialize(post);
            HttpClient _httpclient = new HttpClient();
            using (var multiPartStream = new MultipartFormDataContent())
            {
                multiPartStream.Add(new StringContent(jsonData), "data");

                if (model.image != null)
                {
                    multiPartStream.Add(new StreamContent(model.image.OpenReadStream()), "image", model.image.FileName);
                }
                if (model.image2 != null)
                {
                    multiPartStream.Add(new StreamContent(model.image2.OpenReadStream()), "image2", model.image2.FileName);
                }
                if (model.image3 != null)
                {
                    multiPartStream.Add(new StreamContent(model.image3.OpenReadStream()), "image3", model.image3.FileName);
                }

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, /*"http://localhost:8080/api/Groups/AddPost"*/ "http://api.rashaqa.net/api/Groups/AddPost");
                request.Content = multiPartStream;
                HttpCompletionOption option = HttpCompletionOption.ResponseContentRead;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                using (HttpResponseMessage response = _httpclient.SendAsync(request, option).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        dynamic resultJson = JsonSerializer.Deserialize<dynamic>(result.ToString());
                        var id = resultJson["postId"];
                        //var deserializedObject = JsonConvert.DeserializeObject<object>(result);
                        //dynamic data = JArray.Parse(result.ToString());
                        return (Int32)id;// deserializedObject.postId;
                    }
                    return 0;
                }
            }
        }
        public bool ShareWeekUserAsPost(string user, string steps, int groupId)
        {
            GroupPost post = new GroupPost
            {
                image = "weekWinner.jpg",
                isAllowed = true,
                date = DateTime.Now,
                groupId = groupId,
                accountId = iAdminUsers.GetLoggedUserId(),
                title = "بطل الأسبوع",
                description = "بطل الأسبوع من حيث عدد الخطوات هو" + " " + user + " " + "حيث حقق " + steps + " خطوة"
            };
            repo.iRashaka<GroupPost>().Add(post);
            repo.Save();
            return true;
        }
        public object AddPostComment(AddGroupPostCommentModel model)
        {

            var _commentId = DapperService<object>.ExecuteScalar("AddPostComment", new
            {
                accountId = model.accountId,
                groupPostId = model.groupPostId,
                comment = model.comment,
                date = DateTime.Now
            }, CommandType.StoredProcedure);
            int commentId = Convert.ToInt32(_commentId);
            if (commentId > 0)
            {
                AddNormalCommentToCommentSystem(model);
            }
            return commentId;
        }
        public void AddNormalCommentToCommentSystem(AddGroupPostCommentModel model)
        {
            try
            {
                Thread workerOne = new Thread(() =>
                {
                    Account account = repo.iRashaka<Account>().Find(model.accountId);
                    GroupPost groupPost = repo.iRashaka<GroupPost>().Find(model.groupPostId);
                    var result = commentSystemService.AddComment(account.guid, model.comment, groupPost.commentArtGuid, groupPost.guid, 2);
                    groupPost.commentArtGuid = Guid.Parse(result.ArtGuid);
                    groupPost.commentSystemCommentsCount = groupPost.commentSystemCommentsCount == null ? 1 : groupPost.commentSystemCommentsCount + 1;
                    repo.Save();
                });
                workerOne.Start();
            }
            catch (Exception)
            {
            }

        }
        public object PinnPost(int postId, int groupId)
        {
            return DapperService<object>.ExecuteScalar("update groupPosts set ispinned=0 where groupId=" + groupId + " and ispinned=1; update groupPosts set ispinned=1 where id=" + postId + "");
        }
        public bool DeletePost(int id)
        {
            int? accountId = iAdminUsers.GetLoggedUserId();
            GroupPost post = repo.iRashaka<GroupPost>().GetByIncluding(x => x.id == id, "group");
            if (post.group.creatorId == accountId)
            {
                post.isAllowed = false;
                repo.Save();
                return true;
            }
            return false;
        }
        public ReportedPosts GroupPostRports(int id, int? page)
        {
            var groupPostReport = repo.iRashaka<GroupPost>().GetAll(X => X.groupId == id && X.reportsCount > 0, X => X.id, page ?? 1, 40, "group");
            ReportedPosts posts = new ReportedPosts()
            {
                Posts = groupPostReport,
                GroupName = groupPostReport.Select(x => x.group.name).FirstOrDefault(),
                GroupId = id
            };
            return posts;
        }
        public bool AddComment(Guid? accountGUID, int postId, string text)
        {
            GroupPost groupPost = repo.iRashaka<GroupPost>().Find(postId);
            Guid? userGUID = iAdminUsers.GetLoggedUserGUId();
            var result = iCommentSystem.AddComment(userGUID, text, groupPost.commentArtGuid, groupPost.guid, 2);
            groupPost.commentArtGuid = Guid.Parse(result.ArtGuid);
            groupPost.commentSystemCommentsCount = groupPost.commentSystemCommentsCount == null ? 1 : groupPost.commentSystemCommentsCount + 1;
            repo.Save();
            return true;
        }
        public Comments GetPostComments(CommentModel model)
        {
            GroupPost POSt = repo.iRashaka<GroupPost>().Find(model.id);


            Comments result = commentSystemService.GetArticleCommentsFromCommentSystem(model.commentArtGuid, model.artGuid.ToString(), model.date);
            result.postId = model.id;
            result.groupId = POSt.groupId ?? 0;
            result.artGuid = model.artGuid;
            result.commentArtGuid = POSt.commentArtGuid;
            result.description = POSt.description;
            result.postId = model.id;
            result.accountName = POSt.account != null ? POSt.account.name : "مجموعة رشاقة الرسمية";
            result.profileImage = POSt.account != null ? POSt.account.image : "rashaka.png";


            if (result.comments != null && result.comments.Count > 0)
                result.date = result.comments.Last().date;
            else
                result.date = (DateTime.Now).ToString("dd-MM-yyyy HH:mm");
            return result;
        }
    }
}