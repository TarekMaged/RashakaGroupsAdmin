using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Groups_Report
{
    public string? groupId { get; set; }

    public string? groupName { get; set; }

    public string? Owner_Name { get; set; }

    public string? owner_email { get; set; }

    public string? total_posts { get; set; }

    public string? week_posts { get; set; }

    public string? month_posts { get; set; }

    public string? week_users { get; set; }

    public string? month_users { get; set; }

    public string? total_users { get; set; }

    public string? Column_10 { get; set; }
}
