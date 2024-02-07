
using RashakaGroupsAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace RashakaGroupsAdmin.ViewModel
{
    public class GroupPostsModel
    {
        public bool isUnderRevision { get; set; }
        public int viewsCount { get; set; }
        public int id { get; set; }
        public Nullable<int> groupId { get; set; }
        public string goal { get; set; } = string.Empty;
        public int goalValue { get; set; }
        public Nullable<int> accountId { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string image { get; set; } = string.Empty;
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> totalLikes { get; set; } = 0;
        public Nullable<int> commentsCount { get; set; } = 0;
        public Nullable<int> shareCount { get; set; } = 0;
        public string image2 { get; set; } = string.Empty;
        public string image3 { get; set; } = string.Empty;
        public Nullable<System.Guid> commentArtGuid { get; set; }
        public Nullable<System.Guid> guid { get; set; }

        public Nullable<int> commentSystemCommentsCount { get; set; } = 0;
        public bool isPinned { get; set; } = false;
        public string shareImageUrl { get; set; } = string.Empty;
        public Nullable<int> type { get; set; } = 0;
        public string shareLink { get; set; } = string.Empty;
        public Nullable<int> sharedGroupMembersCount { get; set; } = 0;
        public Nullable<int> sharedStepsCount { get; set; } = 0;
        public Nullable<int> sharedGroupId { get; set; } = 0;
        public string sharedGroupName { get; set; } = string.Empty;
        public Nullable<double> calories { get; set; } = 0;
        public string duration { get; set; } = string.Empty;
        public Nullable<double> distance { get; set; } = 0;
        public string durations { get; set; } = string.Empty;
        public Nullable<int> eventId { get; set; } = 0;
        public string eventName { get; set; } = string.Empty;
        public Nullable<bool> compareSteps { get; set; }
        public string profileImage { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public bool? isLiked { get; set; } = false;
        public int rowsCount { get; set; }
        public string groupName { get; set; } = string.Empty;
        public string userName { get; set; } = string.Empty;
        public string purchaseStatus { get; set; } =string.Empty;
        public string privacy { get; set; } = string.Empty;
        public bool isMember { get; set; } = false;
        public int? postOwnerId { get; set; }
        public string ownerName { get; set; } = string.Empty;
        public Nullable<System.Guid> accountGuid { get; set; }
        public string ownerProfileImage { get; set; } = string.Empty;
    }
    public class ReportedPosts
    {
        public IPagedList<GroupPost> Posts { get; set; }
        public string GroupName { get; set; }
        public int GroupId{ get; set; }
    }
    //public class GroupPostWithShareData : GroupPost
    //{
    //    public new List<int> groupId { get; set; }
    //}
}