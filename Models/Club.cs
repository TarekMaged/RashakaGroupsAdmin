using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Club
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? image { get; set; }

    public virtual ICollection<PromoCode> PromoCodes { get; set; } = new List<PromoCode>();
}
