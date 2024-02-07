using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class TrainingDay
{
    public int id { get; set; }

    public int? DayId { get; set; }

    public int? accountId { get; set; }

    public TimeSpan? startTime { get; set; }

    public string? gender { get; set; }

    public virtual Day? Day { get; set; }

    public virtual Account? account { get; set; }
}
