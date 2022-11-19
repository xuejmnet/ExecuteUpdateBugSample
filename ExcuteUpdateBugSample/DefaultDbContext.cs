using Microsoft.EntityFrameworkCore;

namespace ExcuteUpdateBugSample;

public class DefaultDbContext:DbContext
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<LogicDatabaseEntity>(o =>
        {
            o.HasKey(x => x.Id);
            o.ToTable(nameof(LogicDatabaseEntity));
        });
    }
}