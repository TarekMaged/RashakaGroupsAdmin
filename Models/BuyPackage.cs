using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class BuyPackage
{
    public int id { get; set; }

    public string? type { get; set; }

    public bool? isActive { get; set; }

    public DateTime? expireDate { get; set; }

    public double? discountPercent { get; set; }

    public double? price { get; set; }

    public bool? isNormalBuy { get; set; }

    public double? priceBefor { get; set; }

    public string? productId { get; set; }

    public string? image { get; set; }

    public string? title { get; set; }

    public string? backgroundImage { get; set; }

    public int? platform { get; set; }

    public virtual ICollection<PromoCode> PromoCodes { get; set; } = new List<PromoCode>();
}
