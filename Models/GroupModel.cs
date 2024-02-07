namespace RashakaGroupsAdmin.Models
{
    public class GroupModel
    {
        public int id { get; set; }
        public List<int> adminId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string iso { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public Nullable<int> creatorId { get; set; }
        public Nullable<int> typeId { get; set; }
        public string sponsor { get; set; }
        public int privacyId { get; set; }
        public string privacy { get; set; }
        public string type { get; set; }
        public IFormFile image { get; set; }
        public IFormFile coverImage { get; set; }
    }
    public class PostModel
    {
        public int id { get; set; }
        public int accountId { get; set; }
        public int groupId { get; set; }
        public string description { get; set; }
        
        public IFormFile image { get; set; }
        public IFormFile image2 { get; set; }
        public IFormFile image3 { get; set; }
    }
    public class GroupsDetailsModel
    {
        public Group group { get; set; }
        public long? allSteps { get; set; }
        public double? averageWeekSteps { get; set; }
        public double? totalWeekSteps { get; set; }
        public double? averageWeekDistance { get; set; }
        public double? totalWeekDistance { get; set; }
        public long? allDistance { get; set; }
        public IEnumerable<Account> TopFiveAccounts { get; set; }
        public Account TopWeekAccount { get; set; }      

    }
    public class GroupSettingsModel
    {
        public Group Group { get; set; }       
        public IEnumerable<Account> GroupAdmins { get; set; }
    }
    public class GroupStepsModel
    {
        public IEnumerable<StepModel> dailySteps { get; set; }
        public IEnumerable<StepModel> monthSteps { get; set; }
        public IEnumerable<StepModel> yearSteps { get; set; }

        public IEnumerable<StepModel> dailyDistance { get; set; }
        public IEnumerable<StepModel> monthDistance { get; set; }
        public IEnumerable<StepModel> yearDistance { get; set; }
        //public IEnumerable<StepModel> dailySteps { get; set; }
        //public IEnumerable<StepModel> monthSteps { get; set; }
        //public IEnumerable<StepModel> yearSteps { get; set; }

        //public IEnumerable<StepModel> dailyDistance { get; set; }
        //public IEnumerable<StepModel> monthDistance { get; set; }
        //public IEnumerable<StepModel> yearDistance { get; set; }
    }
    public partial class StepModel
    {
        public int id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public double steps { get; set; } = 0;
        public Nullable<Int64> count { get; set; } = 0;
        public Nullable<Int64> duration { get; set; } = 0;
        public Nullable<int> typeId { get; set; }
        public double distance { get; set; } = 0;
        public Nullable<Int64> calories { get; set; } = 0;
        public Nullable<int> accountId { get; set; }
        public Nullable<System.DateTime> datetime { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public virtual Account Account { get; set; }
    }
    public class UserProfileModel
    {
        public Account  Account { get; set; }
        public GroupUser GroupUser { get; set; }
        public IEnumerable<GroupPost> UserPosts { get; set; }
        public int GroupId { get; set; }
        public int CretatorId { get; set; }
        public string GroupName { get; set; }
    }

}