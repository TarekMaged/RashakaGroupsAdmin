using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_NewsList_all
{
    public int id { get; set; }

    public Guid? commentArtGuid { get; set; }

    public string? categoryName { get; set; }

    public string? title { get; set; }

    public string? urlTitle { get; set; }

    public string? brief { get; set; }

    public string? description { get; set; }

    public DateTime? date { get; set; }

    public string? image { get; set; }

    public int? categoryId { get; set; }

    public bool? allow { get; set; }

    public int? likesCount { get; set; }

    public int? totalLikesCount { get; set; }

    public int? shareCount { get; set; }

    public int? commentsCount { get; set; }

    public int? viewsCount { get; set; }

    public bool? isPinned { get; set; }

    public string? hashTags { get; set; }

    public int? pmi { get; set; }

    public int? typeId { get; set; }

    public int? order { get; set; }

    public string? language { get; set; }
}
