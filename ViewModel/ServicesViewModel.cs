using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.ViewModel
{
    public class ServicesViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
         public int? count { get; set; }
        public int? androidCount { get; set; }
        public int? iphoneCount { get; set; }
        public int? totalCounts { get; set; }
        public DateTime? date { get; set; }
    }
}