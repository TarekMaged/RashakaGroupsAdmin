using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class ActivityLocation
{
    public int id { get; set; }

    public decimal? lat { get; set; }

    public decimal? lng { get; set; }

    public int? activityId { get; set; }

    public virtual Activity? activity { get; set; }
}
