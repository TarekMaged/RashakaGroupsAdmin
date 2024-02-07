using RashakaGroupsAdmin.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.ViewModel
{
    public class GroupMembersModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int? creatorId { get; set; }
        public string period { get; set; }
        public int page { get; set; }
        public IEnumerable<MembersModel> Memebers { get; set; }
        public List<FilterItems> NotActiveFilter { get; set; }
        public FilterItems ActiveFilter { get; set; }

    }
    public class MembersModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int Steps { get; set; }
        public double Distance { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsAdmin { get; set; }


        public static List<FilterItems> GetNotActiveFilter(string filter)
        {
            return FilterItems.filters.Where(x => x.filter != filter).ToList();
        }
        public static FilterItems GetActiveFilter(string filter)
        {
            filter = string.IsNullOrWhiteSpace(filter) ? "today" : filter;
            return FilterItems.filters.Where(x => x.filter == filter).FirstOrDefault();
        }
    }
    public class FilterItems
    {
        public string filter { get; set; }
        public string arName { get; set; }
        public static List<FilterItems> filters = new List<FilterItems> {
           new FilterItems {filter= "today" ,arName="اليوم"}
           ,new FilterItems { filter = "yesterday", arName = "أمس" }
           ,new FilterItems { filter = "week", arName = "إسبوع" }
           ,new FilterItems { filter = "month", arName = "شهر" }
           ,new FilterItems { filter = "all", arName = "الكل" }};


    }
}