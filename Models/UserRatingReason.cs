using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserRatingReason
{
    public int id { get; set; }

    public int? userRatingId { get; set; }

    public int? ratingReasonsId { get; set; }

    public DateTime? date { get; set; }

    public virtual RatingReason? ratingReasons { get; set; }

    public virtual UserRating? userRating { get; set; }
}
