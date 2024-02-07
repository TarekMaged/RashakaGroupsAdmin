using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FoodsEnglish
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

    public int? currentFoodId { get; set; }

    public int? currentcategoryId { get; set; }

    public virtual ICollection<FoodDetailsEnglish> FoodDetailsEnglishes { get; set; } = new List<FoodDetailsEnglish>();

    public virtual FoodCategoryEnglish? category { get; set; }
}
