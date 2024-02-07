using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Steps2
{
    public int id { get; set; }

    public DateTime? date { get; set; }

    public int? count { get; set; }

    public double? duration { get; set; }

    public int? typeId { get; set; }

    public double? distance { get; set; }

    public double? calories { get; set; }

    public int? accountId { get; set; }

    public DateTime? datetime { get; set; }

    public virtual StepType? type { get; set; }
}
