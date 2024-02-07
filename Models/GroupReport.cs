using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupReport
{
    public int id { get; set; }

    public int? groupId { get; set; }

    public int? accountId { get; set; }

    public DateTime? date { get; set; }

    public virtual Account? account { get; set; }

    public virtual Group? group { get; set; }
}
