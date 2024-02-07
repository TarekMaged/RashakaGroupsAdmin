using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_UserFoodSystemDetail
{
    public int systemId { get; set; }

    public string? name { get; set; }

    public int mealId { get; set; }

    public int dietTypeId { get; set; }

    public int? calories { get; set; }

    public int healthStatusId { get; set; }

    public string? healthStatus { get; set; }

    public string? mealName { get; set; }

    public int dayId { get; set; }

    public string? day { get; set; }

    public int foodId { get; set; }

    public string? foodName { get; set; }

    public double? quantity { get; set; }

    public int? unitId { get; set; }

    public string? notes { get; set; }

    public int? mainMealsCount { get; set; }

    public int? snaksMealsCount { get; set; }
}
