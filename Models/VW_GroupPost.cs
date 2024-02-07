using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_GroupPost
{
    public int id { get; set; }

    public Guid? commentArtGuid { get; set; }

    public int? groupId { get; set; }

    public int? accountId { get; set; }

    public string? name { get; set; }

    public string? profileImage { get; set; }

    public string? title { get; set; }

    public string? description { get; set; }

    public int? totalLikes { get; set; }

    public int? commentsCount { get; set; }

    public int? commentSystemCommentsCount { get; set; }

    public int? shareCount { get; set; }

    public string? image { get; set; }

    public string? image2 { get; set; }

    public string? image3 { get; set; }

    public DateTime? date { get; set; }

    public bool isPinned { get; set; }

    public int? sharedGroupMembersCount { get; set; }

    public int? sharedStepsCount { get; set; }

    public string? shareImageUrl { get; set; }

    public int? type { get; set; }

    public string? shareLink { get; set; }

    public int? sharedGroupId { get; set; }

    public string? sharedGroupName { get; set; }

    public string? durations { get; set; }

    public double? calories { get; set; }

    public double? distance { get; set; }

    public int? eventId { get; set; }

    public string? eventName { get; set; }

    public bool? compareSteps { get; set; }

    public string? purchaseStatus { get; set; }
}
