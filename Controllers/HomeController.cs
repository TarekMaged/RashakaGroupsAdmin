using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RashakaAdmin.Models;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using RashakaGroupsAdmin.Services;
using System.Collections;
using System.Data;


namespace RashakaGroupsAdmin.Controllers
{
    [Authorize(Roles = "adminGroups")]
    public class HomeController : Controller
    {
        readonly IGroupsService groupService;
        readonly IRashakaUniteOfWork repo;
        readonly IAdminUsers iAdminUsers;
        int accountId;
         IEnumerable<Group> groups;
        public HomeController(IRashakaUniteOfWork _repo, IGroupsService _igroupService, IAdminUsers _iAdminUsers)
        {
            repo = _repo;
            iAdminUsers = _iAdminUsers;
            groupService = _igroupService;
            accountId = iAdminUsers.GetLoggedUserId();
        }
        public IActionResult Index()
        {
             groups = groupService.GetUserGroups(accountId);
            return View(groups);
        }
        public IActionResult FilteredGroups(string filter)
        {
            int accountId = iAdminUsers.GetLoggedUserId();
            groups = groupService.GetUserGroups(accountId, filter);
            return PartialView("_FilteredGroups", groups);
        }
        public IActionResult MenuGroups()
        {
            if (groups != null)
            {
                return PartialView(groups);
            }
            //groups = repo.iRashaka<GroupUser>().GetAll(X => x.accountId == accountId && X.isAdmin == true).Select(x => x.Group).ToList();
            groups = groupService.GetUserGroups(accountId);
            return PartialView("MenuGroups", groups.ToList());
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public IActionResult Notification(int accountId)
        {
            var msg = DapperService<UserGroupsNotificationModel>.Query("GetUserNotificationsForGroupsAdmin",
                                                       new { accountId, PageNumber = 1, RowsOfPage = 30 }, CommandType.StoredProcedure);
            msg.ToList().ForEach(x => x.image = ImagesSevice.GetProfileImageUrl(x.image));
            return Json(msg.Select(x => new
            {
                x.id,
                date = x.date.ToString("HH:mm tt").Replace("AM", "صباحا").Replace("PM", "مساء"),
                x.Message,
                x.image,
                x.type,
                x.postId,
                x.groupId,
                count = x.TempCount,
                x.isRead
            }).ToList()/**/);
        }
        public IActionResult NotificationCount(int accountId)
        {
            var count = DapperService<string>.ExecuteScalar("SELECT 	count(*)  FROM [GroupUserNotifications] gun join [dbo].[Accounts] ac on gun.from_accountId=ac.id	 and gun.groupId in (select groupid from groupusers where accountId=" + accountId + " and isAdmin=1) WHERE   to_accountId =" + accountId + "");


            return Json(count/**/);
        }
    }
}