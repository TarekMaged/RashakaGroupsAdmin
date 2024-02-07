using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Video
{
    public int id { get; set; }

    public string? title { get; set; }

    public string? url { get; set; }

    public string? image { get; set; }

    public string? youtubeId { get; set; }

    public string? type { get; set; }
}
