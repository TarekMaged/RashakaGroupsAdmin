using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Country
{
    public int id { get; set; }

    public string? iso { get; set; }

    public string? latitude { get; set; }

    public string? longitude { get; set; }

    public string? name { get; set; }

    public string? mcc { get; set; }

    public int? DateDiffIphone { get; set; }

    public int? DateDiffAndroid { get; set; }

    public string? imageUrl { get; set; }
}
