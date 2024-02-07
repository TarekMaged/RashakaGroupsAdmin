using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class temptable
{
    public int id { get; set; }

    public int? weekStepsCount { get; set; }

    public int? weekDistance { get; set; }

    public int? weekCalories { get; set; }

    public int? weekDuration { get; set; }
}
