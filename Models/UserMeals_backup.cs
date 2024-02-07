using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserMeals_backup
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public int? mealId { get; set; }

    public DateTime? date { get; set; }

    public bool? deleted { get; set; }

    public byte[]? timestamp { get; set; }
}
