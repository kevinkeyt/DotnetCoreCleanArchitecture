using System.Reflection;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Contexts;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { 
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Data Seeding
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "Joe", LastName = "User", Email = "joe@testing.com", Phone = "(123) 456-8888" });
        modelBuilder.Entity<User>().HasData(
            new User { Id = 2, FirstName = "Jane", LastName = "User", Email = "jane@testing.com", Phone = "(123) 456-9999"});
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}