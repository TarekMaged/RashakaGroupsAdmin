namespace RashakaGroupsAdmin.ViewModel
{
    public class CommentModel
    {
        public int id { get; set; }
        public string commentArtGuid { get; set; }
        public string artGuid { get; set; }
        public string date { get; set; }
    }
    public class Reply
    {
        public string guid { get; set; }
        public string text { get; set; }
        public string reason { get; set; }
        public string reasonText { get; set; }
        public string commentArtGuid { get; set; }
        public string date { get; set; }
        public int likeCount { get; set; }
        public string accountGuid { get; set; }
        public string userName { get; set; }
        public string image { get; set; }
        public bool isLike { get; set; }

    }

    public class CommentSystem
    {
        public string guid { get; set; }

        public string text { get; set; }
        public string reason { get; set; }
        public string reasonText { get; set; }
        public string ArtName { get; set; }
        public string commentArtGuid { get; set; }
        public string date { get; set; }
        public int likeCount { get; set; }
        public int replyCount { get; set; }
        public string accountGuid { get; set; }
        public string userName { get; set; }
        public string image { get; set; }
        public bool isLike { get; set; }
        public List<Reply> replies { get; set; }

    }

    public class Comments
    {
        public int postId { get; set; }
        public int groupId { get; set; }
        public DateTime timeZone { get; set; }
        public List<CommentSystem> comments { get; set; }
        public Guid? commentArtGuid { get; set; }
        public string description { get; set; }
        public string accountName { get; set; }
        public string profileImage { get; set; }
        public string artGuid { get; set; }
        public string date { get; set; }
    }
    public class GetReplies
    {
        public string commentGuid { get; set; }
        public DateTime timeZone { get; set; }
        public List<Reply> replies { get; set; }
    }

}
