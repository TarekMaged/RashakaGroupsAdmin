using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class androidUserPurchase
{
    public int id { get; set; }

    public int? purchaseTokenID { get; set; }

    public DateTime? startDate { get; set; }

    public DateTime? endDate { get; set; }

    public int? remainTicketsNo { get; set; }

    public int? packageID { get; set; }

    public int? packageType { get; set; }

    public bool? expired { get; set; }

    public bool? reward { get; set; }

    public virtual androidGoldPackageUser? purchaseToken { get; set; }
}
