using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VwGroupUser
{
    public int Id { get; set; }

    public int? CreatorId { get; set; }

    public string? GroupName { get; set; }

    public string? GroupImage { get; set; }

    public string? Privacy { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public string? Iso { get; set; }

    public string? City { get; set; }

    public string? Image { get; set; }

    public string? PurchaseStatus { get; set; }

    public string? Email { get; set; }

    public int? AccountId { get; set; }

    public int? GroupId { get; set; }

    public string? RequestStatus { get; set; }

    public DateTime? JoinDate { get; set; }

    public bool? IsAdmin { get; set; }

    public DateTime? LastUploadDate { get; set; }

    public DateTime? CurrentDayDate { get; set; }

    public DateTime? YesterdayDate { get; set; }

    public int? YesterdayStepsCount { get; set; }

    public double? YesterdayDistance { get; set; }

    public double? YesterdayCalories { get; set; }

    public int? CurrentDayStepsCount { get; set; }

    public double? TodayDistance { get; set; }

    public double? TodayCalories { get; set; }

    public int? WeekStepsCount { get; set; }

    public double? WeekDistance { get; set; }

    public double? WeekCalories { get; set; }

    public int? MonthStepsCount { get; set; }

    public double? MonthDistance { get; set; }

    public double? MonthCalories { get; set; }

    public int? AllStepsCount { get; set; }

    public double? AllDistance { get; set; }

    public double? AllCalories { get; set; }

    public double? DailyActivityTime { get; set; }

    public double? YesterdayActivityTime { get; set; }
}
