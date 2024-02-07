using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class RashakaMeal
{
    public int id { get; set; }

    public string? type { get; set; }

    public string? name { get; set; }

    public double? time { get; set; }

    public double? protein { get; set; }

    public double? fat { get; set; }

    public double? carbohydrates { get; set; }

    public double? calories { get; set; }

    public string? method { get; set; }

    public string? image { get; set; }

    public DateTime? date { get; set; }

    public bool? isDeleted { get; set; }

    public int? itemsCount { get; set; }

    public bool? isTodayMeal { get; set; }

    public bool? isMainMeal { get; set; }

    public Guid? commentArtGuid { get; set; }

    public int? viewsCount { get; set; }

    public int? commentsCount { get; set; }

    public Guid? guid { get; set; }

    public string? language { get; set; }

    public bool? allow { get; set; }

    public string? urlTitle { get; set; }

    public virtual ICollection<RashakaMealsItem> RashakaMealsItems { get; set; } = new List<RashakaMealsItem>();
}
