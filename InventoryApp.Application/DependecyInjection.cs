using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InventoryApp.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
      
            return services;
        }
        
    }
}
