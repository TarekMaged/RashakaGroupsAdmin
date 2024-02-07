using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Invitation
{
    public int id { get; set; }

    public int? accountId_from { get; set; }

    public int? accountId_to { get; set; }

    public DateTime? date { get; set; }

    public bool? isDownloadByInvitaion { get; set; }
}
