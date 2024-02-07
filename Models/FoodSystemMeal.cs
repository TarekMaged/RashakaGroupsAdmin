using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FoodSystemMeal
{
    public int id { get; set; }

    public int? mealId { get; set; }

    public int? foodSystemTypeId { get; set; }

    public int? foodId { get; set; }

    public double? quantity { get; set; }

    public int? dayId { get; set; }

    public int? unitId { get; set; }

    public string? notes { get; set; }

    public virtual Day? day { get; set; }

    public virtual Food? food { get; set; }

    public virtual FoodSystemType? foodSystemType { get; set; }

    public virtual Meal? meal { get; set; }

    public virtual FoodUnit? unit { get; set; }
}
