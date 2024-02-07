using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupEvent
{
    public int id { get; set; }

    public string? image { get; set; }

    public string? image2 { get; set; }

    public string? image3 { get; set; }

    public int? groupId { get; set; }

    public DateTime? dateFrom { get; set; }

    public string? name { get; set; }

    public decimal? latFrom { get; set; }

    public decimal? lngFrom { get; set; }

    public string? placeFrom { get; set; }

    public string? description { get; set; }

    public int? adminId { get; set; }

    public string? gender { get; set; }

    public DateTime? date { get; set; }

    public string? day { get; set; }

    public TimeSpan? time { get; set; }

    public int? shareCount { get; set; }

    public bool? isAllowed { get; set; }

    public int? commentsCount { get; set; }

    public Guid? commentArtGuid { get; set; }

    public Guid? guid { get; set; }

    public int? commentSystemCommentsCount { get; set; }

    public virtual ICollection<GroupEventComment> GroupEventComments { get; set; } = new List<GroupEventComment>();

    public virtual Account? admin { get; set; }

    public virtual Group? group { get; set; }
}
