using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class androidGoldPackageUser
{
    public int id { get; set; }

    public string? purchasToken { get; set; }

    public DateTime? date { get; set; }

    public string? MD5Token { get; set; }

    public Guid? accountGuid { get; set; }

    public Guid? userGuid { get; set; }

    public int? storeID { get; set; }

    public string? topic { get; set; }

    public int? paymentMethodId { get; set; }

    public virtual ICollection<androidUserPurchase> androidUserPurchases { get; set; } = new List<androidUserPurchase>();
}
