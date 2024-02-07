using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_PublicGroupsPost
{
    public int id { get; set; }

    public int? groupId { get; set; }

    public string? groupName { get; set; }

    public string? goal { get; set; }

    public int? goalValue { get; set; }

    public string? privacy { get; set; }

    public int? typeId { get; set; }

    public int? accountId { get; set; }

    public string? title { get; set; }

    public string? description { get; set; }

    public DateTime? date { get; set; }

    public int? totalLikes { get; set; }

    public int? shareCount { get; set; }

    public int? commentsCount { get; set; }

    public int? commentSystemCommentsCount { get; set; }

    public int? viewsCount { get; set; }

    public string? userName { get; set; }

    public string? profileImage { get; set; }

    public string? image { get; set; }

    public string? image2 { get; set; }

    public string? image3 { get; set; }

    public int? sharedGroupMembersCount { get; set; }

    public int? sharedStepsCount { get; set; }

    public string? shareImageUrl { get; set; }

    public int? type { get; set; }

    public string? shareLink { get; set; }

    public int? sharedGroupId { get; set; }

    public string? sharedGroupName { get; set; }

    public double? calories { get; set; }

    public string? duration { get; set; }

    public double? distance { get; set; }

    public int? eventId { get; set; }

    public string? eventName { get; set; }

    public bool? compareSteps { get; set; }

    public string? purchaseStatus { get; set; }
}
