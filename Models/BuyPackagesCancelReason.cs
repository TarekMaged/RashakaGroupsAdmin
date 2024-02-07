using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class BuyPackagesCancelReason
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? englishName { get; set; }

    public string? url { get; set; }

    public string? response { get; set; }

    public string? englishResponse { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual ICollection<UsersBuyPackage> UsersBuyPackages { get; set; } = new List<UsersBuyPackage>();
}
