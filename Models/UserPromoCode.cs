using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserPromoCode
{
    public int id { get; set; }

    public int? promoCodeId { get; set; }

    public int? accountId { get; set; }

    public int? userId { get; set; }

    public DateTime? date { get; set; }

    public virtual Account? account { get; set; }

    public virtual PromoCode? promoCode { get; set; }

    public virtual User? user { get; set; }
}
