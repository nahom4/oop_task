using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchBloggingApp.Application.Dtos.Posts;
using CleanArchBloggingApp.Application.Features.PostFeature.Requests.Query;
using CleanArchBloggingApp.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.PostFeature.Handlers.Query
{
     public class GetAllPostsHandler : IRequestHandler<GetPostByIdRequest, PostWithDetailDto>
    {

        readonly IGenericRepository<PostEntity> _Repository;
        readonly IMapper _mapper;
        public GetAllPostsHandler(IGenericRepository<PostEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;   
            _mapper = mapper;
        }

        public async Task<PostWithDetailDto> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
        {
           var result = await _Repository.GetAll();
            var AllPosts = _mapper.Map<PostWithDetailDto>(result);
            return AllPosts;

        }
    }
}