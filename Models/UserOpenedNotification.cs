using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserOpenedNotification
{
    public int id { get; set; }

    public int accountId { get; set; }

    public int serviceId { get; set; }

    public DateTime? date { get; set; }

    public string? type { get; set; }

    public string? pageName { get; set; }

    public int? notificationId { get; set; }

    public int? userId { get; set; }

    public virtual NotificationHistory? notification { get; set; }
}
