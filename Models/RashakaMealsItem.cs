using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class RashakaMealsItem
{
    public int id { get; set; }

    public int? rashakaMealId { get; set; }

    public string? name { get; set; }

    public string? image { get; set; }

    public string? quantity { get; set; }

    public virtual RashakaMeal? rashakaMeal { get; set; }
}
