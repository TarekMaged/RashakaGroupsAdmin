using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupUser
{
    public int id { get; set; }

    public int? groupId { get; set; }

    public int? accountId { get; set; }

    public DateTime? joinDate { get; set; }

    public string? requestStatus { get; set; }

    public bool? isAdmin { get; set; }

    public int? yesterdayStepsCount { get; set; }

    public int? weekStepsCount { get; set; }

    public int? monthStepsCount { get; set; }

    public int? allStepsCount { get; set; }

    public DateTime? lastUploadDate { get; set; }

    public int? currentDayStepsCount { get; set; }

    public DateTime? currentDayDate { get; set; }

    public DateTime? yesterdayDate { get; set; }

    public int? lastDayStepsCount { get; set; }

    public double? weekDistance { get; set; }

    public double? monthDistance { get; set; }

    public double? allDistance { get; set; }

    public double? todayDistance { get; set; }

    public double? yesterdayDistance { get; set; }

    public bool? allowGroupNotifications { get; set; }

    public int? currentStepsOrder { get; set; }

    public int? lastStepsOrder { get; set; }

    public DateTime? lastUserOrderNotificationDate { get; set; }

    public double? weekCalories { get; set; }

    public double? monthCalories { get; set; }

    public double? allCalories { get; set; }

    public double? todayCalories { get; set; }

    public double? yesterdayCalories { get; set; }

    public double? dailyActivityTime { get; set; }

    public double? yesterdayActivityTime { get; set; }

    public DateTime? activityTimeTodayDate { get; set; }

    public virtual Account? account { get; set; }

    public virtual Group? group { get; set; }
}
