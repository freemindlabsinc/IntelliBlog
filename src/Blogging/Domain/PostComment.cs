namespace Blogging.Domain;

public sealed class PostComment : CommentBase<int>, IAggregateRoot
{
    public PostComment(        
        int postId,
        string text,
        string commentedBy) : base(text, commentedBy)
    {
        PostId = postId; // Once-setter                
    }

    public int PostId { get; private set; } = default!;

    public IReadOnlyCollection<PostCommentLike> Likes => _likes.AsReadOnly();

    public void Like(string likedBy)
    {
        if (_likes.Any(x => x.LikedBy == likedBy)) return;

        _likes.Add(new PostCommentLike(Id, likedBy));

        //RaiseEvent(new PostCommentLiked(this, likedBy));
    }

    public void Unlike(string likedBy)
    {
        var like = _likes.FirstOrDefault(x => x.LikedBy == likedBy);

        if (like is null) return;

        _likes.Remove(like);

        //RaiseEvent(new PostCommentUnliked(this, likedBy));
    }

    private readonly List<PostCommentLike> _likes = new List<PostCommentLike>();
    // For Entity Framework
    private PostComment() : this(default, default!, default!) { }
}
