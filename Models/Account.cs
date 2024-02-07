using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Account
{
    public int id { get; set; }

    public string? publicId { get; set; }

    public string? name { get; set; }

    public string? gender { get; set; }

    public DateTime? birthDate { get; set; }

    public string? email { get; set; }

    public string? image { get; set; }

    public int? coachId { get; set; }

    public double? height { get; set; }

    public string? type { get; set; }

    public DateTime? lastSyncDownloadDate { get; set; }

    public double? weight { get; set; }

    public DateTime? lastSyncUploadDate { get; set; }

    public bool? isLogedIn { get; set; }

    public int? age { get; set; }

    public int? weekStepsCount { get; set; }

    public DateTime? weekStepsDate { get; set; }

    public int? monthStepsCount { get; set; }

    public DateTime? monthStepsDate { get; set; }

    public int? allStepsCount { get; set; }

    public DateTime? date { get; set; }

    public bool? isImageUpdated { get; set; }

    public bool? isNameUpdated { get; set; }

    public int? lastStepsNotification { get; set; }

    public DateTime? mealsLastUploadDate { get; set; }

    public string? userActivity { get; set; }

    public string? goal { get; set; }

    public double? desiredWeight { get; set; }

    public double? weekDesiredWeight { get; set; }

    public string? iso { get; set; }

    public string? city { get; set; }

    public Guid? guid { get; set; }

    public bool? isBlocked { get; set; }

    public string? fullName { get; set; }

    public string? email2 { get; set; }

    public string? mobile { get; set; }

    public string? country { get; set; }

    public string? deleteStatus { get; set; }

    public string? femaleStatus { get; set; }

    public string? chronicDiseaseId { get; set; }

    public string? applicationGoal { get; set; }

    public string? purchaseStatus { get; set; }

    public int? yesterdayStepsCount { get; set; }

    public DateTime? currentDayDate { get; set; }

    public int? currentDayStepsCount { get; set; }

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

    public virtual ICollection<GroupEventComment> GroupEventComments { get; set; } = new List<GroupEventComment>();

    public virtual ICollection<GroupEvent> GroupEvents { get; set; } = new List<GroupEvent>();

    public virtual ICollection<GroupPostComment> GroupPostComments { get; set; } = new List<GroupPostComment>();

    public virtual ICollection<GroupPostLike> GroupPostLikes { get; set; } = new List<GroupPostLike>();

    public virtual ICollection<GroupPostReport> GroupPostReports { get; set; } = new List<GroupPostReport>();

    public virtual ICollection<GroupPost> GroupPosts { get; set; } = new List<GroupPost>();

    public virtual ICollection<GroupReport> GroupReports { get; set; } = new List<GroupReport>();

    public virtual ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
