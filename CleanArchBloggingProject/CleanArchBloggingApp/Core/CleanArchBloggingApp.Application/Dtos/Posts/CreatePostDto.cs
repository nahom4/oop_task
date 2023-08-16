using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchBloggingApp.Application.Dtos.Posts
{
    public class CreatePostDto
    {
        public string? Title  {set;get;} 
        public string? Content { set;get;} 
    }
}