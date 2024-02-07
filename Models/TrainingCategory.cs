using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class TrainingCategory
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? englishName { get; set; }

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
