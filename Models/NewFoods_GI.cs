using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class NewFoods_GI
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? GlycemicLoad { get; set; }

    public string? GlycemicIndex { get; set; }

    public string? gr_s { get; set; }

    public string? arabicName { get; set; }

    public string? categoryName { get; set; }
}
