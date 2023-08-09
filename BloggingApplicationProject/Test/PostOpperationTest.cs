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
            Post first = new(){Title = "school",Content = "Content"};
            // Act
            PostManagerInstance.CreatePost(first);

            // Assert
            var createdPost = _Context.Post.FirstOrDefault();
            Assert.NotNull(createdPost);
            Assert.Equal("school", createdPost.Title);
            Assert.Equal("Content", createdPost.Content);
        }
       
        [Fact]      
        public void CanUpdate()
        {
            // Arrange
            Post first = new(){Title = "work",Content = "work Content"};
            _Context.Post.Add(first);
            // Act
            PostManagerInstance.UpdatePost(new() {Title = "work",Content = "Content changed"});

            // Assert
            var updatedPost = _Context.Post.Where(p => p.Title == "work").First();
            Assert.NotNull(updatedPost);
            Assert.Equal("Content changed", updatedPost.Content);
        }
        [Fact]
        public void CanDelete()
        {
            // Arrange
            Post first = new(){Title = "work",Content = "work Content"};
            _Context.Post.Add(first);
            // Act
            PostManagerInstance.DeletePost("work");

            // Assert
            var createdPost = _Context.Post.Where(p => p.Title == "work").First();
            Assert.Null(createdPost);
        }
        [Fact]
        public void CanGet()
        {
            // Arrange
            Post first = new(){Title = "work",Content = "work Content"};
            _Context.Post.Add(first);
            // Act
            PostManagerInstance.GetPosts();
            // Assert
            var ReturnedValues = _Context.Post;
            Assert.Null(ReturnedValues);
        }
    }      
}
