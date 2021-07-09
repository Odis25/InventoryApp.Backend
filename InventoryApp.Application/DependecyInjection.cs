using FluentValidation;
using InventoryApp.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InventoryApp.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembley = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembley);
            services.AddMediatR(assembley);
            services.AddValidatorsFromAssembly(assembley);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
      
            return services;
        }
        
    }
}
