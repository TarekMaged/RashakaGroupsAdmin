using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class UserRating
{
    public int id { get; set; }

    public int? accountId { get; set; }

    public string? text { get; set; }

    public double? rating { get; set; }

    public DateTime? date { get; set; }

    public int? userId { get; set; }

    public virtual ICollection<UserRatingReason> UserRatingReasons { get; set; } = new List<UserRatingReason>();
}
