using RashakaGroupsAdmin.Requests;
using RashakaGroupsAdmin.Services;

namespace RashakaGroupsAdmin.Responses
{
    public class GroupYesterdaySteps
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public double stepsCount { get; set; }
        public DateTime yesterdayDate { get; set; }
        //public static object CreateYesterdaystepsObject( GroupSteps model, IEnumerable<UserWithStepsOrder> allGroupUsers)
        //{
        //    var id = DapperService<object>.ExecuteScalar("select creatorId from Groups where id=" + model.groupId);
        //    int? creatorId = Convert.ToInt32(id ?? 0);
        //    var groupUsers = allGroupUsers.ToPagedList(model.page ?? 1, 50);
        //    UsersOrderForYesterday currentUser = allGroupUsers.FirstOrDefault(x => x.account.id == model.accountId);
        //    int currentUserOrder = currentUser != null ? currentUser.userOrder : allGroupUsers.Count() > 0 ? allGroupUsers.LastOrDefault().userOrder + 1 : 0;

        //    return new
        //    {
        //         creatorId,
        //        pageCount = groupUsers.PageCount,
        //        userBefore = currentUser != null ? GetUserBeforeObject(allGroupUsers, currentUserOrder) : null,
        //        user = currentUser != null ? GetUserObject(currentUser) : null,
        //        userAfter = currentUser != null ? GetUserAfterObject(allGroupUsers, currentUserOrder) : null,
        //        allUsers = groupUsers.Select(x => new
        //        {
        //            x.account.id,
        //            x.account.name,
        //            image = ImagesSevice.GetProfileImageUrl(x.account.image),
        //            x.userOrder,
        //            x.account.stepsCount
        //        }),
        //        Status = "Success"
        //    };
        //}
        public static object GetUserBeforeObject(IEnumerable<UsersOrderForYesterday> groupUsers, int userOrder)
        {
            return groupUsers.Where(x => x.userOrder == userOrder - 1).Select(x =>
             new
             {
                 x.account.id,
                 x.account.name,
                 image = ImagesSevice.GetProfileImageUrl(x.account.image),
                 x.userOrder,
                  x.account.stepsCount
             }).FirstOrDefault();
        }
        public static object GetUserObject(UsersOrderForYesterday currentUser)
        {
            return new
            {
                currentUser.account.id,
                currentUser.account.name,
                image = ImagesSevice.GetProfileImageUrl(currentUser.account.image),
                currentUser.userOrder,
                 currentUser.account.stepsCount
            };
        }
        public static object GetUserAfterObject(IEnumerable<UsersOrderForYesterday> groupUsers, int userOrder)
        {
            return groupUsers.Where(x => x.userOrder == userOrder + 1).Select(x =>
             new
             {
                 x.account.id,
                 x.account.name,
                 image = ImagesSevice.GetProfileImageUrl(x.account.image),
                 x.userOrder,
                  x.account.stepsCount
             }).FirstOrDefault();
        }
    }
}