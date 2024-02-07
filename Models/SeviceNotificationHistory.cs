using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class SeviceNotificationHistory
{
    public int id { get; set; }

    public DateTime? date { get; set; }

    public int? serviceId { get; set; }

    public string? message { get; set; }

    public int? days { get; set; }

    public string? screenName { get; set; }

    public DateTime? scheduleDate { get; set; }

    public int? numberOfReceivedNotifications { get; set; }

    public int? notificationId { get; set; }
}
