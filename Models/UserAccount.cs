using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserAccount
{
    public int id { get; set; }

    public int? userId { get; set; }

    public int? accountId { get; set; }

    public bool? isLogedIn { get; set; }

    public virtual Account? account { get; set; }

    public virtual User? user { get; set; }
}
