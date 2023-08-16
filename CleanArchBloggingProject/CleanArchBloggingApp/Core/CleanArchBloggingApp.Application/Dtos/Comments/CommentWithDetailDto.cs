using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchBloggingApp.Application.Dtos.Common;
using CleanArchBloggingApp.Application.Dtos.Posts;

namespace CleanArchBloggingApp.Application.Dtos.Comments
{
    public class CommentWithDetailDto : BaseDto
    {
        public int PostId { get;set; }     
        public string? Text {  get;set; }   
        public virtual PostDto? Post { get; set; } 
    }
}