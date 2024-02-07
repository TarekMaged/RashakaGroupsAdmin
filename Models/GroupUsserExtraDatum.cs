using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupUsserExtraDatum
{
    public int id { get; set; }

    public string? fullName { get; set; }

    public string? email { get; set; }

    public string? mobile { get; set; }

    public double? weight { get; set; }

    public double? height { get; set; }

    public string? country { get; set; }

    public int? groupId { get; set; }

    public DateTime? date { get; set; }

    public int? accountId { get; set; }
}
