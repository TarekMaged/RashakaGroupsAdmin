using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Coach
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? image { get; set; }

    public string? soundName { get; set; }

    public string? type { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
