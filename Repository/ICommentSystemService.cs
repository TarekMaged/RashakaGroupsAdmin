using RashakaAdmin.Models;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.ViewModel;

namespace RashakaGroupsAdmin.Repository
{
    public interface ICommentSystemService
    {
        object GetResponseFromCommentSyste(string url, string json);
        string getNameOfArt(string guid);
        Comments GetArticleCommentsFromCommentSystem(string commentArtGuid, string artGuid, string date);
        string deleteCommentFromCommentSystem(string? v, string guid);
        Comments getReportedCommentsFromCommentSystem(string date);
        GetReplies getReportedRepliesFromCommentSystem(string date);
        GetReplies getRepliesFromCommentSystem(string commentGuid, string accountGuid, string date);
        string unReportCommentFromCommentSystem(string commentGuid);
        string AddReplyToCommentSystem(Account account, ReplyJson ReplyJson, string text, string? accountGUID);
        AddCommentResponse AddComment(Guid? accountGUID, string text, Guid? commentArtGuid, Guid? guid, int v);
        string deleteReplyFromCommentSystem(string replyGuid);
        string unReportReplyFromCommentSystem(string replyGuid);
        string AddReplyToCommentSystem(string commentGuid, string text, string? accountGUID);
    }
}