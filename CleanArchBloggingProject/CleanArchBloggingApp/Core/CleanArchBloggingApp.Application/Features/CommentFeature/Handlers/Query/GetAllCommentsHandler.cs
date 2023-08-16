using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchBloggingApp.Application.Dtos.Comments;
using CleanArchBloggingApp.Application.Features.CommentFeature.Requests.Query;
using CleanArchBloggingApp.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.CommentFeature.Handlers.Query
{
     public class GetAllCommentsHandler : IRequestHandler<GetCommentByIdRequest, CommentWithDetailDto>
    {

        readonly IGenericRepository<CommentEntity> _Repository;
        readonly IMapper _mapper;
        public GetAllCommentsHandler(IGenericRepository<CommentEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;   
            _mapper = mapper;
        }

        public async Task<CommentWithDetailDto> Handle(GetCommentByIdRequest request, CancellationToken cancellationToken)
        {
           var result = await _Repository.GetAll();
            var AllComments = _mapper.Map<CommentWithDetailDto>(result);
            return AllComments;

        }
    }
}