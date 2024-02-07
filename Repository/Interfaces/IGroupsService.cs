using RashakaGroupsAdmin.Models;
using X.PagedList;

namespace RashakaGroupsAdmin.Repository.Interfaces
{
    public interface IGroupsService
    {
        int AddGroup(GroupModel model);
        void DeleteGroup(int id);
        int EditGroup(GroupModel model);
        Group GetGroup(int id);
        GroupsDetailsModel GetGroupDetails(int v);
        IPagedList<GroupReport> GetGroupReporting(int id, int v);
        GroupSettingsModel GetGroupSettings(int id);
        GroupStepsModel GetGroupSteps(int id);
        IEnumerable<Group> GetUserGroups(int accountId, string filter);
        IEnumerable<Group> GetUserGroups(int accountId);
 
      
    }
}