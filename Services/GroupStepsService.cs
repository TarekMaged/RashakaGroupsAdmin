
using X.PagedList;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using RashakaGroupsAdmin.Requests;
using RashakaGroupsAdmin.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RashakaGroupsAdmin.Services
{
    public class GroupStepsService : IGroupSteps
    {
        readonly IRashakaUniteOfWork repo;
        public string from = "";
        public string to = "";
        public GroupStepsService()
        {
            //groupsStepsService = new GroupsStepsService();
            repo = repo ?? new RashakaUniteOfWork();
        }
        public virtual IEnumerable<UserStepsData> GetAllSteps(GroupSteps model)
        {
            return DapperService<UserStepsData>.Query("select groupid,lastUploadDate,id=accountId,name,email,image,stepsCount=allStepsCount  from[VW_GroupUsers]WITH(NOEXPAND) where groupId = " + model.groupId + " and[requestStatus] = 'accepted'");

            //return DapperService<UserStepsData>.GetData("GetStepsInGroupIn_All", new { model.groupId });
        }

        public virtual IEnumerable<UserStepsData> GetMonthSteps(GroupSteps model)
        {
            //return DapperService<UserStepsData>.GetData("SELECT gu.accountId,ac.name,ac.gender, ac.iso,ac.city,ac.image,gu.isAdmin,gu.currentDayStepsCount,gu.yesterdayStepsCount,gu.weekStepsCount,gu.monthStepsCount,gu.allStepsCount, gu.[lastUploadDate],gu.currentDayDate,gu.yesterdayDate FROM  dbo.Accounts AS ac INNER JOIN dbo.GroupUsers AS gu ON ac.id = gu.accountId where groupId=" + model.groupId + " and[requestStatus]='accepted'");
            return DapperService<UserStepsData>.Query("select groupid,lastUploadDate,id,accountId,name,email,image,stepsCount=monthStepsCount  from[VW_GroupUsers]WITH(NOEXPAND) where groupId = " + model.groupId + " and[requestStatus] = 'accepted'");

            //return DapperService<UserStepsData>.GetData("GetStepsInGroupIn_Month", new { model.groupId });
        }

        public virtual IEnumerable<UserStepsData> GetWeekSteps(GroupSteps model)
        {
            return DapperService<UserStepsData>.Query("select groupid,lastUploadDate,id,accountId,name,email,image,stepsCount=weekStepsCount  from[VW_GroupUsers]WITH(NOEXPAND) where groupId = "+model.groupId+" and[requestStatus] = 'accepted'");
            //return DapperService<UserStepsData>.GetData("GetStepsInGroupIn_Week", new { model.groupId });

        }
        public IEnumerable<UserStepsData> GetTodaySteps(int? groupId)
        {
            //return DapperService<UserStepsData>.GetData("select * from [VW_GroupTodaySteps] WITH(NOEXPAND) where groupid=" + groupId);
            return DapperService<UserStepsData>.Query("select id,accountId,groupid,name,email,[image],stepsCount=currentDayStepsCount ,lastUploadDate=[currentDayDate]   from [VW_GroupUsers] WITH(NOEXPAND) where groupid=" + groupId);

        }
       
        public int? GetGroupCreatorId(int groupId)
        {
            var group = repo.iRashaka<Group>().Find(groupId);
            return group == null ? 0 : group.creatorId;
        }
        public IPagedList<UserWithStepsOrder> GetOtherGroupSteps(GroupSteps model)
        {
            switch (model.period.Trim().ToLower())
            {
                case "today": return GetTodayStepsObject(model);
                case "week": return GetWeekStepsObject(model);
                case "month": return GetMonthStepsObject(model);
                case "yesterday": return GetYesterdaySteps(model);
                default:
                    return GetAllStepsObject(model);
            }
        }
        public IPagedList<UserWithStepsOrder> GetWeekStepsObject(GroupSteps model)
        {
            //IEnumerable<UserStepsData> usersStepsData = _IGroupSteps.GetWeekSteps(model);

            IEnumerable<UserStepsData> usersStepsData;

            usersStepsData = GetWeekSteps(model);


            IEnumerable<UserWithStepsOrder> allGroupUsers = GetOtherGroupsUsersSteps(model, usersStepsData);
            return allGroupUsers.ToPagedList(model.page ?? 1, 50);


        }
       
        public string GetDateFromTo(int week)
        {
            switch (week)
            {
                case 1:
                    return "2022-05-15" + " إلى " + "2022-05-21";
                case 2:
                    return "2022-05-22" + " إلى " + "2022-05-28";
                case 3:
                    return "2022-05-29" + " إلى " + "2022-06-04";
                case 4:
                    return "2022-06-05" + " إلى " + "2022-06-11";
                case 5:
                    return "2022-06-12" + " إلى " + "2022-06-18";
                case 6:
                    return "2022-06-19" + " إلى " + "2022-06-25";
                default:
                    return "";
            }
        }
        public void GetDate(int week)
        {
            switch (week)
            {
                case 1:
                    from = "2022-05-15";
                    to = "2022-05-21";
                    break;
                case 2:
                    from = "2022-05-22";
                    to = "2022-05-28";
                    break;
                case 3:
                    from = "2022-05-29";
                    to = "2022-06-4";
                    break;
                case 4:
                    from = "2022-06-5";
                    to = "2022-06-11";
                    break;
                case 5:
                    from = "2022-06-12";
                    to = "2022-06-18";
                    break;
                case 6:
                    from = "2022-06-19";
                    to = "2022-06-25";
                    break;
                default:
                    break;
            }
        }
        public IPagedList<UserWithStepsOrder> GetStepsByDate(GroupStepsByDate model)
        {
            GetDate(model.week ?? 1);
            //IEnumerable<UserStepsData> usersStepsData = _IGroupSteps.GetWeekSteps(model);
            if (model.page == 1)
            {
                DapperService<object>.ExecuteScalar("DeleteDuplicateStepsByGroup", new { groupId = 8639 }, CommandType.StoredProcedure);
            }
            IEnumerable<UserStepsData> usersStepsData;
            usersStepsData = DapperService<UserStepsData>.Query("select gu.accountId,ac.name,ac.email ,sum(s.[count]) as stepsCount from " +
"GroupUsers gu join steps s on gu.accountId = s.accountId join accounts ac on ac.id = gu.accountId where gu.groupId = 8639 and s.typeId < 3 and s.date >= '" + from + "' and s.date <= '" + to + "'  " +
"group by gu.accountId, ac.name, email order by sum(s.[count]) desc");

            IEnumerable<UserWithStepsOrder> allGroupUsers = usersStepsData.OrderByDescending(x => x.stepsCount).ToList().Select((item, i) => new UserWithStepsOrder { UserStepsData = item, userOrder = i + 1 }).OrderBy(x => x.userOrder);

            return allGroupUsers.ToPagedList(model.page ?? 1, 50);


        }
        public IPagedList<UserWithStepsOrder> GetMonthStepsObject(GroupSteps model)
        {
            IEnumerable<UserStepsData> usersStepsData;

            usersStepsData = GetMonthSteps(model);

            IEnumerable<UserWithStepsOrder> allGroupUsers = GetOtherGroupsUsersSteps(model, usersStepsData);
            return allGroupUsers.ToPagedList(model.page ?? 1, 50);

        }
        public IPagedList<UserWithStepsOrder> GetTodayStepsObject(GroupSteps model)
        {
            IEnumerable<UserStepsData> usersStepsData = GetTodaySteps(model.groupId);
            var allGroupUsers = GetTodayGroupsUsersData(model, usersStepsData);
            return allGroupUsers.ToPagedList(model.page ?? 1, 100);

        }
        public IPagedList<UserWithStepsOrder> GetAllStepsObject(GroupSteps model)
        {
            IEnumerable<UserStepsData> usersStepsData;

            usersStepsData = GetAllSteps(model);

            IEnumerable<UserWithStepsOrder> allGroupUsers = GetOtherGroupsUsersSteps(model, usersStepsData);
            return allGroupUsers.ToPagedList(model.page ?? 1, 50);

        }
        public IPagedList<UserWithStepsOrder> GetYesterdaySteps(GroupSteps model)
        {
            IEnumerable<UserStepsData> allUsers = GetYesterdayStepsList(model);
            DateTime yesterDayDate = model.todayDate == null ? DateTime.Now.AddDays(-1) : model.todayDate.Value.Date.AddDays(-1);
            IEnumerable<UserStepsData> usersHavingSteps = allUsers.Where(x => x.yesterdayDate.Date == yesterDayDate.Date).ToList();

            List<UserStepsData> usersNotHavingSteps = allUsers.Where(x => x.yesterdayDate == null || x.yesterdayDate.Date < yesterDayDate.Date || x.yesterdayDate.Date > yesterDayDate.Date).ToList();

            usersNotHavingSteps.ForEach(x => { x.stepsCount = 0; });
            usersNotHavingSteps.AddRange(usersHavingSteps);

            //IEnumerable<UserWithStepsOrder> allGroupUsers = GetOtherGroupsYesterdayUsersSteps(model, usersNotHavingSteps);

            IEnumerable<UserWithStepsOrder> allGroupUsers = usersNotHavingSteps.OrderByDescending(x => x.stepsCount).ToList().Select((item, i) => new UserWithStepsOrder { UserStepsData = item, userOrder = i + 1 }).OrderBy(x => x.userOrder);
            return allGroupUsers.ToPagedList(model.page ?? 1, 50);

            //IEnumerable<UserWithStepsOrder> allGroupUsers = usersNotHavingSteps.OrderByDescending(x => x.stepsCount).ToList().Select((item, i) => new UsersOrderForYesterday { account = item, userOrder = i + 1 }).OrderBy(x => x.userOrder);
            //return GroupYesterdaySteps.CreateYesterdaystepsObject(model, allGroupUsers);
            ////IEnumerable<UserStepsData> allGroupUsers = usersNotHavingSteps.OrderByDescending(x => x.stepsCount).ToList().Select((item, i) => new UserStepsData { UserStepsData = item, userOrder = i + 1 }).OrderBy(x => x.userOrder);
            //return allGroupUsers.ToPagedList(model.page ?? 1, 50);
        }
        public IEnumerable<UserStepsData> GetYesterdayStepsList(GroupSteps model)
        {
            return DapperService<UserStepsData>.Query("select id,accountId,groupid,name,email,[image],stepsCount=yesterdayStepsCount,[yesterdayDate],[lastUploadDate] from [VW_GroupUsers] WITH(NOEXPAND) where groupid=" + model.groupId);
        }
        #region Week
        public IEnumerable<UserWithStepsOrder> GetOtherGroupsUsersSteps(GroupSteps model, IEnumerable<UserStepsData> usersStepsData)
        {
            DateTime todayDate = model.todayDate ?? DateTime.Now.Date;
            DateTime? dateTo = GetDateTo(model);
            if (model.period != "all")
            {
                IEnumerable<UserStepsData> usersHavingSteps = usersStepsData.Where(x => x.lastUploadDate >= dateTo.Value.Date && x.lastUploadDate <= todayDate.Date);
                List<UserStepsData> usersNotHavingSteps = usersStepsData.Where(x => x.lastUploadDate == null || x.lastUploadDate < dateTo.Value.Date).ToList();
                usersNotHavingSteps.ForEach(x => { x.stepsCount = 0; });
                usersNotHavingSteps.AddRange(usersHavingSteps);
                return usersNotHavingSteps.OrderByDescending(x => x.stepsCount).ToList().Select((item, i) => new UserWithStepsOrder { UserStepsData = item, userOrder = i + 1 }).OrderBy(x => x.userOrder);
            }
            return usersStepsData.OrderByDescending(x => x.stepsCount).ToList().Select((item, i) => new UserWithStepsOrder { UserStepsData = item, userOrder = i + 1 }).OrderBy(x => x.userOrder);
        }
        public IEnumerable<UserWithStepsOrder> GetTodayGroupsUsersData(GroupSteps model, IEnumerable<UserStepsData> usersStepsData)
        {
            //var usersStepsData = DapperService<UserStepsData>.GetData("select * from VW_GroupTodaySteps WITH (NOEXPAND) where groupid=" + model.groupId);
            if (model.period != "all")
            {
                DateTime? dateTo = GetDateTo(model);
                DateTime todayDate = model.todayDate ?? DateTime.Now.Date;
                IEnumerable<UserStepsData> usersHavingSteps = usersStepsData.Where(x => x.lastUploadDate >= dateTo.Value.Date && x.lastUploadDate <= todayDate.Date);
                List<UserStepsData> usersNotHavingSteps = usersStepsData.Where(x => x.lastUploadDate == null || x.lastUploadDate < dateTo.Value.Date).ToList();
                usersNotHavingSteps.ForEach(x => { x.stepsCount = 0; });
                usersNotHavingSteps.AddRange(usersHavingSteps);
                return usersNotHavingSteps.OrderByDescending(x => x.stepsCount).ToList().Select((item, i) => new UserWithStepsOrder { UserStepsData = item, userOrder = i + 1 }).OrderBy(x => x.userOrder);
            }
            return usersStepsData.OrderByDescending(x => x.stepsCount).ToList().Select((item, i) => new UserWithStepsOrder { UserStepsData = item, userOrder = i + 1 }).OrderBy(x => x.userOrder);
        }
        public DateTime? GetDateTo(GroupSteps model)
        {
            DateTime todayDate = model.todayDate ?? DateTime.Now.Date;
            DateTime? dateTo = todayDate;
            switch (model.period.ToLower().Trim())
            {
                case "today":
                    dateTo = todayDate; break;
                case "yesterday":
                    dateTo = todayDate.Date.AddDays(-1); break;
                case "week":
                    dateTo = todayDate.Date.AddDays(-7); break;
                case "month":
                    dateTo = todayDate.Date.AddDays(-30); break;
            }
            return dateTo;
        }

        #endregion




    }
}