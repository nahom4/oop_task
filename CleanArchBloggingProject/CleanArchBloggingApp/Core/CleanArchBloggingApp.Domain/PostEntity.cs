 public class PostEntity : BaseDomainEntity
{
        public string? Title  {set;get;} 
        public string? Content { set;get;} 
        public virtual List<CommentEntity> ListOfComments {set;get;} 
        public PostEntity()
        {
            CreatedAt =  DateTime.UtcNow;
            ListOfComments = new List<CommentEntity>();
        }
}
