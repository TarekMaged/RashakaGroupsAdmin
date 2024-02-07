using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class Training
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? videoName { get; set; }

    public int? level { get; set; }

    public string? type { get; set; }

    public string? bodyArea { get; set; }

    public string? bodyAreaEnglishName { get; set; }

    public double? duration { get; set; }

    public int? count { get; set; }

    public string? tools { get; set; }

    public string? description { get; set; }

    public string? place { get; set; }

    public string? gender { get; set; }

    public int? trainingNumber { get; set; }

    public string? imageName { get; set; }

    public string? videoUrl { get; set; }

    public int? categoryId { get; set; }

    public string? language { get; set; }

    public int? parentId { get; set; }

    public virtual ICollection<Training> Inverseparent { get; set; } = new List<Training>();

    public virtual ICollection<TrainingPlanDetail> TrainingPlanDetails { get; set; } = new List<TrainingPlanDetail>();

    public virtual ICollection<UserTraining> UserTrainings { get; set; } = new List<UserTraining>();

    public virtual TrainingCategory? category { get; set; }

    public virtual Training? parent { get; set; }
}
