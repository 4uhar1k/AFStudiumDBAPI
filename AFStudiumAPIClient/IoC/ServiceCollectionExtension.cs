using AFStudiumAPIClient.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFStudiumAPIClient.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddAFStudiumAPIClientService(this IServiceCollection services,
            Action<ApiClientOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new AFStudiumAPIClientService(options);
            });
        }
    }
}
