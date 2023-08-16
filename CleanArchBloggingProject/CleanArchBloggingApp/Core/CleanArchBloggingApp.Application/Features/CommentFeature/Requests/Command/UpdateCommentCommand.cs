using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchBloggingApp.Application.Dtos.Comments;
using CleanArchBloggingApp.Application.Dtos.Posts;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.CommentFeature.Requests.Command
{
    public class UpdateCommentCommand : IRequest<int>
    {
        public CommentDto? CommentDto {get; set;}   
    }
}