using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FavoriteNews
{
    public int id { get; set; }

    public int? newsId { get; set; }

    public int? accountId { get; set; }

    public DateTime? date { get; set; }

    public virtual Account? account { get; set; }

    public virtual News? news { get; set; }
}
