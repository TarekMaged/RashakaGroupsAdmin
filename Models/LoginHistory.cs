using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class LoginHistory
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public DateTime? logoutTime { get; set; }

    public DateTime? loginTim { get; set; }

    public int? userId { get; set; }
}
