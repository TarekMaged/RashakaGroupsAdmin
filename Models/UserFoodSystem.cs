using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserFoodSystem
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public int? foodSystemId { get; set; }

    public int? healthStatusId { get; set; }

    public int? FoodSystemTypeId { get; set; }

    public int? dietId { get; set; }

    public int? calories { get; set; }

    public DateTime? date { get; set; }

    public virtual ICollection<UserFoodSystemDetail> UserFoodSystemDetails { get; set; } = new List<UserFoodSystemDetail>();
}
