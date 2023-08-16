using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchBloggingApp.Application.Dtos.Posts;
using CleanArchBloggingApp.Application.Features.PostFeature.Requests.Command;
using CleanArchBloggingApp.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.PostFeature.Handlers.Command
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand,int>
    {
        
        readonly IGenericRepository<PostEntity> _Repository;
        readonly IMapper _mapper;
        public UpdatePostHandler(IGenericRepository<PostEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;   
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
           var PostToBeUpdated = await _Repository.Get(request.PostDto!.Id);
           _mapper.Map(request.PostDto,PostToBeUpdated);
           await _Repository.Update(PostToBeUpdated);
           return PostToBeUpdated.Id;

        }
    }
}