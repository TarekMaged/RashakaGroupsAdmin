using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Day
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? englishName { get; set; }

    public virtual ICollection<FoodSystemMeal> FoodSystemMeals { get; set; } = new List<FoodSystemMeal>();

    public virtual ICollection<GroupEventDay> GroupEventDays { get; set; } = new List<GroupEventDay>();

    public virtual ICollection<TrainingDay> TrainingDays { get; set; } = new List<TrainingDay>();

    public virtual ICollection<TrainingPlan> TrainingPlans { get; set; } = new List<TrainingPlan>();

    public virtual ICollection<UserTraining> UserTrainings { get; set; } = new List<UserTraining>();
}
