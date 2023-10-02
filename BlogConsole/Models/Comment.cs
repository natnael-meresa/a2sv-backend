public class Comment
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string Text { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public Post Post { get; set; } = null!;
}