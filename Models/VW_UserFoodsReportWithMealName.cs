using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_UserFoodsReportWithMealName
{
    public int id { get; set; }

    public int mealId { get; set; }

    public string? name { get; set; }

    public string? mealName { get; set; }

    public long? counts { get; set; }
}
