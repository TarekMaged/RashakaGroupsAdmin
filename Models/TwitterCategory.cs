using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class TwitterCategory
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? image { get; set; }

    public string? englishName { get; set; }

    public int? sort { get; set; }

    public string? CardColor { get; set; }

    public int? ChangeType { get; set; }

    public byte[]? timeStamp { get; set; }

    public string? language { get; set; }

    public virtual ICollection<TwitterVideo> TwitterVideos { get; set; } = new List<TwitterVideo>();

    public virtual ICollection<source> sources { get; set; } = new List<source>();
}
