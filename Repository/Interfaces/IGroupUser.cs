using X.PagedList;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RashakaGroupsAdmin.Repository.Interfaces
{
    public interface IGroupUser
    {
        string UpdateProfileImage(IFormFile image);
        //bool AddAdmin(GroupUser user);
        object GetUsersSteps(int groupId);
        object GetUsersProfile(int accountId, string accountGuid, int groupId);
        GroupMembersModel GetGroupMemebers( int groupId, string period, int page);
        Group GetGroup(int id);
       
        bool DeleteUser(int groupId, int accountId);
        bool AssignOrDeleteAdmin(GroupUser user);
        bool AddAdminList(List<GroupUser> users);
        IEnumerable<Account> GetMembers(int groupId,string key);
        IEnumerable<Account> GetGroupAdmins(int groupId);
    }
}
