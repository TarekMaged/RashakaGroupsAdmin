using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FoodUnit
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? value { get; set; }

    public int? foodId { get; set; }

    public string? weightId { get; set; }

    public double? ammount { get; set; }

    public string? language { get; set; }

    public string? englishName { get; set; }

    public virtual ICollection<FoodSystemMeal> FoodSystemMeals { get; set; } = new List<FoodSystemMeal>();

    public virtual ICollection<FoodsByUserNutrient> FoodsByUserNutrients { get; set; } = new List<FoodsByUserNutrient>();

    public virtual ICollection<Nutrient> Nutrients { get; set; } = new List<Nutrient>();

    public virtual ICollection<UserMealsDetail> UserMealsDetails { get; set; } = new List<UserMealsDetail>();

    public virtual Food? food { get; set; }
}
