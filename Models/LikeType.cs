using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class LikeType
{
    public int id { get; set; }

    public string? EmojiType { get; set; }

    public virtual ICollection<NewsLike> NewsLikes { get; set; } = new List<NewsLike>();
}
