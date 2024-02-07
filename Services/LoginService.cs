using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository.Interfaces;
using System.Security.Claims;

namespace RashakaGroupsAdmin.Services
{
    public class LoginService : ILogin
    {
        IRashakaUniteOfWork repo;
        readonly IHttpContextAccessor _httpContextAccessor;
        public LoginService(IHttpContextAccessor httpContextAccessor, IRashakaUniteOfWork repo)
        {
            _httpContextAccessor = httpContextAccessor;
            this.repo = repo;
        }
        public bool Login(Login adminData)
        {
            Login item = repo.iRashaka<Login>().GetByIncluding(a => a.accountId > 0 && a.userName.ToLower() == adminData.userName.ToLower() && a.password == adminData.password, "roleNavigation");
            if (adminData != null)
            {
                Account account = repo.iRashaka<Account>().Find(item.accountId);
                string groupId = item.groupId;
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, item.accountId + "|" + adminData.userName + "|" + item.roleNavigation.name + "|" + item.groupId + "|" + ImagesSevice.GetProfileImageUrl(account.image) + "|" + account.guid));
                claims.Add(new Claim(ClaimTypes.Role, "adminGroups"));
                var AdminIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                //var identity = new ClaimsIdentity(claims,
                //      CookieAuthenticationDefaults.AuthenticationScheme);

                var claimIdentity = new ClaimsIdentity(claims, "id card");
                var claimPrinciple = new ClaimsPrincipal(claimIdentity);
                var authenticationProperty = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                _httpContextAccessor.HttpContext.SignInAsync(claimPrinciple, authenticationProperty);
                return true;
            }
            return false; ;
        }
      
    }

}