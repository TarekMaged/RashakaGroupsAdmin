using X.PagedList;
using RashakaGroupsAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using X.PagedList;

namespace RashakaGroupsAdmin.Repository.Interfaces
{
    public interface Igroups
    {
        void ReadNotification(int id);
        IEnumerable<Group> GetUserGroups(int accountId);
        IEnumerable<Group> GetUserGroups(int accountId, string filter);
        GroupStepsModel GetGroupSteps(int id);
        GroupSettingsModel GetGroupSettings(int id);
        GroupsDetailsModel GetGroupDetails(int id);
        bool ShareWeekUserAsPost(string user,string steps, int groupId);
        int AddGroup(GroupModel model);
        int EditGroup(GroupModel model);
        void DeleteGroup(int groupId);
        Group GetGroup(int id);
        string GetGroupName(int groupId);
        IPagedList<GroupReport> GetGroupReporting(int id,int page);
    }
}
