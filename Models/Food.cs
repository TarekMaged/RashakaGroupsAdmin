using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Food
{
    public int id { get; set; }

    public int? categoryId { get; set; }

    public string? name { get; set; }

    public string? url { get; set; }

    public byte[]? timeStamp { get; set; }

    public string? updateType { get; set; }

    public DateTime? date { get; set; }

    public int? oldCategoryId { get; set; }

    public int? suggestionId { get; set; }

    public int? accountId { get; set; }

    public bool? isNew { get; set; }

    public int? newFoodId { get; set; }

    public string? language { get; set; }

    public string? notes { get; set; }

    public string? englishName { get; set; }

    public virtual ICollection<FoodSystemMeal> FoodSystemMeals { get; set; } = new List<FoodSystemMeal>();

    public virtual ICollection<FoodUnit> FoodUnits { get; set; } = new List<FoodUnit>();

    public virtual ICollection<Nutrient> Nutrients { get; set; } = new List<Nutrient>();

    public virtual ICollection<UserFavoritFood> UserFavoritFoods { get; set; } = new List<UserFavoritFood>();

    public virtual ICollection<UserFoodSystemDetail> UserFoodSystemDetails { get; set; } = new List<UserFoodSystemDetail>();

    public virtual ICollection<UserMealsDetail> UserMealsDetails { get; set; } = new List<UserMealsDetail>();

    public virtual Account? account { get; set; }

    public virtual FoodCategory? category { get; set; }
}
