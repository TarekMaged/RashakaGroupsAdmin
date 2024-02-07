using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class NewsCommentReply
{
    public int id { get; set; }

    public int? commentId { get; set; }

    public string? reply { get; set; }

    public int? likesCount { get; set; }

    public DateTime? date { get; set; }

    public virtual NewsCommentReplyLike? NewsCommentReplyLike { get; set; }

    public virtual NewsComment? comment { get; set; }
}
