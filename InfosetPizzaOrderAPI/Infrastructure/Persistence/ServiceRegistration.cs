using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DataContext;
using Persistence.Repositories;
using Persistence.Seeder;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InfosetDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnectionString")));
            services.AddScoped<IBranchRepository, BranchRepository>();
            DataSeeder.Seed(services.BuildServiceProvider());
        }
    }
}
