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
            _Context.Post.Add(new Post() {PostId = 1, Title = "forComment",Content =  "for comment"});
            Comment first = new(){Text = "Text",PostId = 1};
            CommentManagerInstance.CreateComment(first);
        }
        [Fact]
        public void CanCreateComment()
        {
            // Arrange
            Comment first = new(){Text = "Text",PostId = 1};
            // Act
            CommentManagerInstance.CreateComment(first);

            // Assert
            var createdComment = _Context.Comment.FirstOrDefault();
            Assert.NotNull(createdComment);
            Assert.Equal("school", createdComment.Text);
        }
        [Fact]
        public void CanGet()
        {
            // Arrange
            // Act
            CommentManagerInstance.GetComments();
            // Assert
            var ReturnedValues = _Context.Comment;
            Assert.Null(ReturnedValues);
        }
        [Fact]      
        public void CanUpdate()
        {
            // Arrange
            int Id = 1;
            string text = "updated comment";
            // Act
            CommentManagerInstance.UpdateComment(new Comment {Text = text,CommentId = 1});

            // Assert
            var updatedComment = _Context.Comment.Where(c => c.CommentId == Id).First();
            Assert.NotNull(updatedComment);
            Assert.Equal("updated comment", updatedComment.Text);
        }
        [Fact]
        public void CanDelete()
        {
            // Arrange
            int Id = 1;
            // Act
            CommentManagerInstance.DeleteComment(Id);
            // Assert
            var createdComment = _Context.Comment.Where(c => c.CommentId == Id).First();
            Assert.Null(createdComment);
        }
    }      
}
