using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using ComputerTechAPI_Repository;

namespace ComputerTechDataAPI.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
        var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
            b => b.MigrationsAssembly("ComputerTechDataAPI"));

        return new RepositoryContext(builder.Options);
    }
}