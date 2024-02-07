using RashakaAdmin.Models;

namespace RashakaGroupsAdmin.Repository.Interfaces
{
    public interface INotification
    {
        string SendAfterAddingGroupPost(int id);
        string SendMainNotification(NotificationData data);
        string SendNotification(NotificationData model);
    }
}