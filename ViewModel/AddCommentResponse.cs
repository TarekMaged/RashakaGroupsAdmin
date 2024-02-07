using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.Models
{
    public class AddCommentResponse
    {
        public string ArtGuid { get; set; }
        public string commentGuid { get; set; }
        public int commentCount { get; set; }
    }
}