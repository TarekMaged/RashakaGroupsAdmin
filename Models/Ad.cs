using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Ad
{
    public int id { get; set; }

    public string? name { get; set; }

    public DateTime? startDate { get; set; }

    public DateTime? endDate { get; set; }

    public string? url { get; set; }

    public string? advertiserName { get; set; }

    public string? image { get; set; }

    public bool? allow { get; set; }

    public string? tags { get; set; }
}
