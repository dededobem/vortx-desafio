using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vortx.Application.Interfaces;
using Vortx.Application.Services;
using Vortx.Domain.Interfaces;
using Vortx.Infrastructure.Data;
using Vortx.Infrastructure.Repositories;

namespace Vortx.Infrastructure.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VortxContext>(options =>
                options.UseSqlite(connection));

            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();

            services.AddScoped<IAppPlan, AppPlan>();
            services.AddScoped<IAppPrice, AppPrice>();

            services.AddScoped<IAppCalculation, AppCalculation>();

        }
    }
}
