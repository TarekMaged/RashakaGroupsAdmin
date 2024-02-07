using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Challenge
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? image { get; set; }

    public string? type { get; set; }

    public DateTime? startDate { get; set; }

    public DateTime? endDate { get; set; }

    public string? country { get; set; }

    public string? city { get; set; }

    public string? description { get; set; }

    public string? sponsoer { get; set; }

    public bool? isWalking { get; set; }

    public string? prize { get; set; }

    public int? creatorId { get; set; }

    public virtual ICollection<ChallengePost> ChallengePosts { get; set; } = new List<ChallengePost>();

    public virtual ICollection<ChallengeUser> ChallengeUsers { get; set; } = new List<ChallengeUser>();
}
