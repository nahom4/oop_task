using BloggingApplication;

class UserInterface
{
    readonly PostManager PostManagerInstance;
    readonly CommentManager CommentManagerInstance;
    public UserInterface(PostManager postManager, CommentManager commentManager)
    {
        PostManagerInstance = postManager;
        CommentManagerInstance = commentManager;   
    }
    public async Task WelcomePage()
    {
        while(true)
        {

            Console.WriteLine("Welcome to the Blogging App");
            Console.WriteLine("You Can Post,Comment and View. Enter Exit to exit the App");
            string? Option = Console.ReadLine()!.Trim().ToLower();
            if (Option == "exit")
            {
                break;
            }
            switch(Option)
            {
                case "post":
                await PostPage();
                break;

                case "comment":
                await CommentPage();
                break;

                case "view":
                ViewPage();
                break;   
            }
        }
    }
    private  void ViewPage()
    {
        Console.WriteLine("postTitle : ");
        string Title = Console.ReadLine()!;

        if (Title == null)
        {
            ViewPage();
        }
        PostManagerInstance.DisplayPost(Title!);
        Console.WriteLine("Do you want to see detail Yes/No");
        string answer = Console.ReadLine()!.Trim().ToLower();

        if(answer == "yes") 
        {   
            PostManagerInstance.DisplayPostDetail(Title!);
        } 
    }

    private async Task  PostPage()
    {
        Console.WriteLine("You can Create,Update,Delete");
        
        string Option = Console.ReadLine()!.Trim();

        switch(Option)
        {
            case "create":
            await CreatePost();
            break;

            case "update":
            await UpdatePost();
            break;

            case "delete":
            await DeletePost();
            break;
        }
        
    }
    private async Task  CommentPage()
    {
        Console.WriteLine("You can Create,Update,Delete");
        
        string Option = Console.ReadLine()!.Trim();

        switch(Option)
        {
            case "create":
            await CreateComment();
            break;

            case "update":
            await UpdateComment();
            break;

            case "delete":
            await DeleteComment();
            break;
        }
        
    }

    private async Task DeletePost()
    {
      Console.WriteLine("PostId :");

      if(! int.TryParse(Console.ReadLine(),out int Id))  
      {
        await DeletePost();
      }

      await PostManagerInstance.DeletePost(Id);
    }

    private async Task UpdatePost()
    {
        Console.WriteLine("Title : ");
        string Title = Console.ReadLine()!;

        Console.WriteLine("New Content : ");
        string Content = Console.ReadLine()!;

        if (Title == null || Content == null)
        {
            await UpdatePost();
        }
        await PostManagerInstance.UpdatePost(new Post() {Title = Title, Content = Content});
    }

    private async Task CreatePost()
    {
        Console.WriteLine("Title : ");
        string Title = Console.ReadLine()!;

        Console.WriteLine("Content : ");
        string Content = Console.ReadLine()!;

        if (Title == null || Content == null)
        {
            await CreatePost();
        }
        await PostManagerInstance.CreatePost(new Post() {Title = Title, Content = Content});
        

    }
    private async Task DeleteComment()
    {
      Console.WriteLine("CommentId :");

      if(! int.TryParse(Console.ReadLine(),out int Id))  
      {
        await DeleteComment();
      }

      await CommentManagerInstance.DeleteComment(Id);
    }

    private async Task UpdateComment()
    {
        Console.WriteLine("CommentId :");
        if (!int.TryParse(Console.ReadLine(),out int CommentId))
        {
            await UpdateComment();   
        }
        
        Console.WriteLine("Text :");
        string Text = Console.ReadLine()!;

        if (Text == null)
        {
            await UpdateComment();
        }
        await CommentManagerInstance.UpdateComment(new Comment() {Text = Text, CommentId = CommentId });
    }

    private async Task CreateComment()
    {
        Console.WriteLine("Text : ");
        string Text = Console.ReadLine()!;
        Console.WriteLine("PostId :");
        if (!int.TryParse(Console.ReadLine(),out int PostId))
        {
            await CreateComment();   
        }

        if (Text == null)
        {
            await CreateComment();
        }
        await CommentManagerInstance.CreateComment(new Comment() {Text = Text, PostId = PostId });

    }
}