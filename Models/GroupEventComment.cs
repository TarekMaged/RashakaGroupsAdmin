using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupEventComment
{
    public int id { get; set; }

    public int? groupEventId { get; set; }

    public string? comment { get; set; }

    public int? accountId { get; set; }

    public int? groupEventUserId { get; set; }

    public DateTime? date { get; set; }

    public int? reportsCount { get; set; }

    public virtual Account? account { get; set; }

    public virtual GroupEvent? groupEvent { get; set; }
}
