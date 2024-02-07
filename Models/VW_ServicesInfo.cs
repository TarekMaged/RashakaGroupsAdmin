using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_ServicesInfo
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? arabicName { get; set; }

    public int? platform { get; set; }

    public DateTime? lastOpenDate { get; set; }

    public int? serviceId { get; set; }
}
