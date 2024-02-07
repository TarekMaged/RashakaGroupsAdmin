namespace RashakaAdmin.Models
{
    public class UserGroupsNotificationModel
    {
        public string id { get; set; }
        public string groupId { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public int? Steps { get; set; }
        public string Type { get; set; }
        public DateTime date { get; set; }
        public bool isRead { get; set; }
        public string image { get; set; }
        public int postId { get; set; }
        public string type { get; set; }
        public int TempCount { get; set; }

    }
    public class NotificationItems
    {
       
        public string Topic { get; set; }
        public string  groupId { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public int? Steps { get; set; }
        public string Type { get; set; }

    }
    public class ReplyNotificationData
    {

        public string guid { get; set; }
        public string replyGuid { get; set; }
        public string actionAccountGuid { get; set; }
        public string postOwnerAccountGuid { get; set; }
        public string commentOwnerAccountGuid { get; set; }
        public string commentArtGuid { get; set; }
        public string commentGuid { get; set; }
        public string type { get; set; }
        public List<string> deviceToken { get; set; }
        public List<string> topics { get; set; }
        public string commentOwnerMessage { get; set; }
        public string postOwnerMessage { get; set; }
        public string replyTopicMessage { get; set; }
        public string programName { get; set; }
        public string APIkey { get; set; }
        public string userName { get; set; }
        public string image { get; set; }
        public string replyTopic { get; set; }
        public string commentTopic { get; set; }

        public string replyType { get; set; }
        public int programId { get; set; }
        public string programArtId { get; set; }

    }
    public class ReplyJson
    {
        public string postGuid { get; set; }
        public string commentArtGuid { get; set; }
        public string commentGuid { get; set; }
        public string commentOwnerAccountGuid { get; set; }
        public string accountGuid { get; set; }
        public string text { get; set; }
        public string image { get; set; }

    }
}