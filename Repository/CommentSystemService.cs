using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RashakaAdmin.Models;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Services;
using RashakaGroupsAdmin.ViewModel;
using System.Net;

namespace RashakaGroupsAdmin.Repository
{

    public class CommentSystemService : ICommentSystemService
    {
        const string commentSystemBaseURL = "http://commentsystem.madarsoft.com/api/";
        IimagesSevice imagesSevice;
        public CommentSystemService(IimagesSevice imagesSevice)
        {
            this.imagesSevice = imagesSevice;
        }
        public string AddReplyToCommentSystem(Account replierAccount, ReplyJson replyJson, string CommentSystemGuid, string text)
        {
            string json = "{\"commentGuid\":\"" + CommentSystemGuid + "\","
                        + "\"accountGuid\":\"" + replierAccount.guid.ToString() + "\"," + "\"text\":\"" + text + "\"}";
            //," + "\"accountCommentGuid\":\"" + accountGUID + "\",
            dynamic resultJosn = GetResponseFromCommentSyste(commentSystemBaseURL + "ReplyComment/add", json);
            string replyGuid = resultJosn["response"]["replyGuid"];
            if (resultJosn["success"] == true)
            {
                //SendAfterAddReply(replierAccount, replyJson, replyGuid);
                //sendNotificationforMainCommentUser(accountGuid, commentArtGuid);
                return "Success";
            }

            return "Failed";
        }



        public Comments GetArticleCommentsFromCommentSystem(string commentArtGuid, string artGuid, string date)
        {

            string json = "{\"commentArtGuid\":\"" + commentArtGuid + "\"," + "\"accountGuid\":\"00000000-0000-0000-0000-000000000000\","
                      + "\"date\":\"" + date + "\"," + "\"artGuid\":\"" + artGuid
                      + "\"," + "\"programId\":" + 6 + "}";

            Comments GetComments = new Comments()
            {
                timeZone = DateTime.Now,
                comments = new List<CommentSystem>()
            };
            dynamic resultJosn = GetResponseFromCommentSyste(commentSystemBaseURL + "CommentV2/getComments", json);
            if (resultJosn["success"] == true)
            {
                GetComments.timeZone = resultJosn["response"]["timeZone"];
                object CommentList = resultJosn["response"]["comments"];
                object replies = null;
                GetComments.comments.AddRange(((JArray)CommentList).Select(x => new CommentSystem
                {
                    guid = (string)x["guid"],
                    text = (string)x["text"],
                    date = (string)x["date"],
                    likeCount = Convert.ToInt32(x["likeCount"]),
                    replyCount = Convert.ToInt32(x["replyCount"]),
                    userName = (string)x["userName"],
                    accountGuid = (string)x["accountGuid"],
                    replies = ((JArray)(replies = x["replies"]))
                    .Select(r => new Reply
                    {
                        text = (string)r["text"],
                        date = (string)r["date"],
                        likeCount = Convert.ToInt32(r["likeCount"])
                    }).ToList(),
                    image = imagesSevice.GetProfileImageUrl(x["image"].ToString(), ""),
                }).ToList());
            }
            return GetComments;
        }

        public string unReportCommentFromCommentSystem(string commentGuid)
        {
            dynamic resultJosn;

            Comments comments = new Comments()
            {
                timeZone = DateTime.Now,
                comments = new List<CommentSystem>()
            };
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://commentsystem.madarsoft.com/api/Comment/unReport");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"commentGuid\":\"" + commentGuid + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                resultJosn = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
            }
            if (resultJosn["success"] == true)
            {
                return "Success";
            }
            return "Failed";
        }

