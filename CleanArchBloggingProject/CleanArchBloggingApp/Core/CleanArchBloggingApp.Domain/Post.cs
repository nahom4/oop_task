 public class Post : BaseDomainEntity
{
        public string? Title  
        {
            set;get;
        } 
        public string? Content 
        {
            set;get;
        } 
        public virtual List<Comment> ListOfComments {set;get;} 
        public Post()
        {
            CreatedAt =  DateTime.UtcNow;
            ListOfComments = new List<Comment>();
        }
}
