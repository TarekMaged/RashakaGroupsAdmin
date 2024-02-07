using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.Requests
{
    public class GroupSteps
    {
        public int accountId { get; set; }
        public int groupId { get; set; }
        public int? yesterdayStepsCount { get; set; }
        public bool? isYesterdayStepsRegisterd { get; set; }
        public string period { get; set; }
        public int? page { get; set; }
        public DateTime? todayDate { get; set; }
    }
    public class GroupStepsByDate
    {
        public int accountId { get; set; }
        public int groupId { get; set; }
        public int? week { get; set; }
        public int? yesterdayStepsCount { get; set; }
        public bool? isYesterdayStepsRegisterd { get; set; }
        public string period { get; set; }
        public int? page { get; set; }
        public DateTime? to { get; set; }
        public DateTime? from { get; set; }
    }
}