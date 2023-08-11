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
    public class CommentController : ControllerBase
    {
        ApplicationContext _DbContext;
        CommentManager CommentManagerInstance;
        public CommentController(ApplicationContext DbContext)
        {
            _DbContext = DbContext;
            CommentManagerInstance = new(_DbContext);

        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            Comment? DataPoint = await CommentManagerInstance.DataPointExists(Id)!;

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
            List<Comment>? CommentList = await CommentManagerInstance.GetComments();
            return Ok(CommentList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment CommentToBeCreated)
        {
            await CommentManagerInstance.CreateComment(CommentToBeCreated);
            return CreatedAtAction(nameof(Get), new { id = CommentToBeCreated.CommentId }, CommentToBeCreated);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateComment(Comment UpdateInfo)
        {
            Comment CommentToBeUpdated = await CommentManagerInstance.DataPointExists(UpdateInfo.CommentId)!;

            if (CommentToBeUpdated != null)
            {
                await CommentManagerInstance.UpdateComment(CommentToBeUpdated,UpdateInfo);
                return NoContent();
            }

            else
            {
                return BadRequest("The Comment doesn't exist");
            }
    
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int Id)
        {
            Comment? CommentToBeDeleted = await CommentManagerInstance.DataPointExists(Id)!;

            if (CommentToBeDeleted != null)
            {
                await CommentManagerInstance.DeleteComment(CommentToBeDeleted);
                return NoContent();
            }

            else
            {
                return BadRequest();
            }
           
        }
    }
}