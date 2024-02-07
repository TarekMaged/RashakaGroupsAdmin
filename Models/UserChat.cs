using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserChat
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public int? typeId { get; set; }

    public DateTime? startDate { get; set; }

    public DateTime? lastMessageDate { get; set; }

    public virtual ICollection<UserChatDetail> UserChatDetails { get; set; } = new List<UserChatDetail>();
}
