using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class PromoCode
{
    public int id { get; set; }

    public string? code { get; set; }

    public double? discountPercent { get; set; }

    public DateTime? expireDate { get; set; }

    public int? clubId { get; set; }

    public int? countOfUse { get; set; }

    public int? buyPackagesId { get; set; }

    public int? allowedNumberOfUsers { get; set; }

    public bool? allowed { get; set; }

    public string? clubImage { get; set; }

    public string? clubName { get; set; }

    public int? usageCount { get; set; }

    public virtual ICollection<UserPromoCode> UserPromoCodes { get; set; } = new List<UserPromoCode>();

    public virtual BuyPackage? buyPackages { get; set; }

    public virtual Club? club { get; set; }
}
