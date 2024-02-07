using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class AppVersion
{
    public int id { get; set; }

    public string? platform { get; set; }

    public string? versionNo { get; set; }

    public string? status { get; set; }

    public string? action { get; set; }
}
