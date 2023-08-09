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
            _Context.SaveChanges();
            _Context.Post.Add(new Post() {PostId = 1, Title = "forComment",Content =  "for comment"});
        }
        [Fact]
        public void CanCreateComment()
        {
            // Arrange
            ClearDatabase();
            Comment TestComment = CreateTestComment();
            // Act
            CommentManagerInstance.CreateComment(TestComment);

            // Assert
            var createdComment = _Context.Comment.FirstOrDefault();
            Assert.NotNull(createdComment);
            Assert.Equal("Test Comment", createdComment.Text);
        }
        [Fact]
        public void CanGet()
        {
            // Arrange
            ClearDatabase();
            Comment TestComment = CreateTestComment();
            _Context.Comment.Add(TestComment); 
            _Context.SaveChanges();        
            // Act
            CommentManagerInstance.GetComments();
            // Assert
            var ReturnedValues = _Context.Comment;
            Assert.NotNull(ReturnedValues);
        }
        [Fact]      
        public void CanUpdate()
        {
            // Arrange
            ClearDatabase();
            Comment TestComment = CreateTestComment();
            _Context.Comment.Add(TestComment);
            _Context.SaveChanges();
            string text = "Updated comment";
            // Act
            CommentManagerInstance.UpdateComment(new Comment {Text = text,CommentId = 1});

            // Assert
            var updatedComment = _Context.Comment.Where(c => c.CommentId == 1).First();
            Assert.NotNull(updatedComment);
            Assert.Equal("Updated comment", updatedComment.Text);
        }
        [Fact]
        public void CanDelete()
        {
            // Arrange
            ClearDatabase();
            Comment TestComment = CreateTestComment();
            _Context.Comment.Add(TestComment);
            _Context.SaveChanges();
            // Act
            CommentManagerInstance.DeleteComment(1);
            // Assert
            var createdComment = _Context.Comment.FirstOrDefault();
            Assert.Null(createdComment);
        }

        public void ClearDatabase()
        {
            _Context.Comment.RemoveRange(_Context.Comment);
            _Context.SaveChanges();
        }

        public static Comment CreateTestComment()
        {
            return new Comment() {CommentId = 1,Text = "Test Comment",PostId = 1};
        }
    }      
}
