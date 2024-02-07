using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_NearestGroup
{
    public int id { get; set; }

    public bool? isDeleted { get; set; }

    public string? iso { get; set; }

    public string? name { get; set; }

    public int? typeId { get; set; }

    public string? privacy { get; set; }

    public string? image { get; set; }

    public decimal? lat { get; set; }

    public decimal? lng { get; set; }

    public int? members { get; set; }
}
