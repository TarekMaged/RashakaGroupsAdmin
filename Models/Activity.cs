using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Activity
{
    public int id { get; set; }

    public int? activityTypeId { get; set; }

    public int? stepCount { get; set; }

    public double? calories { get; set; }

    public double? target { get; set; }

    public DateTime? startTime { get; set; }

    public DateTime? endTime { get; set; }

    public double? duration { get; set; }

    public double? averagePace { get; set; }

    public double? maxPace { get; set; }

    public double? distance { get; set; }

    public int? accountId { get; set; }

    public double? speedAvg { get; set; }

    public double? speedMax { get; set; }

    public double? stepRateAvg { get; set; }

    public double? stepRateMax { get; set; }

    public string? activityPrizes { get; set; }

    public double? pauseDuration { get; set; }

    public string? activityType { get; set; }

    public virtual ICollection<ActivityLocation> ActivityLocations { get; set; } = new List<ActivityLocation>();

    public virtual ActivityType? activityTypeNavigation { get; set; }
}
