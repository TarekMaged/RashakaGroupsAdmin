using RashakaGroupsAdmin.Repository;
using RashakaGroupsAdmin.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using RashakaGroupsAdmin.Models;
using Microsoft.EntityFrameworkCore;
using RashakaGroupsAdmin.ViewModel;

namespace RashakaGroupsAdmin.Models
{
    public class CommentClass
    {
        public Guid accountArtGuid { get; set; }
        public Guid accountCommentGuid { get; set; }
        public string text { get; set; }
        public Guid programArtGuid { get; set; }
        public string artTypeId { get; set; }
    }
    public class CommentAdd
    {
        public Guid? ArtGuid { get; set; }
        public string commentGuid { get; set; }
        public string commentCount { get; set; }
    }
    public class CommentRepo
    {
        private readonly RashakaContext db = new RashakaContext();
        private readonly DateConverter _objDateConverter = new DateConverter();
        
        enum accountTypeId
        {
            facebook = 1,
            twitter = 2,
            google = 3,
            website = 5,
        }
        
        private Account getuserAccount(int userAccountId)
        {
            try
            {
                Account userAccount = db.Accounts.Include("user").Where(x => x.id == userAccountId).FirstOrDefault();
                return userAccount;
            }
            catch (Exception)
            {
                return null;
            }
        }
     
        /// <summary>
        /// add first comment on article only 
        /// </summary>
        /// <param name="_objAdd"></param>
        /// <returns></returns>
        public CommentAdd addBlogArticleCommentSystem(Guid? programArtGuid, Guid? accountArtGuid, string text, string accountCommentGuid)
        {
            CommentAdd comentSystemGuids = new CommentAdd()
            {
                ArtGuid = null,
                commentGuid = null
            };
            dynamic resultJosn;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://commentsystem.madarsoft.com/api/Comment/addCommentWithArt");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"programArtGuid\":\"" + programArtGuid + "\"," + "\"accountArtGuid\":\"" + accountArtGuid + "\","
                        + "\"accountCommentGuid\":\"" + accountCommentGuid + "\"," + "\"text\":\"" + text
                        + "\"," + "\"programId\":\"" +6+"\"," + "\"artTypeId\":\"" + 1 + "\"}";
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
                comentSystemGuids = new CommentAdd
                {
                    ArtGuid = resultJosn["response"]["commentArtGuid"],
                    commentGuid = resultJosn["response"]["commentGuid"],
                    commentCount = resultJosn["response"]["commentCount"]
                };
            }
            return comentSystemGuids;
        }
        private CommentAdd AddCommentInCommentSystem(Guid? CommentSystemGuid, string accountCommentGuid, string text)
        {
            dynamic resultJosn;
            CommentAdd comentSystemGuids = new CommentAdd()
            {
                ArtGuid = null,
                commentGuid = null
            };
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://commentsystem.madarsoft.com/api/Comment/add");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"CommentArtGuid\":\"" + CommentSystemGuid + "\"," + "\"accountGuid\":\"" + accountCommentGuid + "\"," + "\"text\":\"" + text + "\"}";
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
                comentSystemGuids = new CommentAdd
                {
                    ArtGuid = resultJosn["response"]["commentArtGuid"],
                    commentGuid = resultJosn["response"]["commentGuid"],
                    commentCount = resultJosn["response"]["commentCount"]
                };
            }
            return comentSystemGuids;
        }
       
       

      
     
      
      
   
     
        public List<CommentSystemVM> CommentSearch(string searchText)
        {
            try
            {
                dynamic resultJosn;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://commentsystem.madarsoft.com/api/CommentV2/search");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                List<CommentSystemVM> _CommentSystemVM = new List<CommentSystemVM>();

                RashakaContext db = new RashakaContext();
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"accountGuid\":\"00000000-0000-0000-0000-000000000000\","
                        + "\"date\":\"" + "" + "\"," + "\"text\":\"" + searchText + "\","
                        + "\"programId\":\"" +6+"\"}";
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
                    object CommentList = resultJosn["response"]["comments"];
                    object replies = null;
                    _CommentSystemVM.AddRange(((JArray)CommentList).Select(x => new CommentSystemVM
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
                        image = (string)x["image"],
                    }).ToList());
                }

                return _CommentSystemVM;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
     
       }
}