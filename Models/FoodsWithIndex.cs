using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FoodsWithIndex
{
    public int id { get; set; }

    public int? foodId { get; set; }

    public string? name { get; set; }
}
