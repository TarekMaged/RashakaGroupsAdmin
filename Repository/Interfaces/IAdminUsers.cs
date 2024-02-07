namespace RashakaGroupsAdmin.Repository.Interfaces
{
    public interface IAdminUsers
    {
        int GetLoggedUserId();
        Guid? GetLoggedUserGUId();
        int? GetLoggedGroupId();

        string GetLoggedUserRole();
    }
}