using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Requests;
using RashakaGroupsAdmin.ViewModel;

namespace RashakaGroupsAdmin.Controllers
{
    [Authorize(Roles = "adminGroups")]
    public class GroupUsersController : Controller
    {
        readonly IRashakaUniteOfWork repo;
        readonly IGroupUser iGroupUser;
        readonly IGroupSteps groupSteps;
        public GroupUsersController(IRashakaUniteOfWork _repo, IGroupUser _iGroupUser, IGroupSteps _groupSteps)
        {
            repo = _repo;
            iGroupUser = _iGroupUser;
            groupSteps = _groupSteps;
        }

        public IActionResult UserProfile(int? accountId, string accountGuid, int groupId, int? page)
        {
            var userProfile = iGroupUser.GetUsersProfile(accountId ?? 0, accountGuid, groupId);
            return View(userProfile);
        }


        public IActionResult Members(int groupId, string period, int? page)
        {

            GroupMembersModel members = iGroupUser.GetGroupMemebers(groupId, period, page ?? 1);
           
            return View(members);
        }
        public IActionResult MembersJson(int groupId, string key = "")
        {
            var members = iGroupUser.GetMembers(groupId, key).Select(x => new { x.id, x.name }).ToList();
            return Json(members);
        }
        [HttpPost]
        public IActionResult DeleteUser(int groupId, int accountId)
        {
            var result = iGroupUser.DeleteUser(groupId, accountId);
            return Json(result);
        }

        [HttpPost]
        public IActionResult AssignOrDeleteAdmin(GroupUser user)
        {
            bool result = iGroupUser.AssignOrDeleteAdmin(user);
            return Json(result);
        }

        [HttpPost]
        public IActionResult AddAdminList(List<GroupUser> users)
        {
            var result = iGroupUser.AddAdminList(users);
            return Json(result);
        }




        // GET: GroupUsers

        //public IActionResult Index(int? id, int? page, string name)
        //{
        //    try
        //    {
        //        if (id != AdminUsers.GetLoggedGroupId())
        //        {
        //            return View();
        //        }
        //        int? accountId = AdminUsers.GetLoggedUserId();
        //        var group = repo.iRashaka<Group>().GetBy(x => x.id == id /*&& x.creatorId == accountId*/);

        //        IPagedList<GroupUser> groupUsers;
        //        if (!string.IsNullOrEmpty(name))
        //        {
        //            groupUsers = repo.iRashaka<GroupUser>().GetAll(x => x.groupId == id && x.account.name.Contains(name), x => x.id, page ?? 1, 30);
        //        }
        //        else
        //        {
        //            groupUsers = repo.iRashaka<GroupUser>().GetAll(x => x.groupId == id, x => x.id, page ?? 1, 30);
        //        }

        //        return View(groupUsers);
        //    }
        //    catch (Exception)
        //    {
        //        return View();
        //    }

        //}
        public IActionResult Search(int? id, int? page, string name)
        {
            ViewBag.name = name;
            var accounts = repo.iRashaka<GroupUser>().GetAll(x => x.groupId == id && x.account.name.Contains(name), x => x.id, page ?? 1, 30);
            return PartialView("_users", accounts);
        }

        //[HttpPost]
        //public IActionResult AcceptBlockUser(int accountId, int groupId, string requestStatus)
        //{
        //    try
        //    {
        //        var groupName = DapperService<object>.ExecuteScalar("AcceptBlockGroupUserByRashakaAdmin", new
        //        {
        //            accountId = accountId,
        //            groupId = groupId,
        //            requestStatus = requestStatus
        //        });
        //        if (groupName != null)
        //        {
        //            GroupUserModel model = new GroupUserModel { accountId = accountId, groupId = groupId, isAccepted = requestStatus == "accepted" ? true : false };
        //            NotificationCenter.SendAcceptBlockNotification(model, groupName.ToString(), repo);
        //            bool result = !string.IsNullOrEmpty(groupName.ToString()) ? true : false;
        //            return Json(result);
        //        }
        //        return Json(false);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(false);
        //    }
        //}
        //[HttpPost]
        //public IActionResult AddOrRemoveAdmin(GroupUser user)
        //{
        //    try
        //    {
        //        return Json(iGroupUser.AddAdmin(user));
        //    }
        //    catch (Exception)
        //    {
        //        return Json(false);
        //    }
        //}

        public IActionResult GetSteps(int id, int? page, string period)
        {
            try
            {
                ViewBag.groupId = id;
                ViewBag.period = period;
                GroupSteps model = new()
                {
                    groupId = id,
                    accountId = 220,
                    page = page ?? 1,
                    period = period,
                    todayDate = DateTime.Now
                };
                var res = groupSteps.GetOtherGroupSteps(model);
                var dada = res;
                return View(res);
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult GetStepsByDate(int? page, int id, int? week)
        {
            try
            {
                ;
                ViewBag.groupId = id;
                ViewBag.period = week + " ---" + groupSteps.GetDateFromTo(week ?? 1);
                GroupStepsByDate model = new()
                {
                    groupId = id,
                    accountId = 220,
                    page = page ?? 1,
                    week = week ?? 1
                };

                var res = groupSteps.GetStepsByDate(model);
                var dada = res;
                return View(res);
            }
            catch (Exception)
            {
                return View();
            }
        }

    }
}