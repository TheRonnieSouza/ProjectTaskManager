using Application.Commands.ProjectCommand.CreateProjectCommand;
using Application.Commands.TaskCommand.CreateTaskCommand;
using Application.Models;
using Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();
            services.AddMediador();

            return services;
        
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserServices>();
            return services;
        }

        private static IServiceCollection AddMediador(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CreateTaskCommand>();
            });

            services.AddTransient < IPipelineBehavior<CreateProjectCommand, ResultViewModel<Guid>>, ValidadeCreateProjectBehavior>();
            return services;
        }
    }
}