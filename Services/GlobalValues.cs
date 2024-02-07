using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.Services
{
    public class GlobalValues
    {
        public static int? GroupId { get; set; }
        public static Guid accountGuid { get; set; }
        public static void SetGroupId(int _GroupId)
        {
            GroupId = _GroupId;
        }
        public static void SetAccountGuid(Guid _accountGuid)
        {
            accountGuid = _accountGuid;
        }
    }
}