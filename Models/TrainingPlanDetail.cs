using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class TrainingPlanDetail
{
    public int id { get; set; }

    public int? trainingId { get; set; }

    public int? TrainingPlanId { get; set; }

    public int? duration { get; set; }

    public string? level { get; set; }

    public string? section { get; set; }

    public virtual TrainingPlan? TrainingPlan { get; set; }

    public virtual Training? training { get; set; }
}
