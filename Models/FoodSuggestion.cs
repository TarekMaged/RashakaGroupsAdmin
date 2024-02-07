using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class FoodSuggestion
{
    public int id { get; set; }

    public string? foodName { get; set; }

    public int? accountId { get; set; }

    public string? country { get; set; }

    public bool? deleted { get; set; }

    public string? deviceToken { get; set; }

    public string? foodImageUrl { get; set; }

    public DateTime? date { get; set; }

    public bool? isConfirmed { get; set; }
}
