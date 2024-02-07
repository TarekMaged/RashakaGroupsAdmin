using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class ChatDetail
{
    public int id { get; set; }

    public int? chatId { get; set; }

    public int? senderId { get; set; }

    public string? message { get; set; }

    public DateTime? date { get; set; }

    public bool? seen { get; set; }

    public bool? seenByRashakaAdmin { get; set; }

    public string? image { get; set; }

    public string? image2 { get; set; }

    public string? image3 { get; set; }

    public virtual Chat? chat { get; set; }

    public virtual Account? sender { get; set; }
}
