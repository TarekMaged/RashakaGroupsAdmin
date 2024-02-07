using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Weight
{
    public int id { get; set; }

    public double? value { get; set; }

    public DateTime? date { get; set; }

    public int? accountId { get; set; }

    public virtual Account? account { get; set; }
}
