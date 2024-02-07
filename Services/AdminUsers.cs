using RashakaGroupsAdmin.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RashakaGroupsAdmin.Models
{
    public class AdminUsers : IAdminUsers
    {
        static IWebHostEnvironment Environment;
        readonly IHttpContextAccessor _httpContextAccessor;
        public AdminUsers(IWebHostEnvironment _environment, IHttpContextAccessor httpContextAccessor)
        {
            Environment = _environment;
            _httpContextAccessor = httpContextAccessor;
        }
        public int GetLoggedUserId()
        {
            try
            {
                string[] data = _httpContextAccessor.HttpContext.User.Identity.Name.Split('|');
                return Convert.ToInt32(data[0]);
            }
            catch
            {
                return 0;
            }
        }
        public Guid? GetLoggedUserGUId()
        {
            try
            {
                string[] data = _httpContextAccessor.HttpContext.User.Identity.Name.Split('|');
                return  new Guid(data[5]);
            }
            catch
            {
                return null;
            }
        }
        public int? GetLoggedGroupId()
        {
            try
            {
                string[] data = _httpContextAccessor.HttpContext.User.Identity.Name.Split('|');
                //data.Length > 3 ? data[3] : ""
                return Convert.ToInt32(data[3]);
            }
            catch
            {
                return null;
            }
        }

        public string GetLoggedUserRole()
        {
            try
            {
                string[] data = _httpContextAccessor.HttpContext.User.Identity.Name.Split('|');
                return data[2];
            }
            catch
            {
                return "";
            }

        }
    }
}