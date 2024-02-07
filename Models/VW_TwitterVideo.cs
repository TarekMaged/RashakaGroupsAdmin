using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_TwitterVideo
{
    public string? SourceName { get; set; }

    public string? ArticleImage { get; set; }

    public int? Followers { get; set; }

    public string? gender { get; set; }

    public string? videoGender { get; set; }

    public int? categoryId { get; set; }

    public string? thumbnail { get; set; }

    public string? description { get; set; }

    public bool? isRtl { get; set; }

    public int? CountryID { get; set; }

    public int? videoCatID { get; set; }

    public bool? isAutoPublishArticles { get; set; }

    public int? subCategoryId { get; set; }

    public string? language { get; set; }

    public long id { get; set; }

    public int? sourceId { get; set; }

    public string? image { get; set; }

    public string? ArticleCommentSystemGuid { get; set; }

    public string? title { get; set; }

    public string? details { get; set; }

    public string? galleryImages { get; set; }

    public string? Video { get; set; }

    public string? VideoID { get; set; }

    public string? Url { get; set; }

    public string? hash { get; set; }

    public DateTime? videoPublishTime { get; set; }

    public int? LikeCount { get; set; }

    public int? CommentCount { get; set; }

    public int? shareCount { get; set; }

    public bool? urgent { get; set; }

    public byte[]? timeStamp { get; set; }

    public int? readers { get; set; }

    public DateTime? activateDate { get; set; }
}
