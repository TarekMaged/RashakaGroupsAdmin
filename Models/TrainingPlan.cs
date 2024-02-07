using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class TrainingPlan
{
    public int id { get; set; }

    public string? name { get; set; }

    public int? duration { get; set; }

    public int? trainingsCount { get; set; }

    public string? level { get; set; }

    public int? levelId { get; set; }

    public int? dayId { get; set; }

    public string? image { get; set; }

    public string? language { get; set; }

    public int? parentId { get; set; }

    public virtual ICollection<TrainingPlan> Inverseparent { get; set; } = new List<TrainingPlan>();

    public virtual ICollection<TrainingPlanDetail> TrainingPlanDetails { get; set; } = new List<TrainingPlanDetail>();

    public virtual ICollection<UserTrainingPlan> UserTrainingPlans { get; set; } = new List<UserTrainingPlan>();

    public virtual Day? day { get; set; }

    public virtual TrainingPlan? parent { get; set; }
}
