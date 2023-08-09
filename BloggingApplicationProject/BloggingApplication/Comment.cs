using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApplication
{
    public class Comment
    {
        public int CommentId 
        {
            get;set;
        }     
        public int PostId 
        {
            get;set;
        }     
        public string? Text 
        {
            get;set;
        }   
        public DateTime CreatedAt 
        {
            get;set;
        }   

        public virtual Post? Post { get; set; }

        public Comment()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}