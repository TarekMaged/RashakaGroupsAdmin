using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.ViewModel;

namespace RashakaGroupsAdmin.Repository.Interfaces
{
    public interface IGroupPost
    {
        object AddPostComment(AddGroupPostCommentModel addGroupPostCommentModel);
        object PinnPost(int id, int groupId);
        Task<int> AddEditGroupPost(PostModel model);
        bool ShareWeekUserAsPost(string user, string steps, int groupId);
        bool DeletePost(int id);
        bool AddComment(Guid? accountGUID, int postId, string text);
        Comments GetPostComments(CommentModel model);
    }
}