using RashakaGroupsAdmin.Repository;
using RashakaGroupsAdmin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.ViewModels
{
    public class CommentSystemVM
    {
        public string text { get; set; }
        public string date { get; set; }
        public string ArtName { get; set; }
        public string commentArtGuid { get; set; }
        public string guid { get; set; }
        public int likeCount { get; set; }
        public int replyCount { get; set; }
        public string accountGuid { get; set; }
        public string userName { get; set; }
        public string image { get; set; }
        public bool isLike { get; set; }
        public List<Reply> replies { get; set; }
    }
}