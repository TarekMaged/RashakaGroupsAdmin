using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class ApiLog
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public string? api { get; set; }

    public DateTime? date { get; set; }

    public string? data { get; set; }
}
