public class Comment : BaseDomainEntity
{   
    public int PostId 
    {
        get;set;
    }     
    public string? Text 
    {
        get;set;
    }   
    public virtual Post? Post { get; set; }

    public Comment()
    {
        CreatedAt = DateTime.UtcNow;
    }
}