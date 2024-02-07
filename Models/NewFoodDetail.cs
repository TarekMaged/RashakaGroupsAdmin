using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class NewFoodDetail
{
    public int id { get; set; }

    public string? Calories { get; set; }

    public string? TotalFat { get; set; }

    public string? SaturatedFat { get; set; }

    public string? TransFat { get; set; }

    public string? PolyunsaturatedFat { get; set; }

    public string? MonounsaturatedFat { get; set; }

    public string? Cholesterol { get; set; }

    public string? Sodium { get; set; }

    public string? Potassium { get; set; }

    public string? TotalCarbohydrates { get; set; }

    public string? DietaryFiber { get; set; }

    public string? Sugars { get; set; }

    public string? Protein { get; set; }

    public string? VitaminA { get; set; }

    public string? VitaminC { get; set; }

    public string? Calcium { get; set; }

    public string? Iron { get; set; }

    public int? newFoodId { get; set; }

    public int? unitId { get; set; }

    public double? quantity { get; set; }

    public int? foodsId { get; set; }

    public virtual NewFood? newFood { get; set; }
}
