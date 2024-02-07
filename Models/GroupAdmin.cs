using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupAdmin
{
    public int id { get; set; }

    public int? groupId { get; set; }

    public int? accountId { get; set; }

    public bool? isCreator { get; set; }

    public virtual Group? group { get; set; }
}
