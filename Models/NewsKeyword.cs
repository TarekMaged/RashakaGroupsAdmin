using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class NewsKeyword
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? engishName { get; set; }

    public int? usageCount { get; set; }
}
