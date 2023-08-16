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
    public class CreatPostHandler : IRequestHandler<CreatepostCommand, int>
    {
        
        readonly IGenericRepository<PostEntity> _Repository;
        readonly IMapper _mapper;
        public CreatPostHandler(IGenericRepository<PostEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;   
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatepostCommand request, CancellationToken cancellationToken)
        {
          
            var result = _mapper.Map<PostEntity>(request.CreatePostDto);
            var CreatedPost = await _Repository.Create(result);
            return CreatedPost.Id;
    
        }
    }
}