using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class OpenFood
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? quantity { get; set; }

    public string? brands { get; set; }

    public string? categories { get; set; }

    public string? energy { get; set; }

    public string? fat { get; set; }

    public string? Saturatedfat { get; set; }

    public string? carbohydrates { get; set; }

    public string? sugars { get; set; }

    public string? fiber { get; set; }

    public string? proteins { get; set; }

    public string? salt { get; set; }

    public string? imageUrl { get; set; }

    public string? url { get; set; }

    public string? product_name { get; set; }
}
