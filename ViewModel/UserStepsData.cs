using RashakaGroupsAdmin.Responses;
using System;

namespace RashakaGroupsAdmin.Requests
{
    public class UserStepsData
    {
        public int accountId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string iso { get; set; }
        public int? stepsCount { get; set; }
        //public DateTime monthStepsDate { get; set; }
        //public DateTime weekStepsDate { get; set; }
        public DateTime lastUploadDate { get; set; }

        
        public DateTime yesterdayDate { get; set; }
    }
    public class UserStepsDataSheet
    {
        public int id { get; set; }
        public int typeId { get; set; }
        public string name { get; set; }
        public string groupName { get; set; }
        public string groupImage { get; set; }
        public string image { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string privacy { get; set; }
        public string city { get; set; }
        public string iso { get; set; }
        public double stepsCount { get; set; }
        public double distance { get; set; }
        //public DateTime monthStepsDate { get; set; }
        //public DateTime weekStepsDate { get; set; }
        public DateTime date { get; set; }
        //public DateTime yesterdayDate { get; set; }
    }
    public class UserWithStepsOrderSheet
    {
        public UserStepsDataSheet UserStepsData { get; set; }
        public int userOrder { get; set; }
    }
    public class UserWithStepsOrder
    {
        public UserStepsData UserStepsData { get; set; }
        public int userOrder { get; set; }
    }

    public class UsersOrderForYesterday
    {
        public GroupYesterdaySteps account { get; set; }
        public int userOrder { get; set; }
    }
}