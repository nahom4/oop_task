using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.CommentFeature.Requests.Command
{
    public class DeleteCommentCommand : IRequest
    {
        public int Id { get; set; }
    }
}