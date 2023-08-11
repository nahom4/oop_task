using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingApplication;
using Microsoft.AspNetCore.Mvc;

namespace BloggingApplicationWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        ApplicationContext _DbContext;
        PostManager PostManagerInstance;
        public PostController(ApplicationContext DbContext)
        {
            _DbContext = DbContext;
            PostManagerInstance = new(_DbContext);

        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            Console.WriteLine("get by id");
            Post DataPoint = await PostManagerInstance.DataPointExists(Id)!;
            if (DataPoint == null)
            {   
                return NotFound();
            }

            else
            {   
                return Ok(DataPoint);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Post>? PostList = await PostManagerInstance.GetPosts();
            return Ok(PostList);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post PostToBeCreated)
        {
            await PostManagerInstance.CreatePost(PostToBeCreated);
            return CreatedAtAction(nameof(Get), new { id = PostToBeCreated.PostId }, PostToBeCreated);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdatePost(Post UpdateInfo)
        {
            Post PostToBeUpdated = await PostManagerInstance.DataPointExists(UpdateInfo.PostId)!;

            if (PostToBeUpdated != null)
            {
                await PostManagerInstance.UpdatePost(PostToBeUpdated,UpdateInfo);
                return NoContent();
            }

            else
            {
                return BadRequest("The post doesn't exist");
            }
    
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePost(int Id)
        {
            Post? PostToBeDeleted = await PostManagerInstance.DataPointExists(Id)!;

            if (PostToBeDeleted != null)
            {
                await PostManagerInstance.DeletePost(PostToBeDeleted);
                return NoContent();
            }

            else
            {
                return BadRequest();
            }
           
        }
    }
}