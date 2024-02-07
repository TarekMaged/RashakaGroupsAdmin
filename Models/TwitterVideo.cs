using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class TwitterVideo
{
    public long id { get; set; }

    public string? title { get; set; }

    public string? apprev { get; set; }

    public string? image { get; set; }

    public string? Url { get; set; }

    public string? details { get; set; }

    public DateTime? date { get; set; }

    public int? sourceId { get; set; }

    public bool? deleted { get; set; }

    public bool? allow { get; set; }

    public string? hash { get; set; }

    public bool? parsed { get; set; }

    public bool? urgent { get; set; }

    public byte[]? timeStamp { get; set; }

    public int? Duration { get; set; }

    public string? Video { get; set; }

    public string? htmlDetails { get; set; }

    public string? galleryImages { get; set; }

    public string? VideoID { get; set; }

    public DateTime? matchTime { get; set; }

    public string? ArticleCommentSystemGuid { get; set; }

    public Guid? Guid { get; set; }

    public int? CountryID { get; set; }

    public int? CategoryID { get; set; }

    public int? readers { get; set; }

    public int? shareCount { get; set; }

    public DateTime? activateDate { get; set; }

    public int? CommentCount { get; set; }

    public int? LikeCount { get; set; }

    public int? videoTypeId { get; set; }

    public bool? isPublished { get; set; }

    public DateTime? videoPublishTime { get; set; }

    public string? englishTitle { get; set; }

    public int? BtolatLeaguesId { get; set; }

    public int? BtolatHomeTeamId { get; set; }

    public int? BtolatAwayTeamId { get; set; }

    public bool? isWorldCup { get; set; }

    public string? gender { get; set; }

    public virtual TwitterCategory? Category { get; set; }

    public virtual source? source { get; set; }
}
