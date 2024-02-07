using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FoodCategoryEnglish
{
    public int id { get; set; }

    public string? name { get; set; }

    public byte[]? timeStamp { get; set; }

    public string? updateType { get; set; }

    public DateTime? date { get; set; }

    public string? url { get; set; }

    public int? order { get; set; }

    public virtual ICollection<FoodsEnglish> FoodsEnglishes { get; set; } = new List<FoodsEnglish>();
}
