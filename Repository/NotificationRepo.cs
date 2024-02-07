using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Services;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.Repository
{
    public class NotificationRepo
    {
        IRashakaUniteOfWork repo;
        public NotificationRepo()
        {
            repo = new RashakaUniteOfWork();
        }
        //public static object GetHistory()
        //{
        //    var data = DapperService<NotificationHistory>.GetData("SELECT   [typ],[scheduleDate],[date],[message],[screenName],[groupId],[newsId],[postId],[imageUrl] FROM [NotificationHistory] order by id desc");
        //    return data.Select(x => new
        //    {   
        //        x.message,
        //        date = x.date.Value.ToString("dd/MM/yyyy"),
        //        scheduleDate =x. scheduleDate!=null? x.scheduleDate.Value.ToString("dd/MM/yyyy hh:mm tt") :"",               
        //        x.typ
        //    });
        //}
    }
}