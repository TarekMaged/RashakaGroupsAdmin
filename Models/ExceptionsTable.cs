using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class ExceptionsTable
{
    public int id { get; set; }

    public string? message { get; set; }

    public string? methodName { get; set; }

    public string? innerException { get; set; }

    public DateTime? date { get; set; }
}
