using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupType
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? englishName { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
