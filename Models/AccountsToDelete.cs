using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class AccountsToDelete
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public Guid? guid { get; set; }

    public DateTime? date { get; set; }

    public string? email { get; set; }

    public string? status { get; set; }

    public string? reason { get; set; }
}
