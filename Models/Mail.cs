using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Mail
{
    public int id { get; set; }

    public string? userName { get; set; }

    public string? title { get; set; }

    public string? message { get; set; }

    public DateTime? date { get; set; }

    public bool? paidVersion { get; set; }

    public bool? isActive { get; set; }

    public int? activityRate { get; set; }

    public bool? deleted { get; set; }

    public int? parentMail { get; set; }

    public string? udId { get; set; }

    public string? receiverUdId { get; set; }

    public int? countryId { get; set; }

    public int? cityId { get; set; }

    public string? calculateWay { get; set; }

    public string? mazhab { get; set; }

    public string? timeZone { get; set; }

    public string? polarCalculateWay { get; set; }

    public string? summerTime { get; set; }

    public string? mawaquitCorrection { get; set; }

    public string? countryIso { get; set; }

    public int? lang { get; set; }

    public bool? welcomeMail { get; set; }

    public long? readCount { get; set; }

    public bool? Archived { get; set; }

    public string? gender { get; set; }

    public double? appVersion { get; set; }

    public int? platform { get; set; }

    public double? systemVersion { get; set; }

    public int? messageType { get; set; }

    public bool? repeatedMsg { get; set; }

    public string? services { get; set; }

    public bool? appFriend { get; set; }

    public virtual ICollection<MailAttachement> MailAttachements { get; set; } = new List<MailAttachement>();
}
