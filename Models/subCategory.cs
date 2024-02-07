using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class subCategory
{
    public int id { get; set; }

    public string? subCategoryName { get; set; }

    public DateTime? Date { get; set; }

    public byte[]? timeStamp { get; set; }

    public int? changeType { get; set; }

    public virtual ICollection<source> sources { get; set; } = new List<source>();
}
