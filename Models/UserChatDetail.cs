using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserChatDetail
{
    public int id { get; set; }

    public int? chatId { get; set; }

    public int? senderId { get; set; }

    public string? message { get; set; }

    public DateTime? date { get; set; }

    public bool? seen { get; set; }

    public bool? seenByRashakaAdmin { get; set; }

    public virtual UserChat? chat { get; set; }
}
