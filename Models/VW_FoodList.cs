using System;
using System.Collections.Generic;

namespace RashakaGroupsAdmin.Models;

public partial class VW_FoodList
{
    public int id { get; set; }

    public string? name { get; set; }

    public int? categoryId { get; set; }

    public string? updateType { get; set; }

    public DateTime? date { get; set; }

    public int nutrientId { get; set; }

    public int? unitId { get; set; }

    public string? weight_g { get; set; }

    public string? unitName { get; set; }

    public string? englishUnitName { get; set; }

    public string? phosphor_mg { get; set; }

    public string? potassium_mg { get; set; }

    public string? saturatedFat_g { get; set; }

    public string? sugar_g { get; set; }

    public string? vitaminB_mg { get; set; }

    public string? zinc_mg { get; set; }

    public string protein_g { get; set; } = null!;

    public string? proteinBlocks { get; set; }

    public string? fat_g { get; set; }

    public string? calories_g { get; set; }

    public string? carbohydrates_g { get; set; }

    public string? dietaryFiber_g { get; set; }

    public string? calcium_mg { get; set; }

    public string? iron_mg { get; set; }

    public string? sodium_mg { get; set; }

    public string? vitaminC_mg { get; set; }

    public string? vitaminA_mg { get; set; }

    public string? vitaminD_mg { get; set; }

    public string? cholesterol_mg { get; set; }

    public string? transFats_g { get; set; }

    public string? densityPerUnit_g { get; set; }

    public string? energy_kg { get; set; }

    public string? carbohydratesBlocks { get; set; }

    public string? magnasium_mg { get; set; }

    public string? thiamine_mg { get; set; }

    public string? riboflavin_mg { get; set; }

    public string? niacinne_mg { get; set; }

    public string? folatendfe_mg { get; set; }

    public string? fatblocks { get; set; }

    public string? quantity { get; set; }

    public string? PantothenicAcid_mg { get; set; }

    public string? vitaminB6_mg { get; set; }

    public string? folicAcid_mcg { get; set; }

    public string? VitaminB12_mg { get; set; }

    public string? vitaminE_mg { get; set; }

    public string? vitaminK_mg { get; set; }

    public string? mopper_mg { get; set; }

    public string? manganese_mg { get; set; }

    public string? selenium_mcg { get; set; }

    public string? fluorides_mcg { get; set; }

    public string? copper_mg { get; set; }

    public string? language { get; set; }
}
