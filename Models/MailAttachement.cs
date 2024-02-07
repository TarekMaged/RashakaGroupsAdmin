using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class MailAttachement
{
    public int id { get; set; }

    public int? mailId { get; set; }

    public string? imageUrl { get; set; }

    public virtual Mail? mail { get; set; }
}
