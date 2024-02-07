using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using X.PagedList;

namespace RashakaGroupsAdmin.Controllers
{
    [Authorize(Roles = "adminGroups")]
    public class GroupEventsController : Controller
    {
        readonly IRashakaUniteOfWork repo;
        public GroupEventsController(IRashakaUniteOfWork _repo)
        {
            repo = _repo;
        }
        // GET: GroupEvents
        public IActionResult Events(int? page,int? groupId)
        {
            try
            {
                IPagedList<GroupEvent> events;
                if (groupId>0)
                {
                     events = repo.iRashaka<GroupEvent>().GetAll(x => x.groupId==groupId, x => x.dateFrom, page ?? 1, 30);
                }
                else
                {
                 events = repo.iRashaka<GroupEvent>().GetAll(x => x.dateFrom != null, x => x.dateFrom, page ?? 1, 30);
                }
                ViewBag.groupId = groupId;
                return View(events);
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Details(int? id)
        {
            try
            {
                var details = repo.iRashaka<GroupEvent>().Find(id);
                return View(details);
            }
            catch (Exception)
            {
                return View();
            }
        }



        public IActionResult Index(int? id, int? page)
        {
            try
            {
                Group group = repo.iRashaka<Group>().Find(id);
                ViewBag.groupName = group.name;
                ViewBag.groupId = id;
                var groupEvents = repo.iRashaka<GroupEvent>().GetAll(x => x.groupId == id, x => x.id, page ?? 1, 30);
                return View(groupEvents);
            }
            catch (Exception)
            {
                return View();
            }
        }
          [HttpPost]
        public IActionResult DisAllow(int id)
        {
            bool res = false;
            try
            {
                var groupEvent = repo.iRashaka<GroupEvent>().Find(id);
                groupEvent.isAllowed = false;
                repo.Save();
                res = true;
            }
            catch (Exception)
            {
            }
            return Json(res);


        }

        public IActionResult AllowDisAllow(int id, bool allow)
        {
            try
            {
                var groupEvent = repo.iRashaka<GroupEvent>().Find(id);
                groupEvent.isAllowed = allow;
                repo.Save();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }

        }



    }
}