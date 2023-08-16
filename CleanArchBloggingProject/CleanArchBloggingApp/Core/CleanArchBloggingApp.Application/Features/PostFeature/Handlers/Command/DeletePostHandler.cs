using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchBloggingApp.Application.Features.PostFeature.Requests.Command;
using CleanArchBloggingApp.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.PostFeature.Handlers.Command
{
   public class DeletePostHandler : IRequestHandler<DeletePostCommand,Unit>
    {
        
        readonly IGenericRepository<PostEntity> _Repository;
        readonly IMapper _mapper;
        public DeletePostHandler(IGenericRepository<PostEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;   
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
           var PostToBeDeleted = await _Repository.Get(request.Id);
           await _Repository.Delete(PostToBeDeleted);
           return Unit.Value;

        }

    }
}