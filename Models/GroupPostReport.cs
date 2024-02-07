using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupPostReport
{
    public int id { get; set; }

    public int? groupPostId { get; set; }

    public int? accountId { get; set; }

    public DateTime? date { get; set; }

    public virtual Account? account { get; set; }

    public virtual GroupPost? groupPost { get; set; }
}
