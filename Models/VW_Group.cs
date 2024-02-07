using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_Group
{
    public int id { get; set; }

    public string? name { get; set; }

    public int? typeId { get; set; }

    public string? image { get; set; }

    public string? coverImage { get; set; }

    public string? description { get; set; }

    public DateTime? date { get; set; }

    public string? privacy { get; set; }

    public int? acceptedMembersCount { get; set; }

    public bool? isPinned { get; set; }

    public string? country { get; set; }

    public string? city { get; set; }

    public decimal? lat { get; set; }

    public decimal? lng { get; set; }

    public string? iso { get; set; }

    public string? goal { get; set; }
}
