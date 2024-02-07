using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class User
{
    public int id { get; set; }

    public int? platform { get; set; }

    public string? iso { get; set; }

    public string? udId { get; set; }

    public DateTime? date { get; set; }

    public string? accessToken { get; set; }

    public string? city { get; set; }

    public string? deviceName { get; set; }

    public string? appVersion { get; set; }

    public Guid? guid { get; set; }

    public bool? isBlocked { get; set; }
}
