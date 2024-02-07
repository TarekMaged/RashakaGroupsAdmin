using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class StepType
{
    public int id { get; set; }

    public string? type { get; set; }

    public virtual ICollection<Step> Steps { get; set; } = new List<Step>();

    public virtual ICollection<Steps2> Steps2s { get; set; } = new List<Steps2>();
}
