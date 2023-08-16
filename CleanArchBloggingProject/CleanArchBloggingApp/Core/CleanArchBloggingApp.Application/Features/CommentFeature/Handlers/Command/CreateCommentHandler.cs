using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchBloggingApp.Application.Dtos.Comments;
using CleanArchBloggingApp.Application.Dtos.Posts;
using CleanArchBloggingApp.Application.Features.PostFeature.Requests.Command;
using CleanArchBloggingApp.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.PostFeature.Handlers.Command
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, int>
    {
        
        readonly IGenericRepository<CommentEntity> _Repository;
        readonly IMapper _mapper;
        public CreateCommentHandler(IGenericRepository<CommentEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;   
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
           var CommentedToBeCreated  = _mapper.Map<CommentEntity>(request.CreateCommentDto);
           var CreatedComment = await _Repository.Create(CommentedToBeCreated);
           return CreatedComment.Id;

        }
    }
}