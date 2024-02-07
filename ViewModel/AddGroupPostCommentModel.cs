using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.Models
{
    public class AddGroupPostCommentModel
    {
        public int groupPostId { get; set; }
        public string comment { get; set; }
        public int accountId { get; set; }
        public DateTime date { get; set; }
    }
}