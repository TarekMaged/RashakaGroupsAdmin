using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserMeal
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public int? mealId { get; set; }

    public DateTime? date { get; set; }

    public bool? deleted { get; set; }

    public byte[]? timestamp { get; set; }

    public virtual ICollection<UserMealsDetail> UserMealsDetails { get; set; } = new List<UserMealsDetail>();

    public virtual Account? account { get; set; }

    public virtual Meal? meal { get; set; }
}
