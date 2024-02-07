using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.ViewModel
{
    public class SeviceNotificationHistoryModel
    {
        public int id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> serviceId { get; set; }
        public string message { get; set; }
        public Nullable<int> days { get; set; }
        public string screenName { get; set; }
        public string sendNow { get; set; }
        public DateTime scheduleDate { get; set; }
    }
}