using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace BloggingApplication
{
    public class Driver
    {
        public static void Main()
        {
            using var dbContext = new ApplicationContext();
            dbContext.Database.EnsureCreated(); 
            Post FirstPost = new(){Title = "Awesome",Content = "This is a cool post"};
            PostManager PostManagerObj = new(dbContext);
            PostManagerObj.CreatePost(FirstPost);
            CommentManager commentManagerObj = new(dbContext);
            commentManagerObj.CreateComment(new(){Text = "this is good",PostId = 2});
            PostManagerObj.DisplayPost("Awesome");
            PostManagerObj.DisplayPostDetail("Awesome");


                 
        }
    }
}