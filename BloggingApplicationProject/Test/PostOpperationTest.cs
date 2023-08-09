using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BloggingApplication;
using Xunit;

namespace BloggingApplication
{
    public class PostOperationTest
    {
        ApplicationContext _Context;
        readonly PostManager PostManagerInstance;
        
        public PostOperationTest()
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
            // Arrange
            await ClearDatabase();
            Post TestPost = CreateTestPost(1); 
            // Act
            await PostManagerInstance.CreatePost(TestPost);

            // Assert
            var createdPost = _Context.Post.FirstOrDefault();
            Assert.NotNull(createdPost);
            Assert.Equal("Test Post", createdPost.Title);
            Assert.Equal("Test Post Content", createdPost.Content);
        }
       
        [Fact]      
        public async Task CanUpdate()
        {
            // Arrange
            await  ClearDatabase();
            Post TestPost = CreateTestPost(2);
            await _Context.Post.AddAsync(TestPost);
            await _Context.SaveChangesAsync();
            // Act
            await PostManagerInstance.UpdatePost(new() {Title = "Test Post",Content = "Test Post changed"});

            // Assert
            var updatedPost = _Context.Post.Where(p => p.Title == "Test Post").First();
            Assert.NotNull(updatedPost);
            Assert.Equal("Test Post changed", updatedPost.Content);
        }
        [Fact]
        public async Task CanDelete()
        {
            // Arrange
             await ClearDatabase();
            Post TestPost = CreateTestPost(3);
            await _Context.Post.AddAsync(TestPost);
            await _Context.SaveChangesAsync();
            // Act
            await PostManagerInstance.DeletePost(3);

            // Assert
            var createdPost = _Context.Post.Find(3);
            Assert.Null(createdPost);
        }
        [Fact]
        public async Task CanGet()
        {
            // Arrange
            await ClearDatabase();
            Post TestPost = CreateTestPost(4);
            await _Context.Post.AddAsync(TestPost);
            await _Context.SaveChangesAsync();
            // Act
            await PostManagerInstance.GetPosts();
            // Assert
            var ReturnedValues = _Context.Post;
            Assert.NotNull(ReturnedValues);
        }

        internal async Task ClearDatabase()
        {
             _Context.Post.RemoveRange(_Context.Post);
            await _Context.SaveChangesAsync();
        }

        public static Post CreateTestPost(int Id)
        {
            return new Post() {PostId = Id,Title = "Test Post",Content = "Test Post Content"};
        }
    }      
}
