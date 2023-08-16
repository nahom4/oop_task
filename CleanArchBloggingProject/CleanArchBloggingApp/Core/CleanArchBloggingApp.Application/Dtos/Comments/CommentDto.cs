using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchBloggingApp.Application.Dtos.Common;

namespace CleanArchBloggingApp.Application.Dtos.Comments
{
    public class CommentDto : BaseDto
    {
        public int PostId { get;set; }     
        public string? Text {  get;set; }   
    }
}