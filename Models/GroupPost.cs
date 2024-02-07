using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupPost
{
    public int id { get; set; }

    public int? groupId { get; set; }

    public int? accountId { get; set; }

    public string? title { get; set; }

    public string? description { get; set; }

    public string? image { get; set; }

    public DateTime? date { get; set; }

    public int? totalLikes { get; set; }

    public int? commentsCount { get; set; }

    public int? shareCount { get; set; }

    public int? groupUserId { get; set; }

    public int? reportsCount { get; set; }

    public string? image2 { get; set; }

    public string? image3 { get; set; }

    public bool? isAllowed { get; set; }

    public Guid? commentArtGuid { get; set; }

    public Guid? guid { get; set; }

    public int? commentSystemCommentsCount { get; set; }

    public int? viewsCount { get; set; }

    public bool isPinned { get; set; }

    public bool? isUnderRevision { get; set; }

    public string? shareImageUrl { get; set; }

    public int? type { get; set; }

    public string? shareLink { get; set; }

    public int? sharedGroupMembersCount { get; set; }

    public int? sharedStepsCount { get; set; }

    public int? sharedGroupId { get; set; }

    public string? sharedGroupName { get; set; }

    public double? calories { get; set; }

    public string? duration { get; set; }

    public double? distance { get; set; }

    public string? durations { get; set; }

    public int? eventId { get; set; }

    public string? eventName { get; set; }

    public bool? compareSteps { get; set; }

    public virtual ICollection<GroupPostComment> GroupPostComments { get; set; } = new List<GroupPostComment>();

    public virtual ICollection<GroupPostLike> GroupPostLikes { get; set; } = new List<GroupPostLike>();

    public virtual ICollection<GroupPostReport> GroupPostReports { get; set; } = new List<GroupPostReport>();

    public virtual Account? account { get; set; }

    public virtual Group? group { get; set; }
}
