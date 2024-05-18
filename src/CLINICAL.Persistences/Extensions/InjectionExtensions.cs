using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Persistences.Context;
using CLINICAL.Persistences.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICAL.Persistences.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<AppDbContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;

        }
    }
}
