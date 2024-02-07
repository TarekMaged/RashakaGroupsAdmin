using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class NewsComment
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public string? comment { get; set; }

    public DateTime? date { get; set; }

    public int? reportsCount { get; set; }

    public int? newsId { get; set; }

    public virtual ICollection<NewsCommentReply> NewsCommentReplies { get; set; } = new List<NewsCommentReply>();

    public virtual Account? account { get; set; }

    public virtual News? news { get; set; }
}
