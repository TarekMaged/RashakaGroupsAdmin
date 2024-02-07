using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class SiteKey
{
    public int id { get; set; }

    public string? keys { get; set; }

    public int? SourceID { get; set; }

    public string? titleKey { get; set; }

    public string? apprevKey { get; set; }

    public string? imageKey { get; set; }

    public string? detailKey { get; set; }

    public string? galleryKey { get; set; }

    public string? VideoKey { get; set; }

    public string? wordsToRemove { get; set; }

    public string? imageAttr { get; set; }

    public string? matchTime { get; set; }

    public virtual source? Source { get; set; }
}
