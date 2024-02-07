using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FoodSystemType
{
    public int id { get; set; }

    public string? name { get; set; }

    public int? weightFrom { get; set; }

    public int? weightTo { get; set; }

    public int? foodSystemId { get; set; }

    public int? dietId { get; set; }

    public virtual ICollection<FoodSystemMeal> FoodSystemMeals { get; set; } = new List<FoodSystemMeal>();

    public virtual DietType? diet { get; set; }

    public virtual FoodSystem? foodSystem { get; set; }
}
