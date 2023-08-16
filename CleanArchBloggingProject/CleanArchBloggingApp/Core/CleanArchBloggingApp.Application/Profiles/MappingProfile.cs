using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchBloggingApp.Application.Dtos.Comments;
using CleanArchBloggingApp.Application.Dtos.Posts;

namespace CleanArchBloggingApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
        CreateMap<PostEntity,CreatePostDto>().ReverseMap();
        CreateMap<PostEntity,PostDto>().ReverseMap();
        CreateMap<PostEntity,PostWithDetailDto>().ReverseMap();
        CreateMap<CommentEntity,CommentDto>().ReverseMap();
        CreateMap<CommentEntity,CreateCommentDto>().ReverseMap();
        CreateMap<CommentEntity,CommentWithDetailDto>().ReverseMap();

        }
    }
}