using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeutroLab.Extensions.NHibernate;
using NHibernate;
using NHibernate.Cfg;

namespace NeutroLab.Extensions.NetCore
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, Action<IServiceProvider, Configuration> configure, string[] filters = null)
        {
            services.AddSingleton((provider) =>
            {
                Configuration config = new Configuration();

                if (configure != null)
                    configure(provider, config);

                return config;
            });

            services.AddSingleton((provider) =>
            {
                return provider.GetService<Configuration>().BuildSessionFactory();
            });

            services.AddScoped((provider) =>
            {

                ISessionFactory factory = provider.GetService<ISessionFactory>();
                ISession session = factory.OpenSession();

                if (filters != null)
                {
                    foreach (string filterName in filters)
                        session.EnableFilter(filterName);
                }

                return session;
            });

            return services;
        }

        public static IServiceCollection AddNHibernateWithConfigSetting(this IServiceCollection services, Action<IServiceProvider, Configuration> configure = null, string[] filters = null)
        {
            services.AddNHibernate((provider, config) =>
            {
                IConfiguration appConfig = provider.GetService<IConfiguration>();
                NHibernateSetting options = appConfig.GetSection(NHibernateSetting.SECTION_NAME).Get<NHibernateSetting>();

                config.AddProperties(options.Properties);
                config.Properties.Add("connection.connection_string", appConfig.GetConnectionString(options.ConnectionStringName));

                if (configure != null)
                    configure(provider, config);

            }, filters);

            return services;
        }
    }
}
