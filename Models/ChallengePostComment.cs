using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class ChallengePostComment
{
    public int id { get; set; }

    public int? challengePostId { get; set; }

    public string? comment { get; set; }

    public int? accountId { get; set; }

    public int? challengeUserId { get; set; }

    public virtual ChallengePost? challengePost { get; set; }

    public virtual ChallengeUser? challengeUser { get; set; }
}
