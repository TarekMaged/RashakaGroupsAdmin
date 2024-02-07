using X.PagedList;
using RashakaGroupsAdmin.Requests;
using RashakaGroupsAdmin.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RashakaGroupsAdmin.Repository.Interfaces
{
    public interface IGroupSteps
    {
        IPagedList<UserWithStepsOrder> GetStepsByDate(GroupStepsByDate model);
        string GetDateFromTo(int week);
        IPagedList<UserWithStepsOrder> GetOtherGroupSteps(GroupSteps model);
      //  IEnumerable<UserStepsData> GetWeekSteps(GroupSteps model);
        //IEnumerable<UserStepsData> GetMonthSteps(GroupSteps model);
       // IEnumerable<UserStepsData> GetAllSteps(GroupSteps model);
        IEnumerable<UserStepsData> GetTodaySteps(int? groupId);
        //IEnumerable<UserStepsData> GetYesterdaySteps(GroupSteps model);
        //int? GetGroupCreatorId(int groupId);
    }
}
