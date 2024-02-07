using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_NewGroup
{
    public int id { get; set; }

    public DateTime? date { get; set; }

    public string? name { get; set; }

    public int? typeId { get; set; }

    public string? image { get; set; }

    public string? description { get; set; }

    public string? privacy { get; set; }

    public int? members { get; set; }
}
