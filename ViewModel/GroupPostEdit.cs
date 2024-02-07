using RashakaGroupsAdmin.Models;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Requests
{
    public class GroupPostEdit
    {
        public int id { get; set; }
        public int? accountId { get; set; }
        public int? groupId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> imagesToDelete { get; set; }
        //public GroupPost groupPost { get; set; }
        //public List<string> imagesToDelete { get; set; }

    }
}