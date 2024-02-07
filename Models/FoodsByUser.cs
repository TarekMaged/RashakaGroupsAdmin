using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FoodsByUser
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

    public virtual ICollection<FoodsByUserNutrient> FoodsByUserNutrients { get; set; } = new List<FoodsByUserNutrient>();

    public virtual FoodCategory? category { get; set; }
}
