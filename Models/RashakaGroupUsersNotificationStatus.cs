using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class RashakaGroupUsersNotificationStatus
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public bool? allowGroupNotifications { get; set; }
}
