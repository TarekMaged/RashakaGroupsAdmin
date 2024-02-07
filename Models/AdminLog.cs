using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class AdminLog
{
    public int id { get; set; }

    public DateTime? date { get; set; }

    public int? userId { get; set; }

    public string? _event { get; set; }

    public string? type { get; set; }

    public int? itemId { get; set; }

    public string? userName { get; set; }

    public string? url { get; set; }
}
