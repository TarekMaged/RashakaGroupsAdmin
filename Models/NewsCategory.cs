using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class NewsCategory
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? image { get; set; }

    public string? englishName { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();

    public virtual ICollection<NewsTranslation> NewsTranslations { get; set; } = new List<NewsTranslation>();
}
