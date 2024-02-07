using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Login
{
    public int id { get; set; }

    public string? userName { get; set; }

    public string? password { get; set; }

    public string? role { get; set; }

    public string? groupId { get; set; }

    public int? roleId { get; set; }

    public bool? deleted { get; set; }

    public int? accountId { get; set; }

    public virtual AdminRole? roleNavigation { get; set; }
}