        public GetReplies getReportedRepliesFromCommentSystem(string date)
        {
            dynamic resultJosn;

            GetReplies GetReplies = new GetReplies()
            {
                timeZone = DateTime.Now,
                replies = new List<Reply>()
            };
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://commentsystem.madarsoft.com/api/ReplyComment/getReported");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"date\":\"" + date + "\"," + "\"programId\":" + 6 + "}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                resultJosn = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
            }
            if (resultJosn["success"] == true)
            {
                object CommentList = resultJosn["response"];
                GetReplies.replies.AddRange(((JArray)CommentList).Select(x => new Reply
                {
                    guid = (string)x["replyGuid"],
                    text = (string)x["text"],
                    reason = (string)x["reason"],
                    reasonText = (string)x["reasonText"],
                    commentArtGuid = (string)x["commentArtGuid"],
                    date = (string)x["date"],
                    likeCount = Convert.ToInt32(x["likeCount"]),
                    userName = (string)x["userName"],
                    accountGuid = (string)x["accountGuid"],
                    image = (string)x["image"],
                }).ToList());
            }
            return GetReplies;
        }

        public string AddReplyToCommentSystem(string CommentSystemGuid, string text, string accountGuid)
        {
            string json = "{\"commentGuid\":\"" + CommentSystemGuid + "\","
                        + "\"accountGuid\":\"" + accountGuid + "\"," + "\"text\":\"" + text + "\"}";
            //," + "\"accountCommentGuid\":\"" + accountGUID + "\",
            dynamic resultJosn = GetResponseFromCommentSyste(commentSystemBaseURL + "ReplyComment/add", json);

            if (resultJosn["success"] == true)
            {
                // sendNotificationforMainCommentUser(accountGuid, commentArtGuid);
                return "Success";
            }

            return "Failed";
        }
        public AddCommentResponse AddComment(Guid? accountGUID, string comment, Guid? commentArtGuid, Guid? guid, int artType)
        {
            AddCommentResponse comentSystemGuids = new AddCommentResponse();

            string json = "{\"programId\":6," + "\"artTypeId\":" + artType + "," + "\"text\":\"" + comment + "\"," + "\"commentArtGuid\":\"" + commentArtGuid + "\"," + "\"accountCommentGuid\":\"" + accountGUID + "\"," + "\"programArtGuid\":\"" + guid + "\"}";
            dynamic resultJosn = GetResponseFromCommentSyste(commentSystemBaseURL + "CommentV3/addComment", json);
            if (resultJosn["success"] == true)
            {
                comentSystemGuids.ArtGuid = resultJosn["response"]["commentArtGuid"];
                comentSystemGuids.commentGuid = resultJosn["response"]["commentGuid"];
                comentSystemGuids.commentCount = Convert.ToInt32(resultJosn["response"]["commentCount"]);
            }
            return comentSystemGuids;
        }

        public object GetResponseFromCommentSyste(string url, string json)
        {
            dynamic resultJosn;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                resultJosn = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
            }
            return resultJosn;
        }
        public Comments getReportedCommentsFromCommentSystem(string date)
        {
            string json = "{\"date\":\"" + date + "\"," + "\"programId\":" + 6 + "}";
            dynamic resultJosn = GetResponseFromCommentSyste(commentSystemBaseURL + "Comment/getReported", json);


            Comments Comments = new Comments()
            {
                timeZone = DateTime.Now,
                comments = new List<CommentSystem>()
            };

            if (resultJosn["success"] == true)
            {
                object CommentList = resultJosn["response"];
                object replies = null;
                Comments.comments.AddRange(((JArray)CommentList).Select(x => new CommentSystem
                {
                    guid = (string)x["commentGuid"],
                    text = (string)x["text"],
                    ArtName = getNameOfArt((string)x["commentArtGuid"]),
                    reason = (string)x["reason"],
                    commentArtGuid = (string)x["commentArtGuid"],
                    date = (string)x["date"],
                    reasonText = (string)x["reasonText"],
                    likeCount = Convert.ToInt32(x["likeCount"]),
                    replyCount = Convert.ToInt32(x["replyCount"]),
                    userName = (string)x["userName"],
                    accountGuid = (string)x["accountGuid"],
                    replies = ((JArray)(replies = x["replies"]))
                    .Select(r => new Reply
                    {
                        text = (string)r["text"],
                        date = (string)r["date"],
                        likeCount = Convert.ToInt32(r["likeCount"])
                    }).ToList(),
                    image = (string)x["image"],
                }).ToList());
            }
            return Comments;
        }
        public string getNameOfArt(string guid)
        {
            //    RashakaEntities db = new RashakaEntities();
            //    string artName = "";
            //    artName = db.News.Where(x => x.commentArtGuid == new Guid(guid)).Select(x => x.title).FirstOrDefault();
            //    if (artName == "" || artName == null)
            //    {
            //        artName = "استطلاع-" + db.Surveys.Where(x => x.commentSystemGuid == new Guid(guid)).Select(x => x.question).FirstOrDefault();
            //    }
            //    return artName;
            return "";
        }
        public string deleteCommentFromCommentSystem(string commentArtGuid, string commentGuid)
        {
            string json = "{\"commentGuid\":\"" + commentGuid + "\"," + "\"accountGuid\":\"00000000-0000-0000-0000-000000000001\","
                       + "\"commentArtGuid\":\"" + commentArtGuid + "\"}";

            dynamic resultJosn = GetResponseFromCommentSyste(commentSystemBaseURL + "Comment/delete", json);

            if (resultJosn["success"] == true)
            {
                return "success";
            }
            return "failed";
        }
        public GetReplies getRepliesFromCommentSystem(string commentGuid, string accountGuid, string date)
        {
            dynamic resultJosn;

            GetReplies GetReplies = new GetReplies()
            {
                commentGuid = commentGuid,
                timeZone = DateTime.Now,
                replies = new List<Reply>()
            };
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://commentsystem.madarsoft.com/api/ReplyCommentV2/getReplies");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"commentGuid\":\"" + commentGuid + "\","
                        + "\"date\":\"" + date + "\"," + "\"accountGuid\":\"" + accountGuid + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                resultJosn = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
            }
            if (resultJosn["success"] == true)
            {
                GetReplies.timeZone = resultJosn["response"]["timeZone"];
                object CommentList = resultJosn["response"]["replies"];
                GetReplies.replies.AddRange(((JArray)CommentList).Select(x => new Reply
                {
                    guid = (string)x["guid"],
                    text = (string)x["text"],
                    date = (string)x["date"],
                    reasonText = (string)x["reasonText"],
                    likeCount = Convert.ToInt32(x["likeCount"]),
                    userName = (string)x["userName"],
                    accountGuid = (string)x["accountGuid"],
                    image = (string)x["image"],
                }).ToList());
            }
            return GetReplies;
        }

        public string deleteReplyFromCommentSystem(string replyGuid)
        {
            dynamic resultJosn;

            GetReplies GetReplies = new GetReplies()
            {
                timeZone = DateTime.Now,
                replies = new List<Reply>()
            };
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://commentsystem.madarsoft.com/api/ReplyComment/delete");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"replyGuid\":\"" + replyGuid + "\"," + "\"accountGuid\":\"00000000-0000-0000-0000-000000000001\"" + "}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                resultJosn = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
            }
            if (resultJosn["success"] == true)
            {
                return "Success";
            }
            return "Failed";
        }
        public string unReportReplyFromCommentSystem(string replyGuid)
        {
            dynamic resultJosn;           
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://commentsystem.madarsoft.com/api/ReplyComment/unReport");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"replyGuid\":\"" + replyGuid + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                resultJosn = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
            }
            if (resultJosn["success"] == true)
            {
                return "Success";
            }
            return "Failed";
        }
    }
}