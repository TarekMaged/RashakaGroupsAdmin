using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserService
{
    public int id { get; set; }

    public int? serviceId { get; set; }

    public int? userId { get; set; }

    public DateTime? firstOpenDate { get; set; }

    public DateTime? lastOpenDate { get; set; }

    public DateTime? lastNotificationDate { get; set; }

    public string? deviceToken { get; set; }

    public int? countOfOpening { get; set; }

    public int? platform { get; set; }

    public virtual Service? service { get; set; }

    public virtual User? user { get; set; }
}
