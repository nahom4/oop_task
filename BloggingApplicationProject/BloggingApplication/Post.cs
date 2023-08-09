using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApplication
{
    public class Post
    {
        [Key]          
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId 
        {
            set;get;
        } 
        public string? Title  
        {
            set;get;
        } 
        public string? Content 
        {
            set;get;
        } 
        public DateTime? CreatedAt
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
}