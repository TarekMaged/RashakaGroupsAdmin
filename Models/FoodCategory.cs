using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FoodCategory
{
    public int id { get; set; }

    public string? name { get; set; }

    public byte[]? timeStamp { get; set; }

    public string? updateType { get; set; }

    public DateTime? date { get; set; }

    public string? url { get; set; }

    public int? order { get; set; }

    public string? language { get; set; }

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();

    public virtual ICollection<FoodsByUser> FoodsByUsers { get; set; } = new List<FoodsByUser>();
}
