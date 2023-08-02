using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Infrastructure.Persistence;
using TodoApp.Infrastructure.Repositories;

namespace TodoApp.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInftrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoDbContext>(options =>
            {
                var connStr = configuration.GetConnectionString("TodoConnectionString");

                options.UseNpgsql(configuration.GetConnectionString("TodoConnectionString"));
            });

            services.AddScoped<ITodoUnitOfWork, TodoUnitOfWork>();
            services.AddScoped<ITodoRepository, TodoRepository>();


            return services;
        }
    }
}

