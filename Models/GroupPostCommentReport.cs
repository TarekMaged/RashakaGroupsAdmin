using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupPostCommentReport
{
    public int Id { get; set; }

    public int? PostCommentId { get; set; }

    public int? AccountId { get; set; }

    public DateTime? Date { get; set; }
}
