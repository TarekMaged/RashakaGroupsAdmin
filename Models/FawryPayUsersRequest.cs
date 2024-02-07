using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FawryPayUsersRequest
{
    public int id { get; set; }

    public string? email { get; set; }

    public string? paymentMethod { get; set; }

    public string? mobile { get; set; }

    public decimal? amount { get; set; }

    public Guid? accountGuid { get; set; }

    public Guid? userGuid { get; set; }

    public string? packageId { get; set; }

    public long? referenceNumber { get; set; }

    public DateTime? date { get; set; }
}
