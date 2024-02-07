using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Advertising
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? email { get; set; }

    public string? phone { get; set; }

    public string? whatsNo { get; set; }

    public string? activity { get; set; }

    public string? details { get; set; }

    public DateTime date { get; set; }
}
