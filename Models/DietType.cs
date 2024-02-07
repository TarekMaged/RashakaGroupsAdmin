using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class DietType
{
    public int id { get; set; }

    public string? name { get; set; }

    public int? calories { get; set; }

    public string? englishName { get; set; }

    public virtual ICollection<FoodSystemType> FoodSystemTypes { get; set; } = new List<FoodSystemType>();
}
