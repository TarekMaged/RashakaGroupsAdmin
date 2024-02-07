using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserFavoritFood
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public int? foodId { get; set; }

    public virtual Account? account { get; set; }

    public virtual Food? food { get; set; }
}
