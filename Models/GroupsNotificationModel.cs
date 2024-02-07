namespace RashakaAdmin.Models
{
    public class GroupsNotificationModel
    {
        public int? accountId { get; set; }
        public int? groupId { get; set; }
        public List<string> tokens { get; set; }
        public string Topic { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }

    }
}