using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BloggingApplication
{
    public class CommentOpperationTest
    {
        readonly ApplicationContext _Context;
        readonly CommentManager CommentManagerInstance;
        
        public CommentOpperationTest()
        {   
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _Context = new ApplicationContext(options);
            CommentManagerInstance = new(_Context);
            _Context.Post.RemoveRange(_Context.Post);
            _Context.Post.Add(new Post() {PostId = 1, Title = "forComment",Content =  "for comment"});
        }
        [Fact]
        public async Task CanCreateComment()
        {
            // Arrange
            await ClearDatabase();
            Comment TestComment = CreateTestComment(1);
            // Act
            await CommentManagerInstance.CreateComment(TestComment);

            // Assert
            var createdComment = _Context.Comment.Find(1);
            Assert.NotNull(createdComment);
            Assert.Equal("Test Comment", createdComment.Text);
        }
        [Fact]
        public async Task CanGet()
        {
            // Arrange
            await ClearDatabase();
            Comment TestComment = CreateTestComment(2);
            await _Context.Comment.AddAsync(TestComment); 
            // Act
            await CommentManagerInstance.GetComments();
            // Assert
            var ReturnedValues = _Context.Comment.Find(2);
            Assert.NotNull(ReturnedValues);
        }
        [Fact]      
        public async Task CanUpdate()
        {
            // Arrange
            await ClearDatabase();
            Comment TestComment = CreateTestComment(3);
            await _Context.Comment.AddAsync(TestComment);
            await _Context.SaveChangesAsync();
            string text = "Updated comment";
            // Act
            await CommentManagerInstance.UpdateComment(new Comment {Text = text,CommentId = 3});

            // Assert
            var updatedComment = _Context.Comment.Where(c => c.CommentId == 3).First();
            Assert.NotNull(updatedComment);
            Assert.Equal("Updated comment", updatedComment.Text);
        }
        [Fact]
        public async Task CanDelete()
        {
            // Arrange
            await ClearDatabase();
            Comment TestComment = CreateTestComment(4);
            await _Context.Comment.AddAsync(TestComment);
            await _Context.SaveChangesAsync();
            // Act
            await CommentManagerInstance.DeleteComment(4);
            // Assert
            var createdComment = _Context.Comment.Find(4);
            Assert.Null(createdComment);
        }

        internal async Task ClearDatabase()
        {
            _Context.Comment.RemoveRange(_Context.Comment);
            await _Context.SaveChangesAsync();
        }

        public static Comment CreateTestComment(int Id)
        {
            return new Comment() {CommentId = Id,Text = "Test Comment",PostId = 1};
        }
    }      
}
