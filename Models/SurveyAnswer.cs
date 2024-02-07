using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class SurveyAnswer
{
    public int id { get; set; }

    public string? title { get; set; }

    public int? questionId { get; set; }

    public int? userCount { get; set; }

    public DateTime? date { get; set; }

    public virtual Survey? question { get; set; }
}
