using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;

namespace NeutroLab.Extensions.NetCore
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNHibernate(this IApplicationBuilder builder)
        {
            if (builder.ApplicationServices.GetService<ISessionFactory>() == null)
                throw new HibernateConfigException("Unable to initialize the session factory.");

            return builder;
        }
    }
}
