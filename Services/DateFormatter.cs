using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.Services
{  
    public static class Formatter
    {
        public static string FormattedDate(this DateTime? date)
        {
            try
            {
                return date.Value.ToString("dd/MM/yyyy");
            }
            catch 
            {
                return "";
            }
        }
        public static string FormattedDate(this DateTime date)
        {
            try
            {
                return date.ToString("dd/MM/yyyy");
            }
            catch
            {
                return "";
            }
        }
        public static string FormattedNumber(this double? number)
        {
            try
            {
                return number.Value.ToString("0");                    
            }
            catch
            {
                return "0";
            }
        }
        public static string FormattedNumber(this double number)
        {
            try
            {
                return number.ToString("0");
            }
            catch
            {
                return "0";
            }
        }
        public static string FormattedNumber(this long? number)
        {
            try
            {
                return number.Value.ToString("0");
            }
            catch
            {
                return "0";
            }
        }
        public static string GetGender(this string gender)
        {
                if (gender.ToLower()=="female")
                {
                    return "أنثى";
                }
            return "ذكر";

        }
    }
}