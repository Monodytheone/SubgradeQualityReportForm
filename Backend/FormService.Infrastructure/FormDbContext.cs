using FormService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormService.Infrastructure;

public class FormDbContext : DbContext
{
    public DbSet<Form> Forms { get; private set; }

    public FormDbContext(DbContextOptions<FormDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
