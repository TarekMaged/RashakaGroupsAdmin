using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class ServicesDailyReport
{
    public int id { get; set; }

    public int? serviceId { get; set; }

    public DateTime? date { get; set; }

    public int? androidCount { get; set; }

    public int? iphoneCount { get; set; }

    public virtual Service? service { get; set; }
}
