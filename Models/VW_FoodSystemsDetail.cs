using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_FoodSystemsDetail
{
    public int id { get; set; }

    public int fsmId { get; set; }

    public int systemId { get; set; }

    public string? systemName { get; set; }

    public int dietTypeId { get; set; }

    public int? calories { get; set; }

    public string? language { get; set; }

    public int healthStatusId { get; set; }

    public string? healthStatus { get; set; }

    public string? healthStatusEnglishName { get; set; }

    public int mealId { get; set; }

    public string? mealName { get; set; }

    public string? englishMealName { get; set; }

    public int dayId { get; set; }

    public string? day { get; set; }

    public string? englishDayName { get; set; }

    public int foodId { get; set; }

    public string? foodName { get; set; }

    public double? quantity { get; set; }

    public int? unitId { get; set; }

    public string? notes { get; set; }

    public int? mainMealsCount { get; set; }

    public int? snaksMealsCount { get; set; }

    public int? parentId { get; set; }
}
