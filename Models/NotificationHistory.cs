using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class NotificationHistory
{
    public int id { get; set; }

    public string? typ { get; set; }

    public DateTime? scheduleDate { get; set; }

    public DateTime? date { get; set; }

    public string? message { get; set; }

    public string? screenName { get; set; }

    public int? groupId { get; set; }

    public int? newsId { get; set; }

    public int? postId { get; set; }

    public string? imageUrl { get; set; }

    public int? hangfireId { get; set; }

    public int? serviceId { get; set; }

    public int? numberOfReceivedNotifications { get; set; }

    public bool? isAutomatic { get; set; }

    public virtual ICollection<UserOpenedNotification> UserOpenedNotifications { get; set; } = new List<UserOpenedNotification>();

    public virtual Service? service { get; set; }
}
