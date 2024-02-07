using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class ChallengePost
{
    public int id { get; set; }

    public int? challengeId { get; set; }

    public int? accountId { get; set; }

    public string? title { get; set; }

    public string? description { get; set; }

    public string? image { get; set; }

    public DateTime? date { get; set; }

    public virtual ICollection<ChallengePostComment> ChallengePostComments { get; set; } = new List<ChallengePostComment>();

    public virtual ICollection<ChallengePostLike> ChallengePostLikes { get; set; } = new List<ChallengePostLike>();

    public virtual Challenge? challenge { get; set; }
}
