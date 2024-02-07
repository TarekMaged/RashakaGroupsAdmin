using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class AdminRole
{
    public int id { get; set; }

    public string? name { get; set; }

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
