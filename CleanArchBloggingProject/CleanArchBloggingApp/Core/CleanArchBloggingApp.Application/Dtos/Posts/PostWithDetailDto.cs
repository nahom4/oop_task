using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchBloggingApp.Application.Dtos.Comments;
using CleanArchBloggingApp.Application.Dtos.Common;

namespace CleanArchBloggingApp.Application.Dtos.Posts
{
    public class PostWithDetailDto : BaseDto
    {
        public string? Title  {set;get;} 
        public string? Content { set;get;} 
        public virtual List<CommentDto>? ListOfComments {set;get;} 
    }
}