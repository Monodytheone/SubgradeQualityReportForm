using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FormService.Infrastructure;

internal class FormDesignTimeDbContextFactory : IDesignTimeDbContextFactory<FormDbContext>
{
    public FormDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FormDbContext>();
        string connStr = Environment.GetEnvironmentVariable("ConnectionStrings:SubgradeQualityForm")!;
        optionsBuilder.UseSqlServer(connStr);
        return new FormDbContext(optionsBuilder.Options);
    }
}
