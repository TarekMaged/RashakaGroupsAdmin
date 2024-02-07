using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupEventUser
{
    public int id { get; set; }

    public int? groupEventId { get; set; }

    public int? accountId { get; set; }

    public DateTime? joinDate { get; set; }

    public virtual ICollection<GroupEventComment> GroupEventComments { get; set; } = new List<GroupEventComment>();

    public virtual Account? account { get; set; }

    public virtual GroupEvent? groupEvent { get; set; }
}
