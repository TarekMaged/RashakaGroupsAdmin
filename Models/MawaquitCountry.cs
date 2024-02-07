using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class MawaquitCountry
{
    public int CountryID { get; set; }

    public string? CountryName { get; set; }

    public double? Mazhab { get; set; }

    public string? CountryIso { get; set; }

    public double? Way { get; set; }

    public double? DlSaving { get; set; }

    public double? id_server { get; set; }

    public string? CountryNameEn { get; set; }

    public double? FajrAngle { get; set; }

    public double? EshaaAngle { get; set; }

    public double? FajrOffset { get; set; }

    public double? ShrouokOffset { get; set; }

    public double? ZuhrOffset { get; set; }

    public double? AsrOffset { get; set; }

    public double? MaghrebOffset { get; set; }

    public double? EshaaOffset { get; set; }

    public virtual ICollection<ModifiedCity> ModifiedCities { get; set; } = new List<ModifiedCity>();
}
