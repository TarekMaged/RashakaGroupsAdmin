using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository;
using RashakaGroupsAdmin.Services;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace RashakaGroupsAdmin.Controllers
{
    [Authorize(Roles = "adminGroups")]
    public class AdminGroupsController : Controller
    {
        // GET: AdminGroups
        readonly IRashakaUniteOfWork repo;
        readonly AdminGroupsRepo adminGroupsRepo;
        int? accountId = 0;
        readonly IAdminUsers iAdminUsers;
        public AdminGroupsController(IRashakaUniteOfWork _repo, IAdminUsers _iAdminUsers)
        {
            repo = _repo;
            iAdminUsers = _iAdminUsers;
            accountId = iAdminUsers.GetLoggedUserId();
        }

        public IActionResult Index(int? page, int? accountId)
        {
            ViewBag.accountId = accountId;
            //Login admin = repo.iRashaka<Login>().GetBy(a => a.accountId==accountId);
            //int groupId = Convert.ToInt32(admin.groupId);
            var groups = repo.iRashaka<GroupUser>().GetAll(x => x.accountId == accountId && x.isAdmin == true).Select(x => x.group).OrderBy(x => x.id).ToPagedList(1, 20);
            //var groups = repo.iRashaka<Group>().GetAll(x => x.isDeleted != true &&x.id== groupId, x => x.id, page ?? 1, 30);
            return View(groups);
        }
        public IActionResult Details(int? id)
        {
            try
            {

                var details = adminGroupsRepo.GetGroupDetails(id);
                return View(details);
            }
            catch
            {
                return View();
            }
        }



        //[Route("adminGroups/Posts/{id}/{page}")]


        public IActionResult Events(int? page, int? groupId)
        {
            try
            {
                var group = repo.iRashaka<Group>().GetBy(x => x.id == groupId /*&& x.creatorId == accountId*/);
                if (group == null) return View();

                IPagedList<GroupEvent> events = repo.iRashaka<GroupEvent>().GetAll(x => x.groupId == groupId, x => x.dateFrom, page ?? 1, 30);
                ViewBag.groupId = groupId;
                return View(events);
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult AddEvent(int id)
        {
            ViewBag.groups = new SelectList(repo.iRashaka<Group>().GetAll(x => x.id == id), "id", "name", id);

            //ViewBag.groups = new SelectList(repo.iRashaka<Group>().GetAll(x => x.id == 4 || x.id == 868), "id", "name", 4);
            ViewBag.groupId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(GroupEvent _event, IFormFile image)
        {
            try
            {
                _event.date = DateTime.Now;
                _event.adminId = accountId;
                _event.shareCount = 0;
                if (image == null)
                {
                    _event.image = "defaultEventImg1.jpg";
                }
                string jsonData = JsonConvert.SerializeObject(_event);
                int postId = await GroupsService.AddEditGroupEvent("http://api.rashaqa.net/api/GroupEvents/AddEvent", jsonData, image);
                if (postId <= 0)
                {
                    ViewBag.message = "error";
                    return View();
                }
                return RedirectToAction("events");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult GroupReports(int? id, int? page)
        {
            try
            {
                IPagedList<GroupReport> groupReports = null;
                if (id == null)
                {
                    int? accountId = iAdminUsers.GetLoggedUserId();
                    groupReports = repo.iRashaka<GroupReport>().GetAll(x => x.group.creatorId == accountId, x => x.date, page ?? 1, 40);
                }
                else
                {
                    groupReports = repo.iRashaka<GroupReport>().GetAll(x => x.groupId == id, x => x.date, page ?? 1, 40);
                }


                ViewBag.groupName = groupReports.Select(x => x.group.name).FirstOrDefault();
                return View(groupReports);
            }
            catch (Exception)
            {
                return View();
            }

        }
        public IActionResult AllowDisAllow(int id, bool allow)
        {
            try
            {
                var groupEvent = repo.iRashaka<GroupEvent>().Find(id);
                groupEvent.isAllowed = allow;
                repo.Save();
                return Json(true/**/);
            }
            catch (Exception)
            {
                return Json(false);
            }

        }


    }
}