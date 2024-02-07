using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class NewFood
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? url { get; set; }

    public string? unit { get; set; }

    public string? imageUrl { get; set; }

    public string? arabicName { get; set; }

    public int? categoryId { get; set; }

    public int? unitid { get; set; }

    public bool? Saved { get; set; }

    public virtual ICollection<NewFoodDetail> NewFoodDetails { get; set; } = new List<NewFoodDetail>();
}
