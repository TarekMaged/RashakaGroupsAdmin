using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Meal
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? englishName { get; set; }

    public bool? allow { get; set; }

    public string? language { get; set; }

    public virtual ICollection<FoodSystemMeal> FoodSystemMeals { get; set; } = new List<FoodSystemMeal>();

    public virtual ICollection<UserFoodSystemDetail> UserFoodSystemDetails { get; set; } = new List<UserFoodSystemDetail>();

    public virtual ICollection<UserMeal> UserMeals { get; set; } = new List<UserMeal>();
}
