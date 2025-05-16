using CleanArch.IntegrationTests.Domain.Interfaces;
using CleanArch.IntegrationTests.Infra.Data.Context;
using CleanArch.IntegrationTests.Infra.Data.Repositories;
using CleanArch.IntegrationTests.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.IntegrationTests.Ioc
{
    public static class InfrastructureConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default")));
           

            return services;
        }
    }
}
