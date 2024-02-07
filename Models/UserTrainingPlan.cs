using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserTrainingPlan
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public int? trainingPlanId { get; set; }

    public int? dayId { get; set; }

    public DateTime? date { get; set; }

    public virtual TrainingPlan? trainingPlan { get; set; }
}
