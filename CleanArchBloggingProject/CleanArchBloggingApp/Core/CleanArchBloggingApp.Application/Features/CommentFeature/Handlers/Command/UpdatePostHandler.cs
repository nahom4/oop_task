using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchBloggingApp.Application.Dtos.Comments;
using CleanArchBloggingApp.Application.Features.CommentFeature.Requests.Command;
using CleanArchBloggingApp.Application.Persistence.Contracts;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.CommentFeature.Handlers.Command
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand,int>
    {
        
        readonly IGenericRepository<CommentEntity> _Repository;
        readonly IMapper _mapper;
        public UpdateCommentHandler(IGenericRepository<CommentEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;   
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var CommentToBeUpdated = await _Repository.Get(request.CommentDto!.Id);
           _mapper.Map(request.CommentDto,CommentToBeUpdated);
           await _Repository.Update(CommentToBeUpdated);
           return CommentToBeUpdated.Id;

        }
    }
}