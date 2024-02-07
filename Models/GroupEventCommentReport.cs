using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupEventCommentReport
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public int? eventCommentId { get; set; }

    public DateTime? date { get; set; }

    public virtual Account? account { get; set; }

    public virtual GroupEventComment? eventComment { get; set; }
}
