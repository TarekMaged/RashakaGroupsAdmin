using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FoodSystem
{
    public int id { get; set; }

    public string? name { get; set; }

    public int? healthStatusId { get; set; }

    public int? mainMealsCount { get; set; }

    public int? snaksMealsCount { get; set; }

    public string? femaleStatus { get; set; }

    public bool? isVisible { get; set; }

    public string? language { get; set; }

    public string? englishName { get; set; }

    public int? parentId { get; set; }

    public virtual ICollection<FoodSystemType> FoodSystemTypes { get; set; } = new List<FoodSystemType>();

    public virtual HealthStatus? healthStatus { get; set; }
}
