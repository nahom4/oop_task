public class CommentEntity : BaseDomainEntity
{   
    public int PostId { get;set; }     
    public string? Text {  get;set; }   
    public virtual PostEntity? Post { get; set; }
    public CommentEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }
}