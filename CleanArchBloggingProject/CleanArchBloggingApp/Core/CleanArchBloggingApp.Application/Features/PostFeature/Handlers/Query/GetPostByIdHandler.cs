using AutoMapper;
using CleanArchBloggingApp.Application.Dtos.Posts;
using CleanArchBloggingApp.Application.Features.PostFeature.Requests.Query;
using CleanArchBloggingApp.Application.Persistence.Contracts;
using MediatR;
namespace CleanArchBloggingApp.Application.Features.PostFeature.Handlers.Query
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdRequest, PostWithDetailDto>
    {

        readonly IGenericRepository<PostEntity> _Repository;
        readonly IMapper _mapper;
        public GetPostByIdHandler(IGenericRepository<PostEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;   
            _mapper = mapper;
        }

        public async Task<PostWithDetailDto> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
        {
            PostEntity result = await _Repository.Get(request.Id);
            PostWithDetailDto postWithDetail = _mapper.Map<PostWithDetailDto>(result);
            return postWithDetail;

        }
    }
}