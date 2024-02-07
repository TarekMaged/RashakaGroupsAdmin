using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserMealsDetail
{
    public int id { get; set; }

    public int? userMealId { get; set; }

    public int? foodId { get; set; }

    public double? count { get; set; }

    public DateTime? date { get; set; }

    public string? updateType { get; set; }

    public int? unitId { get; set; }

    public virtual Food? food { get; set; }

    public virtual FoodUnit? unit { get; set; }

    public virtual UserMeal? userMeal { get; set; }
}
