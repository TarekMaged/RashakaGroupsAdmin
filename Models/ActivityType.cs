using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class ActivityType
{
    public int id { get; set; }

    public string? name { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
