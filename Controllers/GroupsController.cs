using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Services;

namespace RashakaGroupsAdmin.Controllers
{
    [Authorize(Roles = "adminGroups")]
    public class GroupsController : Controller
    {
        readonly IGroupsService iGroupsService;
        readonly IGroupUser iGroupUser;
        readonly IGroupPost iGroupPost;
        public GroupsController(IGroupsService _repo, IGroupUser _iGroupUser, IGroupPost iGroupPost)
        {
            iGroupsService = _repo;
            iGroupUser = _iGroupUser;
            this.iGroupPost = iGroupPost;
        }
        [HttpPost]
        public IActionResult ShareWeekUserAsPost(string user, string steps, int groupId)
        {
            try
            {
                iGroupPost.ShareWeekUserAsPost(user, steps, groupId);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }

        }
        public IActionResult Details(int? id)
        {
            GlobalValues.SetGroupId(id ?? 0);
            var details = iGroupsService.GetGroupDetails(id ?? 0);
            return View(details);
        }

        //[OutputCache(CacheProfile ="steps",Duration =1000)]
        [HttpPost]
        public IActionResult GetGroupSteps(int id)
        {
            var steps = iGroupsService.GetGroupSteps(id);
            return PartialView("_GroupSteps", steps);
        }

        public IActionResult Settings(int id)
        {
            var groupSettings = iGroupsService.GetGroupSettings(id);
            return View(groupSettings);
        }
        public IActionResult Reporting(int id, int? page)
        {
            ViewBag.groupId = id;
            var groupSettings = iGroupsService.GetGroupReporting(id, page ?? 1);
            return View(groupSettings);
        }
        // GET: Groups
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        //[ValidateInput(false)]
        public IActionResult AddGroup(GroupModel model)
        {
            try
            {
                iGroupsService.AddGroup(model);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ViewBag.message = "حدث خطأ";
                return View();
            }
        }
        public IActionResult Edit(int id)
        {

            ViewBag.admins = iGroupUser.GetGroupAdmins(id);
            return View(iGroupsService.GetGroup(id));
        }
        [HttpPost]
        public IActionResult Edit(GroupModel model)
        {
            try
            {
                iGroupsService.EditGroup(model);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.message = "حدث خطأ";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                iGroupsService.DeleteGroup(id);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
    }
}