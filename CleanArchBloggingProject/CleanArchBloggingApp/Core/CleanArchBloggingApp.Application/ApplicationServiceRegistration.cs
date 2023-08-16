using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchBloggingApp.Application
{
    public class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationService(IServiceCollection Service)
        {
            Service.AddAutoMapper(Assembly.GetExecutingAssembly());
            Service.AddMediatR(Assembly.GetExecutingAssembly());
            return Service;
        }
    }
}