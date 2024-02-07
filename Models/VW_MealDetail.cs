using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_MealDetail
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? type { get; set; }

    public double? protein { get; set; }

    public double? calories { get; set; }

    public double? carbohydrates { get; set; }

    public int? commentsCount { get; set; }

    public Guid? commentArtGuid { get; set; }

    public double? fat { get; set; }

    public string? method { get; set; }

    public string? image { get; set; }

    public int? itemsCount { get; set; }

    public double? time { get; set; }

    public int? viewsCount { get; set; }

    public int itemId { get; set; }

    public string? itemName { get; set; }

    public string? itemQuantity { get; set; }

    public string? itemImage { get; set; }

    public DateTime? date { get; set; }
}
