using Application.Commands.ProjectCommand.CreateProjectCommand;
using Application.Commands.TaskCommand.AssingTasksToUsersCommand;
using Application.Commands.TaskCommand.CreateTaskCommand;
using Application.Commands.TaskCommand.DeleteTaskCommand;
using Application.Commands.TaskCommand.UpdateTaskCommand;
using Application.Commands.UserCommands.CreateUserCommand;
using Application.Commands.UserCommands.DeleteUserCommand;
using Application.Commands.UserCommands.UpdateUserCommand;
using Application.Models;
using Application.Models.Projects.ViewModels;
using Application.Models.Tasks.ViewModels;
using Application.Models.Users.ViewModels;
using Application.Queries.ProjectQueries.GetProjectByIdQueries;
using Application.Queries.TaskQueries.GetTaskById;
using Application.Queries.UserQueries.GetUserById;
using Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediador();
            services.AddValidator();

            return services;
        
        }     

        private static IServiceCollection AddMediador(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CreateTaskCommand>();
            });

            services.AddTransient<IPipelineBehavior<CreateProjectCommand, ResultViewModel<Guid>>, ValidadeCreateProjectBehavior>();
            services.AddTransient<IPipelineBehavior<CreateTaskCommand, ResultViewModel<Guid>>, ValidateCreateTaskBehavior>();
            services.AddTransient<IPipelineBehavior<CreateUserCommand, ResultViewModel<Guid>>, ValidateCreateUserBehavior>();
            services.AddTransient<IPipelineBehavior<AssingTasksToUsersCommand, ResultViewModel>,ValidateAssingTaskToUserBehavior>();
            services.AddTransient<IPipelineBehavior<DeleteTaskCommand, ResultViewModel>, ValidateDeleteTaskBehavior>();
            services.AddTransient<IPipelineBehavior<UpdateTaskCommand, ResultViewModel>, ValidateUpdateTaskBehavior>();
            services.AddTransient<IPipelineBehavior<DeleteUserCommand, ResultViewModel>, ValidateDeleteBehavior>();
            services.AddTransient<IPipelineBehavior<UpdateUserCommand, ResultViewModel>, ValidateUpdateUserBehavior>();
            services.AddTransient<IPipelineBehavior<GetProjectByIdQuery, ResultViewModel<GetProjectViewModel>>, ValidateGetProjectByIdBehavior>();
            services.AddTransient<IPipelineBehavior<GetTaskByIdQuery, ResultViewModel<GetTaskViewModel>>, ValidateGetTaskByIdBehavior>();
            services.AddTransient<IPipelineBehavior<GetUserByIdQuery, ResultViewModel<UsersViewModels>>, ValidateGetUserByIdBehavior>();

            return services;
        }

        private static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateProjectValidator>();

            return services;
        }
    }
}