using AutoMapper;
using CleanArchBloggingApp.Application.Dtos.Comments;
using CleanArchBloggingApp.Application.Features.CommentFeature.Requests.Query;
using CleanArchBloggingApp.Application.Persistence.Contracts;
using MediatR;
namespace CleanArchBloggingApp.Application.Features.CommentFeature.Handlers.Query
{
    public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdRequest, CommentWithDetailDto>
    {

        readonly IGenericRepository<CommentEntity> _Repository;
        readonly IMapper _mapper;
        public GetCommentByIdHandler(IGenericRepository<CommentEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;   
            _mapper = mapper;
        }

        public async Task<CommentWithDetailDto> Handle(GetCommentByIdRequest request, CancellationToken cancellationToken)
        {
            CommentEntity result = await _Repository.Get(request.Id);
            CommentWithDetailDto CommentWithDetail = _mapper.Map<CommentWithDetailDto>(result);
            return CommentWithDetail;

        }
    }
}