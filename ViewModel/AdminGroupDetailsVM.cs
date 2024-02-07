using RashakaGroupsAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.ViewModel
{
    public class AdminGroupDetailsVM
    {
        public Group group { get; set; }
        public int? reportsCount { get; set; }
        //public int? usersCount { get; set; }
        //public int? postsCount { get; set; }
        //public int? eventsCount { get; set; }
        public int? postsReportsCount { get; set; }
        public IEnumerable<GroupUser> admins { get; set; }
    }
}