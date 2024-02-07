using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_GroupUser
{
    public int id { get; set; }

    public int? creatorId { get; set; }

    public string? groupName { get; set; }

    public string? groupImage { get; set; }

    public string? privacy { get; set; }

    public string? name { get; set; }

    public string? gender { get; set; }

    public string? iso { get; set; }

    public string? city { get; set; }

    public string? image { get; set; }

    public string? purchaseStatus { get; set; }

    public string? email { get; set; }

    public int? accountId { get; set; }

    public int? groupId { get; set; }

    public string? requestStatus { get; set; }

    public DateTime? joinDate { get; set; }

    public bool? isAdmin { get; set; }

    public DateTime? lastUploadDate { get; set; }

    public DateTime? currentDayDate { get; set; }

    public DateTime? yesterdayDate { get; set; }

    public int? yesterdayStepsCount { get; set; }

    public double? yesterdayDistance { get; set; }

    public double? yesterdayCalories { get; set; }

    public int? currentDayStepsCount { get; set; }

    public double? todayDistance { get; set; }

    public double? todayCalories { get; set; }

    public int? weekStepsCount { get; set; }

    public double? weekDistance { get; set; }

    public double? weekCalories { get; set; }

    public int? monthStepsCount { get; set; }

    public double? monthDistance { get; set; }

    public double? monthCalories { get; set; }

    public int? allStepsCount { get; set; }

    public double? allDistance { get; set; }

    public double? allCalories { get; set; }

    public double? dailyActivityTime { get; set; }

    public double? yesterdayActivityTime { get; set; }

    public DateTime? activityTimeTodayDate { get; set; }
}
