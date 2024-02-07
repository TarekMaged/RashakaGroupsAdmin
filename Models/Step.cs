using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Step
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? Count { get; set; }

    public double? Duration { get; set; }

    public int? TypeId { get; set; }

    public double? Distance { get; set; }

    public double? Calories { get; set; }

    public int? AccountId { get; set; }

    public DateTime? Datetime { get; set; }
}
