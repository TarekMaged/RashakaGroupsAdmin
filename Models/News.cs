using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class News
{
    public int id { get; set; }

    public string? title { get; set; }

    public string? description { get; set; }

    public DateTime? date { get; set; }

    public string? image { get; set; }

    public int? categoryId { get; set; }

    public bool? allow { get; set; }

    public int? shareCount { get; set; }

    public int? commentsCount { get; set; }

    public int? viewsCount { get; set; }

    public string? brief { get; set; }

    public Guid? guid { get; set; }

    public Guid? commentArtGuid { get; set; }

    public int? likesCount { get; set; }

    public int? loveCount { get; set; }

    public int? angryCount { get; set; }

    public int? wowCount { get; set; }

    public int? hahaCount { get; set; }

    public int? sadCount { get; set; }

    public int? totalLikesCount { get; set; }

    public bool? isPinned { get; set; }

    public int? order { get; set; }

    public string? hashTags { get; set; }

    public int? typeId { get; set; }

    public int? pmi { get; set; }

    public DateTime? notificationTime { get; set; }

    public int? countryId { get; set; }

    public int? keywordId { get; set; }

    public int? parentId { get; set; }

    public string? language { get; set; }

    public string? facebookPostId { get; set; }

    public string? urlTitle { get; set; }

    public virtual ICollection<FavoriteNews> FavoriteNews { get; set; } = new List<FavoriteNews>();

    public virtual ICollection<NewsComment> NewsComments { get; set; } = new List<NewsComment>();

    public virtual ICollection<NewsLike> NewsLikes { get; set; } = new List<NewsLike>();

    public virtual ICollection<NewsTranslation> NewsTranslations { get; set; } = new List<NewsTranslation>();

    public virtual NewsCategory? category { get; set; }
}
