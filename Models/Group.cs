using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Group
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? image { get; set; }

    public string? coverImage { get; set; }

    public string? description { get; set; }

    public string? iso { get; set; }

    public string? country { get; set; }

    public string? city { get; set; }

    public string? type { get; set; }

    public DateTime? date { get; set; }

    public int? creatorId { get; set; }

    public int? typeId { get; set; }

    public string? sponsor { get; set; }

    public string? privacy { get; set; }

    public int? privacyId { get; set; }

    public bool? isDeleted { get; set; }

    public decimal? lat { get; set; }

    public decimal? lng { get; set; }

    public int? shareCount { get; set; }

    public string? joinQuestion { get; set; }

    public bool? isPinned { get; set; }

    public int? reportsCount { get; set; }

    public int? membersCount { get; set; }

    public int? acceptedMembersCount { get; set; }

    public int? postsCount { get; set; }

    public int? eventsCount { get; set; }

    public int? viewsCount { get; set; }

    public string? goal { get; set; }

    public int? goalValue { get; set; }

    public virtual ICollection<GroupEvent> GroupEvents { get; set; } = new List<GroupEvent>();

    public virtual ICollection<GroupPost> GroupPosts { get; set; } = new List<GroupPost>();

    public virtual ICollection<GroupReport> GroupReports { get; set; } = new List<GroupReport>();

    public virtual ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();

    public virtual Account? creator { get; set; }

    public virtual GroupType? typeNavigation { get; set; }
}
