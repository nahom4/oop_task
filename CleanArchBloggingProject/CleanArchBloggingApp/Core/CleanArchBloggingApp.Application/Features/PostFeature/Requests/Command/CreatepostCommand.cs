using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchBloggingApp.Application.Dtos.Posts;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.PostFeature.Requests.Command
{
    public class CreatepostCommand : IRequest<int>
    {
        public CreatePostDto? CreatePostDto{ get; set; }
    }
}