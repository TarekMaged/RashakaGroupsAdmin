using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class HealthStatus
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? gender { get; set; }

    public int? priority { get; set; }

    public string? type { get; set; }

    public string? femaleStatus { get; set; }

    public string? englishName { get; set; }

    public string? language { get; set; }

    public virtual ICollection<FoodSystem> FoodSystems { get; set; } = new List<FoodSystem>();
}
