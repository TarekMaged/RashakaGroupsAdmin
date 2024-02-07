using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserFoodSystemDetail
{
    public int id { get; set; }

    public int? userFoodSystemId { get; set; }

    public int? mealId { get; set; }

    public int? foodId { get; set; }

    public double? quantity { get; set; }

    public int? unitId { get; set; }

    public int? accountId { get; set; }

    public int? dayId { get; set; }

    public DateTime? date { get; set; }

    public virtual Food? food { get; set; }

    public virtual Meal? meal { get; set; }

    public virtual UserFoodSystem? userFoodSystem { get; set; }
}
