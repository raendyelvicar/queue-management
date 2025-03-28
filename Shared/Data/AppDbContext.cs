using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Shared.Data;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Queue> Queues { get; set; }
    public DbSet<Service> Services { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION") 
                                   ?? _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}