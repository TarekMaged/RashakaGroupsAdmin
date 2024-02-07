using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupPostComment
{
    public int id { get; set; }

    public int? groupPostId { get; set; }

    public string? comment { get; set; }

    public int? accountId { get; set; }

    public DateTime? date { get; set; }

    public int? reportsCount { get; set; }

    public virtual Account? account { get; set; }

    public virtual GroupPost? groupPost { get; set; }
}
