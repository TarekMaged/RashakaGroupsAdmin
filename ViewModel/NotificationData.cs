using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaAdmin.Models
{
    public class NotificationData
    {
        
             public int? accountId { get; set; }
        public int platformId { get; set; }
        public string groupId { get; set; }
        public string newsId { get; set; }
        public string mealId { get; set; }
        
        public string eventId { get; set; }
        public string postId { get; set; }
        public string guid { get; set; }
        public string version { get; set; }
        public string type { get; set; }
        public List<string> topic { get; set; }
        public string body { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string deviceToken { get; set; }
        public string pageName { get; set; }
        public int? Steps { get; set; }
        public string isRich { get; set; }
        public string imageUrl { get; set; }
        public DateTime scheduleDate { get; set; }
        public string sendNow { get; set; }
        public int hangfireId { get; set; }
    }
}