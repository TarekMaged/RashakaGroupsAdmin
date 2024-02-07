using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Service
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? arabicName { get; set; }

    public virtual ICollection<NotificationHistory> NotificationHistories { get; set; } = new List<NotificationHistory>();

    public virtual ICollection<ServicesDailyReport> ServicesDailyReports { get; set; } = new List<ServicesDailyReport>();

    public virtual ICollection<UserService> UserServices { get; set; } = new List<UserService>();
}
