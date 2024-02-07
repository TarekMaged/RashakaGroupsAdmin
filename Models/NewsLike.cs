using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class NewsLike
{
    public int id { get; set; }

    public int? newsId { get; set; }

    public int? accountId { get; set; }

    public int? likeTypeId { get; set; }

    public virtual LikeType? likeType { get; set; }

    public virtual News? news { get; set; }
}
