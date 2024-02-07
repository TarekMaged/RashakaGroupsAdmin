using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class GroupUserNotification
{
    public int id { get; set; }

    public string? message { get; set; }

    public DateTime? date { get; set; }

    public int? from_accountId { get; set; }

    public int? to_accountId { get; set; }

    public string? type { get; set; }

    public int? postId { get; set; }

    public int? groupId { get; set; }

    public int? commentId { get; set; }

    public bool? isRead { get; set; }

    public int? eventId { get; set; }

    public Guid? commentGuid { get; set; }

    public string? groupName { get; set; }

    public string? groupPrivacy { get; set; }

    public string? userName { get; set; }

    public string? englishMessage { get; set; }
}
