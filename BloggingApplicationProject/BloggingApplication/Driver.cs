using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace BloggingApplication
{
    public class Driver
    {
        public static async Task Main()
        {
            using var dbContext = new ApplicationContext();
            dbContext.Database.EnsureCreated(); 
            Post FirstPost = new(){Title = "Work",Content = "This is a cool post"};
            PostManager PostManagerObj = new(dbContext);
            await PostManagerObj.CreatePost(FirstPost);
            CommentManager commentManagerObj = new(dbContext);
            await commentManagerObj.CreateComment(new(){Text = "this is good",PostId = 6});
            PostManagerObj.DisplayPost("Work");
            PostManagerObj.DisplayPostDetail("Work");
            UserInterface Ui = new(PostManagerObj,commentManagerObj);
            PostManagerObj.DisplayPostDetail("cool app");
            
            await Ui.WelcomePage();
                 
        }
    }
}