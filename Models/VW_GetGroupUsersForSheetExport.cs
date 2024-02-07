using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_GetGroupUsersForSheetExport
{
    public int id { get; set; }

    public int? groupId { get; set; }

    public int? accountId { get; set; }

    public string? name { get; set; }

    public string? gender { get; set; }

    public string? requestStatus { get; set; }

    public DateTime? joinDate { get; set; }

    public string? iso { get; set; }

    public string? city { get; set; }

    public string? image { get; set; }

    public bool? isAdmin { get; set; }

    public int? weekStepsCount { get; set; }

    public int? monthStepsCount { get; set; }

    public int? allStepsCount { get; set; }
}
