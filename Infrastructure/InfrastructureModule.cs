using Core.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddData(configuration);

            return services;
        }
        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ProjectTaskManager");

            services.AddDbContext<ProjectTaskManagerDbContext>(o => o.UseInMemoryDatabase("ProjectTaskManager"));

            //services.AddDbContext<ProjectTaskManagerDbContext>(o => o.UseSqlServer(connectionString));


            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRespository>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
