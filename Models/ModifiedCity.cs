using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class ModifiedCity
{
    public int CityID { get; set; }

    public string? CityName { get; set; }

    public double? CityLatitude { get; set; }

    public double? CityLongitude { get; set; }

    public double? CityZone { get; set; }

    public int? CountryID { get; set; }

    public string? CityNameEn { get; set; }

    public double? id_server { get; set; }

    public string? CountryIso { get; set; }

    public double? HighLatitudeWay { get; set; }

    public double? isCityEnteredByUser { get; set; }

    public virtual MawaquitCountry? Country { get; set; }
}
