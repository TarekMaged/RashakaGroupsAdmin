using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class RatingReason
{
    public int id { get; set; }

    public string? reason { get; set; }

    public virtual ICollection<UserRatingReason> UserRatingReasons { get; set; } = new List<UserRatingReason>();
}
