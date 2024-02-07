using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_PublicGroupsEvent
{
    public int id { get; set; }

    public int? groupId { get; set; }

    public string? groupName { get; set; }

    public string? placeFrom { get; set; }

    public DateTime? dateFrom { get; set; }

    public TimeSpan? time { get; set; }

    public string? name { get; set; }

    public string? description { get; set; }

    public int? shareCount { get; set; }

    public int? typeId { get; set; }

    public string? image { get; set; }
}
