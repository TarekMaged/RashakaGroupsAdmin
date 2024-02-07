using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace RashakaGroupsAdmin.ViewModel
{
    public class MealsViewModel
    {

        public int id { get; set; }
        [Required(ErrorMessage ="من فضلك أدخل النوع")]
        public string type { get; set; }
        [Required(ErrorMessage = "من فضلك أدخل الإسم")]
        public string name { get; set; }
        public int mealId { get; set; }
        public Nullable<double> time { get; set; }
        public Nullable<double> protein { get; set; }
        public Nullable<double> fat { get; set; }
        public Nullable<double> carbohydrates { get; set; }
        public Nullable<double> calories { get; set; }
        public string method { get; set; }
        public IFormFile image { get; set; }
        public MealItem item { get; set; }
        public  List<MealItem> MealItems { get; set; }
    }
    public class MealObject
    {

    }
    
    public  class MealItem
    {
        public int id { get; set; }
       
        public string quantity { get; set; }
        public string name { get; set; }
        public IFormFile itemImage { get; set; }
    }
}