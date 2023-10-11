
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PancakeApp.DataAccess.DataContext;
using PancakeApp.DataAccess.Repositories.Implementations;
using PancakeApp.DataAccess.Repositories.Interfaces;
using PancakeApp.Domain.Models;
using PancakeApp.Services.Implementations;
using PancakeApp.Services.Interfaces;

namespace PancakeApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services)
        {
            services.AddDbContext<PancakeAppDbContext>(options => options.UseSqlServer(@"Data Source=(localdb)\PancakeApp;Database=PancakeAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPancakeRepository, PancakeRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Location>, LocationRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IPancakeService, PancakeService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ILocationService, LocationService>();
        }

    }
}
