using System.Reflection;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddMappings();
        services.AddDbContext(configuration);
        services.AddRepositories();
    }

    // private static void AddMappings(this IServiceCollection services)
    // {
    //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
    // }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {   
        // In-Memory Data
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName: "UserDB"));

        // MS SQL Server
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        // services.AddDbContext<ApplicationDbContext>(options =>
        //     options.UseSqlServer(connectionString,
        //         builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
            .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddTransient<IUserRepository, UserRepository>();
    }
}