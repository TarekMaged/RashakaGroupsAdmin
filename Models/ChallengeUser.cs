using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class ChallengeUser
{
    public int id { get; set; }

    public int? chalengeId { get; set; }

    public int? accountId { get; set; }

    public bool? isAllow { get; set; }

    public string? distance { get; set; }

    public DateTime? joinDate { get; set; }

    public double? stepsCount { get; set; }

    public string? period { get; set; }

    public virtual ICollection<ChallengePostComment> ChallengePostComments { get; set; } = new List<ChallengePostComment>();

    public virtual ICollection<ChallengePostLike> ChallengePostLikes { get; set; } = new List<ChallengePostLike>();

    public virtual Challenge? chalenge { get; set; }
}
