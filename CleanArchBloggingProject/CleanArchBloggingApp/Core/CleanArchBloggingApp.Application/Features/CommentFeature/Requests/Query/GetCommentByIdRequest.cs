using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchBloggingApp.Application.Dtos.Comments;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.CommentFeature.Requests.Query
{
    public class GetCommentByIdRequest : IRequest<CommentWithDetailDto>
    {
        public int Id { get; set; }
    }
}