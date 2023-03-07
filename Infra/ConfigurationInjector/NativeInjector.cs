using Infra.Interface;
using Infra.Repository;
using Infra.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.ConfigurationInjector
{
    public static class NativeInjector
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();

            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}