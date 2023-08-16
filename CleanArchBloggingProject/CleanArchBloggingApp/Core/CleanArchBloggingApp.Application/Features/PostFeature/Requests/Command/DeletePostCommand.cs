using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchBloggingApp.Application.Features.PostFeature.Requests.Command
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }
    }
}