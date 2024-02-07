using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UsersBuyPackage
{
    public int id { get; set; }

    public DateTime? buyDate { get; set; }

    public int? accountId { get; set; }

    public int? period { get; set; }

    public string? type { get; set; }

    public bool? isCanceled { get; set; }

    public DateTime? cancelDate { get; set; }

    public string? cancelReason { get; set; }

    public DateTime? expiryDate { get; set; }

    public int? cancelReasonId { get; set; }

    public virtual Account? account { get; set; }

    public virtual BuyPackagesCancelReason? cancelReasonNavigation { get; set; }
}
