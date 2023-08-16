using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchBloggingApp.Application.Dtos.Comments
{
    public class CreateCommentDto
    {
        public int PostId { get;set; }     
        public string? Text {  get;set; }   
    }
}