using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace RashakaGroupsAdmin.ViewComponent
{
    //public class SideMenuViewComponent : ViewComponent
    //{
    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {

    //        if (groups != null)
    //        {
    //            return PartialView(groups);
    //        }
    //        //groups = repo.iRashaka<GroupUser>().GetAll(X => x.accountId == accountId && X.isAdmin == true).Select(x => x.Group).ToList();
    //        groups = groupService.GetUserGroups(accountId);
    //        return PartialView("MenuGroups", groups.ToList());
    //    }
    //}
}
