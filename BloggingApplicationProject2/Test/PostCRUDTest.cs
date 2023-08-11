namespace Test;
using BloggingApplication;
using Microsoft.EntityFrameworkCore;

public class PostCRUDTest
{
    PostManager PostManagerInstance;
    ApplicationContext _Context;
    public PostCRUDTest()
        {   
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _Context = new ApplicationContext(options);
            PostManagerInstance = new(_Context);
        }

    [Fact] 
    public async Task CanCreatePost()
    {
        //Arrange
        Post TestPost = new() {Title = "Create",Content = "Create Content"};

        //Act
        await PostManagerInstance.CreatePost(TestPost);

        //Assert
        Post? DataPoint = await _Context.Post.FirstOrDefaultAsync(p => p.PostId == TestPost.PostId);
        Assert.NotNull(DataPoint);

    }

    [Fact]
    public async Task GetAllPosts()
    {
        //Arrange
        Post TestPost = new() { Title = "Get post",Content = "Get post Content"};
        await PostManagerInstance.CreatePost(TestPost);

        //Act
        List<Post>? DataPoint = await PostManagerInstance.GetPosts();

        //Assert
        Assert.NotEmpty(DataPoint);
    }
    
    [Fact]
    public async Task GetPostWithValidId()
    {
        //Arrange
        Post TestPost = new() { Title = "Get post",Content = "Get post Content"};
        await _Context.Post.AddAsync(TestPost);
        await _Context.SaveChangesAsync();
        //Act
        Post? DataPoint = await PostManagerInstance.DataPointExists(TestPost.PostId)!;

        //Assert
        Assert.NotNull(DataPoint);
    }

    [Fact]
    public async Task GetPostWithInValidId()
    {
        //Arrange
        Post TestPost = new() { Title = "Get post",Content = "Get post Content"};
        await PostManagerInstance.CreatePost(TestPost);

        //Act
        Post? DataPoint = await PostManagerInstance.DataPointExists(1000)!;

        //Assert
        Assert.Null(DataPoint);
    }

    [Fact]
    public async Task UpdatePost()
    {
        //Arrange
        Post TestPost = new() { Title = "Update post",Content = "post Content"};
        await PostManagerInstance.CreatePost(TestPost);
        Post PostInfo = new() {PostId = TestPost.PostId,Title = "Update post", Content = "Update Post"};
        //Act
        await PostManagerInstance.UpdatePost(TestPost,PostInfo);
        //Assert
        Post? DataPoint = await _Context.Post.FirstOrDefaultAsync(p => p.PostId == TestPost.PostId);
        Assert.NotNull(DataPoint);
        Assert.Equal(DataPoint!.Content,PostInfo.Content);
    }

    [Fact]
    public async Task DeletePost()
    {
        //Arrange
        Post TestPost = new() {Title = "Delete Post",Content = "Delete Post"};
        await PostManagerInstance.CreatePost(TestPost);

        //Act
        await PostManagerInstance.DeletePost(TestPost);

        //Assert
        Post? DataPoint = await _Context.Post.FirstOrDefaultAsync(p => p.PostId == TestPost.PostId);
        Assert.Null(DataPoint);

    }

}