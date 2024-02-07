using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.Requests
{
    public class GroupUserModel
    {
        public int groupId { get; set; }
        public int adminId { get; set; }
        public int accountId { get; set; }
        public bool isAccepted { get; set; }
    }
}