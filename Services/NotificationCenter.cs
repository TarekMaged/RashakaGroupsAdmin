using Newtonsoft.Json;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Requests;
using RashakaGroupsAdmin.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace RashakaAdmin.Models
{
    public class NotificationService: INotification
    {
        //static string APIkey ="AAAAhKBV6nY:APA91bE5tovaj1Y5MC0Uk7JSE8_91flz69_7f0RKLM3SYvZqJiw3bfnMj_fsAwc0HRc-KOnbfepmpRzWNTVFud2H16JXb4lwewCqYJ4g1MylDYwpuWf9zY8jTX-FE2hkkhOdcwN535DY";
        static string APIkey = "AAAAhKBV6nY:APA91bE5tovaj1Y5MC0Uk7JSE8_91flz69_7f0RKLM3SYvZqJiw3bfnMj_fsAwc0HRc-KOnbfepmpRzWNTVFud2H16JXb4lwewCqYJ4g1MylDYwpuWf9zY8jTX-FE2hkkhOdcwN535DY";//"AAAAhKBV6nY:APA91bGC5EFdplhihUqgLYq7wC02LKc_UK2uKB6p6NQC_AzKlNTB_BnMJPLYfgXfHcVR0DW7qlGxDjYuAfcpRRgagVeqrnwU89juj8iCuH2Iiflqu7uGP4R65VWUcHfELzdC_IOPhmMd"; //"AAAAhKBV6nY:APA91bE5tovaj1Y5MC0Uk7JSE8_91flz69_7f0RKLM3SYvZqJiw3bfnMj_fsAwc0HRc-KOnbfepmpRzWNTVFud2H16JXb4lwewCqYJ4g1MylDYwpuWf9zY8jTX-FE2hkkhOdcwN535DY";


        RashakaContext db;
        IRashakaUniteOfWork repo;
        IAdminUsers iadminUsers;
        public NotificationService(IRashakaUniteOfWork _repo, IAdminUsers adminUsers)
        {
            db = new RashakaContext();
            repo = _repo;
            this.iadminUsers = adminUsers;
        }

        public static string SendToOneTokensOfFoodSuggestions(string token)
        {
            List<string> tokens = new List<string>() { token };
            string message = "شكرا جزيلا لكم تمت إضافة إقتراحاتكم للوجبات";
            string stringregIds = string.Join("\",\"", tokens);
            string json = "{\"registration_ids\":[\"" + stringregIds + "\"],\"time_to_live\":3600,\"priority\":\"high\",\"notification\": { \"body\" : \"'" + message + "'\",\"type\" : \"normal\",\"content-available\":\"1\",\"badge\" : \"1\",\"sound\" : \"sound.caf\",\"e\":0},\"data\": {\"message\" : \"" + message + "\",\"type\" : \"normal\",\"badge\" : \"1\"}}";
            if (tokens.Count() > 0)
            {
                return Send(json, false) == "1" ? "success" : "error";
            }

            return "no users";
        }

        public static void SendAcceptBlockNotification(GroupUserModel model, string groupName, IRashakaUniteOfWork repo)
        {
            try
            {
                Thread workerOne = new Thread(() =>
                {
                    var accessToken = DapperService<object>.ExecuteScalar("GetUserAccessToken", new { accountId = model.accountId }, CommandType.StoredProcedure);
                    if (accessToken != null)
                    {
                        string message = "تم قبول عضويتك فى مجموعة" + " " + groupName;
                        if (model.isAccepted == false)
                        {
                            message = "تم رفض عضويتك فى مجموعة" + " " + groupName; // "acceptGroupUser"
                        }
                        sendToDeviceToken(message, model.groupId, "previewGroup", new List<string> { accessToken.ToString() });
                    }

                });
                workerOne.Start();
            }
            catch
            {


            }

        }
        public static void AcceptPostIngroup(GroupPost post)
        {
            try
            {
                if (post.accountId > 0 && post.groupId > 0)
                {
                    //Thread workerOne = new Thread(() =>
                    //{
                    var accessToken = DapperService<object>.ExecuteScalar("GetUserAccessToken", new
                    {
                        accountId = post.accountId
                    }, CommandType.StoredProcedure);
                    if (!string.IsNullOrWhiteSpace(accessToken.ToString()))
                    {
                        string message = "تم السماح للمنشور الخاص بك ";
                        sendToDeviceToken(message, post.groupId, "previewGroup", new List<string> { accessToken.ToString() });
                    }
                    //});
                    //workerOne.Start();
                }
            }
            catch (Exception ex)
            {
            }
        }


        public static string sendToDeviceToken(string message, int? groupId, string type, List<string> deviceToken)
        {
            var result = "";
            try
            {
                if (deviceToken.Count > 0)
                {
                    string date = DateTime.Now.ToString();
                    string stringregIds = string.Join("\",\"", deviceToken);
                    string json = "{\"registration_ids\":[\"" + stringregIds + "\"],\"time_to_live\":3600,\"priority\":\"high\",\"notification\": { \"body\" : \"" + message + "\",\"groupId\" : \"" + groupId + "\",\"title\" : \"رشاقة\",\"type\" : \"" + type + "\",\"content-available\":\"1\",\"badge\" : \"1\",\"sound\" : \"sound.caf\",\"e\":0},\"data\": {\"message\" : \"" + message + "\",\"groupId\" : \"" + groupId + "\",\"type\" : \"" + type + "\",\"badge\" : \"1\"}}";

                    result = Send(json, false);
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public static string SendToTokens(GroupsNotificationModel items)
        {
            string json = string.Empty;
            var accessToken = string.Empty;
            if (items.accountId > 0)
            {
                accessToken = DapperService<object>.ExecuteScalar("GetUserAccessToken", new
                {
                    accountId = items.accountId
                }, CommandType.StoredProcedure).ToString();

                items.tokens = new List<string> { accessToken.ToString() };

                string stringregIds = string.Join("\",\"", items.tokens);
                json = "{\"registration_ids\":[\"" + stringregIds + "\"],\"content-available\":\"1\",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": {\"body\" : \"" + items.Message + "\",\"page\" : \"\",\"articleId\" : \"\",\"eventId\" : \"\",\"postId\" : \"\",\"groupId\" :\"" + items.groupId + "\",\"mealId\" : \"\",\"URL\" : \"\",\"version\" : \"\",\"date\" : \"" + DateTime.Now + "\",\"title\" : \"" + items.Message + "\",\"type\" : \"" + items.Type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0},\"data\": {\"message\" : \"" + items.Message + "\"   ,\"page\" : \"\",\"articleId\" : \"\",\"eventId\" : \"\",\"postId\" : \"\",\"groupId\" : \"" + items.groupId + "\",\"mealId\" : \"\",\"URL\" : \"\",\"version\" : \"\",\"date\" : \"" + DateTime.Now + "\",\"title\" : \"" + items.Message + "\",\"type\" : \"" + items.Type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0}}";
                return Send(json, false);
            }

            string topic = "New_group_" + items.groupId;
            json = "{\"to\":\"/topics/" + topic + "\",\"content-available\":\"1\",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": {\"body\" : \"" + items.Message + "\",\"page\" : \"\",\"articleId\" : \"\",\"eventId\" : \"\",\"postId\" : \"\",\"groupId\" : \"" + items.groupId + "\",\"mealId\" : \"\",\"URL\" : \"\",\"version\" : \"\",\"date\" : \"" + DateTime.Now + "\",\"title\" : \"" + items.Message + "\",\"type\" : \"" + items.Type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0},\"data\": {\"message\" : \"" + items.Message + "\"   ,\"page\" : \"\",\"articleId\" : \"\",\"eventId\" : \"\",\"postId\" : \"\",\"groupId\" : \"" + items.groupId + "\",\"mealId\" : \"\",\"URL\" : \"\",\"version\" : \"\",\"date\" : \"" + DateTime.Now + "\",\"title\" : \"" + items.Message + "\",\"type\" : \"" + items.Type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0}}";
            return Send(json, true);
        }

    
        public static string SendSilentNotificationToTopic()
        {
            var result = "";
            string date = DateTime.Now.ToString();
            string json = "{\"to\":\"/topics/sensor_foreground_topic\",\"priority\":\"high\",\"content_available\":true,\"data\": {\"silentPush\" : \"1\",\"content_available\":true,\"type\" : \"foreground\"}}";
            //string json = "{\"to\":\"/topics/fitness_android_global\",\"priority\":\"high\",\"data\": {\"رشاقة\" : \"foreground\",\"type\" : \"foreground\",\"badge\" : \"1\"}}";
            result = Send(json, true);
            return result;
        }
        public static string Send(string json, bool isTopic)
        {
            //var result = "true";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", APIkey));

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        dynamic resultJosn = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
                        if (isTopic)
                        {
                            return "تم الارسال بنجاح";// resultJosn["message_id"];
                        }
                       string res= resultJosn["success"];
                        return res == "1" ? "تم الارسال بنجاح" : "حدث خطأ";
                    }
                }
            }
            catch (Exception ex)
            {
                return " حدث خطأ " + ex.Message;
            }

        }
        public static string GenerateTopicsString(List<string> topics)
        {
            string schema = "\"";
            if (topics.Count > 1)
            {
                for (int i = 1; i < topics.Count; i++)
                {
                    schema += "'" + topics[i] + "' in topics ||";
                }
                schema += "'" + topics[0] + "' in topics";
            }
            else
            {
                schema += "'" + topics[0] + "' in topics";
            }
            return schema;
        }
        public string SendAfterAddingGroupPost(int postId)
        {
            int? groupId = repo.iRashaka<GroupPost>().Find(postId).groupId;
            if (groupId > 0)
            {
                string message = "أرسل إليك قائد المجموعة دعوة إلى منشور";
                string topic =  "New_group_" + groupId ;
                string token = "el3Xt7G_Q0OoeDg4D4N-Bq:APA91bEcBtboed-QJF6a04-qiqV8casMttcO_TXbb3gnOanyZvRydpGQKq0JnZvhytCb6gY7SccQ9-8dmJljllX93hHEcWkLFeeEI1PRZb39ZJKwGFOb3xNmjr37PC3c7HXGmxNKMnxB";

                //string stringregIds = string.Join("\",\"", token);
                //return "{\"registration_ids\":[\"" + stringregIds + "\"],\"content-available\":\"1\",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": {\"body\" : \"" + data.body + "\",\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0},\"data\": {\"message\" : \"" + data.body + "\"   ,\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0}}";


                string json = "{\"to\":\"/topics/" + topic + "\",\"content-available\":\"1\",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": {\"body\" : \"" + message + "\",\"page\" : \"\",\"articleId\" : \"0\",\"eventId\" : \"0\",\"postId\" : \"" + postId + "\",\"groupId\" : \"" + groupId + "\",\"mealId\" : \"\",\"URL\" : \"\",\"version\" : \"\",\"date\" : \"" + DateTime.Now + "\",\"title\" : \"" + message + "\",\"type\" : \"groupPostPublic\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0},\"data\": {\"message\" : \"" + message + "\"   ,\"page\" : \"\",\"articleId\" : \"\",\"eventId\" : \"\",\"postId\" : \"" + postId + "\",\"groupId\" : \"" + groupId + "\",\"mealId\" : \"0\",\"URL\" : \"\",\"version\" : \"\",\"date\" : \"" + DateTime.Now + "\",\"title\" : \"" + message + "\",\"type\" : \"groupPostPublic\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0}}";
               return Send(json, false);
            }
            return "";
        }

        //public string SendNotificationNow(NotificationData model)
        //{
        //    string res = SendMainNotification(model);
        //    if (!res.Contains("خطأ"))
        //    {
        //        SaveNotificationHistory(model);
        //    }
        //    return res;
        //}


        public string SendMainNotification(NotificationData data)
        {
            data.pageName = data.type == "inner" ? data.pageName : "";
            string res = string.Empty;

            data.groupId = iadminUsers.GetLoggedGroupId().ToString();// data.pageName == "eventDetails" && string.IsNullOrEmpty(data.groupId) ? repo.iRashaka<GroupEvent>().Find(Int32.Parse(data.eventId)).groupId.ToString() : data.groupId;
            string json = CreateNotificationJson(data);
            res = Send(json, string.IsNullOrEmpty(data.deviceToken) ? true : false);

            return res;
        }

        public string SendMainNotificationToDeviceToken(NotificationData data)
        {
            data.pageName = data.type == "inner" ? data.pageName : "";
            string res = string.Empty;

            data.groupId = data.pageName == "eventDetails" && string.IsNullOrEmpty(data.groupId) ? repo.iRashaka<GroupEvent>().Find(Int32.Parse(data.eventId)).groupId.ToString() : data.groupId;
            string json = CreateNotificationJsonByDeviceToken(data);
            res = Send(json, string.IsNullOrEmpty(data.deviceToken) ? true : false);

            return res;
        }
        public static void SendReplyNotification(ReplyNotificationData data)
        {
            string schemaTopics = GenerateTopicsString(data.topics);

            //string json = "{\"condition\":" + schemaTopics + " \",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": { \"body\" : \"" + data.replyTopicMessage + "\",\"title\" : \"" + data.programName + "\",\"accountGuid\" : \"" + data.accountGuid + "\",\"commentGuid\" : \"" + data.commentGuid + "\",\"replyGuid\" : \"" + data.replyGuid + "\",\"programArtGuid\" : \"" + data.programArtGuid + "\",\"type\" : \"reply\",\"content-available\":\"1\" ,\"userName\" : \"" + data.userName + "\",\"image\" : \"" + data.image + "\",\"replyTopic\" : \"" + data.replyTopic + "\",\"commentTopic\" : \"" + data.commentTopic + "\",\"badge\" : \"1\",\"sound\" : \"sound.caf\",\"e\":0},\"data\": {\"message\" : \"" + data.replyTopicMessage + "\",\"accountGuid\" : \"" + data.accountGuid + "\",\"commentGuid\" : \"" + data.commentGuid + "\",\"replyGuid\" : \"" + data.replyGuid + "\",\"programArtGuid\" : \"" + data.programArtGuid + "\",\"type\" : \"reply\",\"userName\" : \"" + data.userName + "\",\"image\" : \"" + data.image + "\",\"replyTopic\" : \"" + data.replyTopic + "\",\"commentTopic\" : \"" + data.commentTopic + "\",\"badge\" : \"1\"}}";        
            string json = "{\"condition\":" + schemaTopics + " \",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": { \"body\" : \"" + data.replyTopicMessage + "\",\"title\" : \"" + data.programName + "\",\"accountGuid\" : \"" + data.actionAccountGuid + "\",\"commentGuid\" : \"" + data.commentGuid + "\",\"ArtId\" : \"" + data.programArtId + "\",\"replyGuid\" : \"" + data.replyGuid + "\",\"commentArtGuid\" : \"" + data.commentArtGuid + "\",\"type\" : \"reply\",\"userName\" : \"" + "\",\"replyType\" : \"" + data.replyType + "\",\"replyTopic\" : \"" + data.replyTopic + "\",\"commentTopic\" : \"" + data.commentTopic + "\",\"badge\" : \"1\",\"sound\" : \"sound.caf\",\"e\":0},\"data\": {\"message\" : \"" + data.replyTopicMessage + "\",\"ArtId\" : \"" + data.programArtId + "\",\"accountGuid\" : \"" + data.actionAccountGuid + "\",\"commentGuid\" : \"" + data.commentGuid + "\",\"replyType\" : \"" + data.replyType + "\",\"replyGuid\" : \"" + data.replyGuid + "\",\"commentArtGuid\" : \"" + data.commentArtGuid + "\",\"type\" : \"reply\",\"userName\" : \"" + data.userName + "\",\"replyTopic\" : \"" + data.replyTopic + "\",\"commentTopic\" : \"" + data.commentTopic + "\",\"badge\" : \"1\"}}";

            Send(json, true);
            if (data.deviceToken != null)
            {
                //Distinct solve issue when user add post then add comment on post and some one reply for this comment 
                //we seen 2 notification send to device why? because we send to device owner and device comment owner 
                // in this case the post owner and comment owner the same device so we add Distinct() method
                string stringIds = string.Join("\",\"", data.deviceToken.Where(x => x != "").Distinct());

                json = "{\"registration_ids\":[\"" + stringIds + "\"],\"time_to_live\":3600,\"mutable-content\" : \"True\",\"data\": {\"message\" : \"" + data.replyTopicMessage + "\",\"postOwnerMessage\" : \"" + data.postOwnerMessage + "\",\"commentOwnerMessage\" : \"" + data.commentOwnerMessage + "\",\"actionAccountGuid\" : \"" + data.actionAccountGuid + "\",\"postOwnerAccountGuid\" : \"" + data.postOwnerAccountGuid + "\",\"replyType\" : \"" + data.replyType + "\",\"commentOwnerAccountGuid\" : \"" + data.commentOwnerAccountGuid + "\",\"commentGuid\" : \"" + data.commentGuid + "\",\"replyGuid\" : \"" + data.replyGuid + "\",\"guid\" : \"" + data.guid + "\",\"type\" : \"reply\",\"isSendByServer\" : \"false\",\"userName\" : \"" + data.userName + "\",\"image\" : \"" + data.image + "\",\"replyTopic\" : \"" + data.replyTopic + "\",\"commentTopic\" : \"" + data.commentTopic + "\",\"commentArtGuid\" : \"" + data.commentArtGuid + "\",\"badge\" : \"1\",\"sound\" : \"notificationsound.mp3\"}}";
                Send(json, false);
            }
        }



        public string CreateNotificationJson(NotificationData data)
        {
            string date = DateTime.Now.ToString();
            if (data.pageName == "eventDetails")
            {
                int eventId = Convert.ToInt32(data.eventId);
                data.groupId = repo.iRashaka<GroupEvent>().Find(eventId).groupId.ToString();
            }
            string schema = CreateTopic(data);

            if (data.isRich != null)
            {
                return "{\"condition\": " + schema + " \",\"mutable_content\" :true,\"mutable-content\" :1,\"content-available\":true,\"priority\":\"high\",\"notification\": {\"body\" : \"" + data.body + "\",\"richType\" : \"richType\",\"imageUrl\" : \"" + data.imageUrl + "\"   ,\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"badge\" : \"0\",\"sound\" : \"default\",\"e\":0},\"data\": {\"message\" : \"" + data.body + "\" ,\"richType\" : \"richType\",\"imageUrl\" : \"" + data.imageUrl + "\"  ,\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"badge\" : \"0\",\"sound\" : \"default\",\"e\":0}}";
            }
            else
            {
                if (!string.IsNullOrEmpty(data.deviceToken))
                {
                    string stringregIds = string.Join("\",\"", data.deviceToken);
                    return "{\"registration_ids\":[\"" + stringregIds + "\"],\"content-available\":\"1\",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": {\"body\" : \"" + data.body + "\",\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0},\"data\": {\"message\" : \"" + data.body + "\"   ,\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0}}";
                }
                return "{\"condition\": " + schema + " \",\"content-available\":\"1\",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": {\"body\" : \"" + data.body + "\",\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0},\"data\": {\"message\" : \"" + data.body + "\"   ,\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0}}";
            }
        }
        public string SendNotification(NotificationData model)
        {
            if (model.accountId > 0)
            {
                return SendMainNotificationToDeviceToken(model);
            }
            return SendMainNotification(model);
        }

        public string CreateNotificationJsonByDeviceToken(NotificationData data)
        {
            List<string> tokens = new List<string>();
            var accessToken = DapperService<object>.ExecuteScalar("GetUserAccessToken", new { accountId = data.accountId }, CommandType.StoredProcedure);
            tokens.Add(accessToken.ToString());
            string stringregIds = string.Join("\",\"", accessToken);
            string date = DateTime.Now.ToString();
            if (data.pageName == "eventDetails")
            {
                int eventId = Convert.ToInt32(data.eventId);
                data.groupId = repo.iRashaka<GroupEvent>().Find(eventId).groupId.ToString();
            }
            if (data.isRich != null)
            {
                return "{\"registration_ids\":[\"" + stringregIds + "\"],\"mutable_content\" :true,\"mutable-content\" :1,\"content-available\":true,\"priority\":\"high\",\"notification\": {\"body\" : \"" + data.body + "\",\"richType\" : \"richType\",\"imageUrl\" : \"" + data.imageUrl + "\"   ,\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"badge\" : \"0\",\"sound\" : \"default\",\"e\":0},\"data\": {\"message\" : \"" + data.body + "\" ,\"richType\" : \"richType\",\"imageUrl\" : \"" + data.imageUrl + "\"  ,\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"badge\" : \"0\",\"sound\" : \"default\",\"e\":0}}";
            }
            else
            {
                return "{\"registration_ids\":[\"" + stringregIds + "\"],\"content-available\":\"1\",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": {\"body\" : \"" + data.body + "\",\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0},\"data\": {\"message\" : \"" + data.body + "\"   ,\"page\" : \"" + data.pageName + "\",\"articleId\" : \"" + data.newsId + "\",\"eventId\" : \"" + data.eventId + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"mealId\" : \"" + data.mealId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"sound\" : \"default\",\"e\":0}}";
            }
        }

        public static string CreateTopic(NotificationData data)
        {

            string schema = string.Empty;
            if (data.type == "group")
            {
                schema = GenerateTopicsString(new List<string> { "previewGroup" });
            }
            else if (data.type == "post")
            {
                schema = GenerateTopicsString(new List<string> { "New_group_" + data.groupId });
            }

            //else
            //{
            //    schema = GenerateTopicsString(data.topic);

            //    //schema = GenerateTopicsString(new List<string> { "New_group_687" });
            //}
            return schema;
        }

        //public static string SendRichNotification(NotificationData data)
        //{
        //    //string json2 = "{\"registration_ids\":[\"" + stringregIds + "\"],\"mutable_content\" :true,\"mutable-content\" :1,\"content-available\":true,\"priority\":\"high\",\"notification\": { \"body\" : \"" + message + "\",\"URL\" : \"" + url + "\",\"mediaUrl\" : \"http://api.madarsoft.com/notification/v2/images/malekah.jpg\",\"version\" : \"" + version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + title + "\",\"type\" : \"" + type + "\",\"id\" : \"" + id + "\",\"newsid\" : \"" + id + "\",\"badge\" : \"1\",\"sound\" : \"sound.caf\",\"e\":0},\"data\": {\"message\" : \"" + message + "\",\"mutable_content\" :true,\"mutable-content\" :1,\"type\" : \"" + type + "\",\"mediaUrl\" : \"http://api.madarsoft.com/notification/v2/images/malekah.jpg\",\"URL\" : \"" + url + "\",\"version\" : \"" + version + "\",\"id\" : \"" + id + "\",\"newsid\" : \"" + id + "\",\"date\" : \"" + date + "\",\"badge\" : \"1\"}}";
        //    string response = string.Empty;
        //    //string schema = GenerateTopicsString(data.topic);
        //    string date = DateTime.Now.ToString();
        //    if (data.type == "group")
        //    {
        //        GroupsNotificationModel model = new GroupsNotificationModel { Type = "previewGroup", groupId = data.groupId, Message = data.body, Topic = "group_" + data.groupId };
        //        string schema = GenerateTopicsString(new List<string> { "previewGroup" });
        //        string json = "{\"condition\": " + schema + " \",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": { \"body\" : \"" + data.body + "\",\"URL\" : \"" + data.url + "\",\"type\" : \"" + data.type + "\",\"groupId\" : \"" + data.groupId + "\",\"title\" : \"رشاقة\",\"topic\" : \"" + data.topic[0] + "\",\"content-available\":\"1\",\"badge\" : \"1\",\"sound\" : \"sound.caf\",\"e\":0},\"data\": {\"message\" : \"" + data.body + "\",\"type\" : \"" + data.type + "\",\"groupId\" : \"" + data.groupId + "\",\"title\" : \"رشاقة\",\"URL\" : \"" + data.url + "\",\"topic\" : \"" + data.topic + "\",\"badge\" : \"1\"}}";


        //        response = SendToTopic(model);
        //    }
        //    else if (data.type == "post")
        //    {
        //        string schema_test = GenerateTopicsString(new List<string> { "New_group_" + data.groupId });

        //        string json = "{\"condition\": " + schema_test + " \",\"mutable_content\" :true,\"mutable-content\" :1,\"content-available\":true,\"priority\":\"high\",\"notification\": { \"body\" : \"" + data.body + "\",\"mediaUrl\" : \"" + data.imageUrl + "\",\"postId\" : \"" + data.postId + "\",\"accountId\" : \"0\",\"type\" : \"addPost_New\",\"badge\" : \"0\",\"sound\" : \"default\"},\"data\": {\"message\" : \"" + data.body + "\",\"postId\" : \"" + data.body + "\",\"accountId\" : \"0\",\"type\" : \"addPost_New\"}}";
        //        //response = Send(json);
        //    }
        //    else if (data.type == "topUsers")
        //    {
        //        NotificationItems items = new NotificationItems { Message = data.body, Steps = data.Steps, Topic = data.topic[0], Type = data.type, Url = data.url };
        //        response = SendToTokens(items);
        //    }
        //    else
        //    {
        //        string json = "{\"condition\": " + schema + " \",\"mutable_content\" :true,\"mutable-content\" :1,\"content-available\":true,\"priority\":\"high\",\"notification\": {\"message\" : \"" + data.body + "\",\"body\" : \"'" + data.body + "'\",\"mediaUrl\" : \"" + data.imageUrl + "\",\"pageName\" : \"" + data.pageName + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"badge\" : \"1\",\"sound\" : \"default\",\"e\":0},\"data\": {\"message\" : \"" + data.body + "\",\"pageName\" : \"" + data.pageName + "\",\"type\" : \"" + data.type + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"badge\" : \"1\"}}";
        //        //response = Send(json);
        //    }
        //    return response;
        //}
        public class AccounsTokens
        {
            public IEnumerable<string> tokens { get; set; }
            public IEnumerable<int> ids { get; set; }
        }
        //public static string SendNormalNotification(NotificationData data)
        //{
        //    string response = string.Empty;
        //    string schema = GenerateTopicsString(data.topic);
        //    string date = DateTime.Now.ToString();
        //    if (data.type == "group")
        //    {
        //        GroupsNotificationModel model = new GroupsNotificationModel { Type = "previewGroup", groupId = data.groupId, Message = data.body, Topic = "group_" + data.groupId };
        //        //response = SendToTopic(model);
        //    }
        //    else if (data.type == "post")
        //    {
        //        string schema_test = GenerateTopicsString(new List<string> { "New_group_" + data.groupId });
        //        string json = "{\"condition\": " + schema_test + " \",\"content-available\":\"1\",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": { \"body\" : \"" + data.body + "\",\"postId\" : \"" + data.postId + "\",\"accountId\" : \"0\",\"type\" : \"addPost_New\",\"badge\" : \"0\",\"sound\" : \"default\"},\"data\": {\"message\" : \"" + data.body + "\",\"postId\" : \"" + data.body + "\",\"accountId\" : \"0\",\"type\" : \"addPost_New\"}}";
        //        //response = Send(json);
        //    }
        //    else if (data.type == "topUsers")
        //    {
        //        NotificationItems items = new NotificationItems { Message = data.body, Steps = data.Steps, Topic = data.topic[0], Type = data.type, Url = data.url };
        //        //response = SendToTokens(items);
        //    }
        //    else
        //    {
        //        string json = "{\"condition\": " + schema + " \",\"time_to_live\":3600,\"content_available\":\"1\",\"priority\":\"high\",\"notification\": {\"message\" : \"" + data.body + "\",\"body\" : \"'" + data.body + "'\",\"pageName\" : \"" + data.pageName + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"badge\" : \"1\",\"sound\" : \"default\",\"e\":0},\"data\": {\"message\" : \"" + data.body + "\",\"pageName\" : \"" + data.pageName + "\",\"type\" : \"" + data.type + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"badge\" : \"1\"}}";
        //        //response = Send(json);
        //    }

        //    string json = "{\"condition\": " + schema + " \",\"content_available\":\"1\",\"time_to_live\":3600,\"priority\":\"high\",\"notification\": {\"body\" : \"" + data.body + "\"   ,\"pageName\" : \"" + data.pageName + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"badge\" : \"1\",\"sound\" : \"default\",\"e\":0}"+
        //                                                                                                                                   ",\"data\": {\"message\" : \"" + data.body + "\",\"pageName\" : \"" + data.pageName + "\",\"postId\" : \"" + data.postId + "\",\"groupId\" : \"" + data.groupId + "\",\"URL\" : \"" + data.url + "\",\"version\" : \"" + data.version + "\",\"date\" : \"" + date + "\",\"title\" : \"" + data.title + "\",\"type\" : \"" + data.type + "\",\"content-available\":\"1\",\"URL\" : \"" + data.url + "\",\"badge\" : \"1\"}}";

        //    return response;
        //}

        public string GetNotifactionType(string type)
        {
            switch (type)
            {
                case "groupPostPublic": return "منشور";
                case "previewGroup": return "مجموعة";
                default: return type;
            }
        }
        public static void SendAfterAddGroupAdmins(GroupUser user)
        {
            try
            {
                List<string> tokens = new List<string>();
                Thread workerOne = new Thread(() =>
                {
                    var accessToken = DapperService<object>.ExecuteScalar("GetUserAccessToken", new { accountId = user.accountId }, CommandType.StoredProcedure);
                    tokens.Add(accessToken.ToString());

                    string message = " تم اضافتك كمسؤل فى مجموعة" + "" + user.group.name;
                    sendToDeviceToken(message, user.groupId, "previewGroup", new List<string> { accessToken.ToString() });

                });
                workerOne.Start();
            }
            catch { }

        }
    }
}