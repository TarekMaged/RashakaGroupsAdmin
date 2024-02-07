using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupLastPost
{
    public int id { get; set; }

    public int? groupId { get; set; }

    public int? LastPostId { get; set; }

    public DateTime? lastDate { get; set; }
}
