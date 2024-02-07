using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Chat
{
    public int id { get; set; }

    public int? accountId_1 { get; set; }

    public int? accountId_2 { get; set; }

    public int? groupId { get; set; }

    public DateTime? lastMessageDate { get; set; }

    public int? typeId { get; set; }

    public bool isClosed { get; set; }

    public string? closeReason { get; set; }

    public bool? isProblemSolved { get; set; }

    public int? cancelReasonId { get; set; }

    public virtual ICollection<ChatDetail> ChatDetails { get; set; } = new List<ChatDetail>();

    public virtual Account? accountId_1Navigation { get; set; }

    public virtual Account? accountId_2Navigation { get; set; }

    public virtual BuyPackagesCancelReason? cancelReason { get; set; }

    public virtual Group? group { get; set; }
}
