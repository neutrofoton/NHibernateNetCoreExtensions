using System;
using Microsoft.Extensions.DependencyInjection;
using NeutroLab.BusinessLogic.Repository;
using NeutroLab.BusinessLogic.Repository.Impl;

namespace NeutroLab.WebApi
{
    public static class ServiceRegistration
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
