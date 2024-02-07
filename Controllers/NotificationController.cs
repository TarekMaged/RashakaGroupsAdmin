using Microsoft.AspNetCore.Mvc;
using RashakaAdmin.Models;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Services;
using System.Data;

namespace RashakaAdmin.Controllers
{
    //[HandleError(View = "Error")]
    public class NotificationController : Controller
    {
        readonly INotification iNotification;
        public NotificationController(INotification _iNotification)
        {
            iNotification = _iNotification;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(NotificationData model)
        {
            ViewBag.message = iNotification.SendNotification(model);
            return View();
        }
        [HttpPost]
        public IActionResult SendByPost(int id)
        {
            return Json(iNotification.SendAfterAddingGroupPost(id));
        }
        public IActionResult Top250000()
        {
            ViewBag.message = "";
            return View();
        }

        public IActionResult FoodSuggestionNotification()
        {
            ViewBag.message = "";
            return View();
        }


        public IActionResult Silent()
        {
            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        public IActionResult SendNotificationToGroupUser(int accountId, int groupId, string message)
        {
            try
            {
                //var accessToken = string.Empty;
                //if (accountId > 0)
                //{
                //    accessToken = DapperService<object>.ExecuteScalar("GetUserAccessToken", new
                //    {
                //        accountId = accountId
                //    }).ToString();
                //}

                GroupsNotificationModel model = new() { Type = "previewGroup", groupId = groupId, accountId = accountId, Message = message/*, tokens = new List<string> { accessToken.ToString() } */};
                string res = NotificationService.SendToTokens(model);
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(false);
            }

        }
        [HttpPost]
        public IActionResult SendNotificationToGroup(string groupId, string message)
        {
            try
            {
                NotificationData data = new() { type = "previewGroup", groupId = groupId, body = message, topic = new List<string> { "New_group_" + groupId } };
                string result = iNotification.SendMainNotification(data);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }

        }
        [HttpPost]
        public IActionResult SendNotificationToUser(int accountId, string message)
        {
            try
            {
                var accessToken = DapperService<object>.ExecuteScalar("GetUserAccessToken", new
                {
                    accountId
                }, CommandType.StoredProcedure);
                GroupsNotificationModel model = new() { Type = "normal", accountId = accountId, Message = message, tokens = new List<string> { accessToken.ToString() } };

                string res = NotificationService.SendToTokens(model);
                //BackgroundJob.Schedule( () => NotificationCenter.SendToTokens(model), TimeSpan.FromMinutes(2));
                //BackgroundJob.Enqueue(() => NotificationCenter.SendToTokens(model));
                //RecurringJob.AddOrUpdate(() => NotificationCenter.SendToTokens(model), Cron.Minutely());
                //RecurringJob.AddOrUpdate(() => NotificationCenter.SendToTokens(model), Cron.Daily());
                //RecurringJob.AddOrUpdate(() => NotificationCenter.SendToTokens(model), Cron.Hourly(1));
                //RecurringJob.AddOrUpdate(() => NotificationCenter.SendToTokens(model), Cron.HourInterval(int.Parse(1)));
                //RecurringJob.AddOrUpdate(() => NotificationCenter.SendToTokens(model), Cron.HourInterval(int.Parse(1)));
                //DateTimeOffset dateOffset = DateTime.SpecifyKind(DateTime.Now.AddMinutes(5), DateTimeKind.Local);
                //BackgroundJob.Schedule(() => NotificationCenter.SendToTokens(model), dateOffset);
                //RecurringJob.AddOrUpdate(() => NotificationCenter.SendToTokens(model), Cron.Daily());

                if (res == "1")
                {
                    return Json(true);
                }
                return Json(false);
            }
            catch (Exception ex)
            {
                return Json(false);
            }

        }

    }
}