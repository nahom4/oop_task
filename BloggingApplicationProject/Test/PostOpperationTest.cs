using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BloggingApplication
{
    public class PostOpperationTest
    {
        ApplicationContext _Context;
        PostManager PostManagerInstance;
        
        public PostOpperationTest()
        {   
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _Context = new ApplicationContext(options);
            PostManagerInstance = new(_Context);

        }
        [Fact]
        public void CanCreatePost()
        {
            // Arrange
            ClearDatabase();
            Post TestPost = CreateTestPost(); 
            // Act
            PostManagerInstance.CreatePost(TestPost);

            // Assert
            var createdPost = _Context.Post.FirstOrDefault();
            Assert.NotNull(createdPost);
            Assert.Equal("Test Post", createdPost.Title);
            Assert.Equal("Test Post Content", createdPost.Content);
        }
       
        [Fact]      
        public void CanUpdate()
        {
            // Arrange
            ClearDatabase();
            Post TestPost = CreateTestPost();
            _Context.Post.Add(TestPost);
            _Context.SaveChanges();
            // Act
            PostManagerInstance.UpdatePost(new() {Title = "Test Post",Content = "Test Post changed"});

            // Assert
            var updatedPost = _Context.Post.Where(p => p.Title == "Test Post").First();
            Assert.NotNull(updatedPost);
            Assert.Equal("Test Post changed", updatedPost.Content);
        }
        [Fact]
        public void CanDelete()
        {
            // Arrange
             ClearDatabase();
            Post TestPost = CreateTestPost();
            _Context.Post.Add(TestPost);
            _Context.SaveChanges();
            // Act
            PostManagerInstance.DeletePost("Test Post");

            // Assert
            var createdPost = _Context.Post.FirstOrDefault();
            Assert.Null(createdPost);
        }
        [Fact]
        public void CanGet()
        {
            // Arrange
            ClearDatabase();
            Post TestPost = CreateTestPost();
            _Context.Post.Add(TestPost);
            _Context.SaveChanges();
            // Act
            PostManagerInstance.GetPosts();
            // Assert
            var ReturnedValues = _Context.Post;
            Assert.NotNull(ReturnedValues);
        }

          public void ClearDatabase()
        {
            _Context.Post.RemoveRange(_Context.Post);
            _Context.SaveChanges();
        }

        public static Post CreateTestPost()
        {
            return new Post() {PostId = 1,Title = "Test Post",Content = "Test Post Content"};
        }
    }      
}
