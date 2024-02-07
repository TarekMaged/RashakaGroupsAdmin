using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class NewsCommentReplyLike
{
    public int id { get; set; }

    public int? replyId { get; set; }

    public int? accountId { get; set; }

    public DateTime? date { get; set; }

    public virtual Account? account { get; set; }

    public virtual NewsCommentReply idNavigation { get; set; } = null!;
}
