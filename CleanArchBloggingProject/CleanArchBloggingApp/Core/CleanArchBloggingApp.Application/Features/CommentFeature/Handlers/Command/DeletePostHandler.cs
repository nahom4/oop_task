using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchBloggingApp.Application.Features.CommentFeature.Requests.Command;
using CleanArchBloggingApp.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.CommentFeature.Handlers.Command
{
   public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        
        readonly IGenericRepository<CommentEntity> _Repository;
        readonly IMapper _mapper;
        public DeleteCommentHandler(IGenericRepository<CommentEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;   
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var CommentToBeDeleted = await _Repository.Get(request.Id);
            await _Repository.Delete(CommentToBeDeleted);
            return Unit.Value;
        }

    }
}