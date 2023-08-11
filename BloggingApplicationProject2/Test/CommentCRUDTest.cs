namespace Test;
using BloggingApplication;
using Microsoft.EntityFrameworkCore;

public class CommentCRUDTest
{
    CommentManager CommentManagerInstance;
    ApplicationContext _Context;
    public CommentCRUDTest()
        {   
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _Context = new ApplicationContext(options);
            CommentManagerInstance = new(_Context);
        }
    [Fact] 
    public async Task CanCreateComment()
    {
        //Arrange
        Comment TestComment = new() {Text = "Create"};

        //Act
        await CommentManagerInstance.CreateComment(TestComment);

        //Assert
        Comment? DataPoint = await _Context.Comment.FirstOrDefaultAsync(p => p.CommentId == TestComment.CommentId);
        Assert.NotNull(DataPoint);

    }

    [Fact]
    public async Task GetAllComments()
    {
        //Arrange
        Comment TestComment = new() { Text = "Get Comment"};
        await CommentManagerInstance.CreateComment(TestComment);

        //Act
        List<Comment>? DataPoint = await CommentManagerInstance.GetComments();

        //Assert
        Assert.NotEmpty(DataPoint);
    }
 
    [Fact]
    public async Task GetCommentWithValidId()
    {
        //Arrange
        Comment TestComment = new() { Text = "Get Comment"};
        await CommentManagerInstance.CreateComment(TestComment);

        //Act
        Comment? DataPoint = await CommentManagerInstance.DataPointExists(TestComment.CommentId)!;

        //Assert
        Assert.NotNull(DataPoint);
    }
    [Fact]
    public async Task GetCommentWithInValidId()
    {
        //Arrange
        Comment TestComment = new() { Text = "Get Comment"};
        await CommentManagerInstance.CreateComment(TestComment);

        //Act
        Comment? DataPoint = await CommentManagerInstance.DataPointExists(1000)!;

        //Assert
        Assert.Null(DataPoint);
    }

    [Fact]
    public async Task UpdateComment()
    {
        //Arrange
        Comment TestComment = new() { Text = "Comment"};
        await CommentManagerInstance.CreateComment(TestComment);
        Comment CommentInfo = new() {CommentId = TestComment.CommentId,Text = "Update Comment"};
        //Act
        await CommentManagerInstance.UpdateComment(TestComment,CommentInfo);
        //Assert
        Comment? DataPoint = await _Context.Comment.FirstOrDefaultAsync(p => p.CommentId == TestComment.CommentId);
        Assert.NotNull(DataPoint);
        Assert.Equal(DataPoint!.Text,CommentInfo.Text);
    }

    [Fact]
    public async Task DeleteComment()
    {
        //Arrange
        Comment TestComment = new() {Text = "Delete Comment"};
        await CommentManagerInstance.CreateComment(TestComment);

        //Act
        await CommentManagerInstance.DeleteComment(TestComment);

        //Assert
        Comment? DataPoint = await _Context.Comment.FirstOrDefaultAsync(p => p.CommentId == TestComment.CommentId);
        Assert.Null(DataPoint);

    }

}