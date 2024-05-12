using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu;
using BuberDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace BuberDinner.Infrastructure.Persistence;

public class BuberDinnerDbContext : DbContext
{
    private readonly PublishDomainEventInterceptor _publishDomainEventInterceptor;
    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options, PublishDomainEventInterceptor publishDomainEventInterceptor) : base(options)
    {
        _publishDomainEventInterceptor = publishDomainEventInterceptor ?? throw new ArgumentNullException(nameof(publishDomainEventInterceptor));
    }

    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}