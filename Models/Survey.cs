using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Survey
{
    public int id { get; set; }

    public string? question { get; set; }

    public int? userCount { get; set; }

    public DateTime? date { get; set; }

    public DateTime? expireDate { get; set; }

    public bool? isPublish { get; set; }

    public string? image { get; set; }

    public int? commentsCount { get; set; }

    public Guid? guid { get; set; }

    public Guid? commentSystemGuid { get; set; }

    public int? shareCount { get; set; }

    public string? videoUrl { get; set; }

    public string? description { get; set; }

    public string? type { get; set; }

    public string? videoId { get; set; }

    public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();
}
