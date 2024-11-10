using LocalizationPractice.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalizationPractice.Web.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonalInformation>(builder =>
        {
            builder.HasKey(x => x.EntityId);
            builder.Property(x => x.EntityId).ValueGeneratedOnAdd();
        });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<PersonalInformation> PersonalInformation { get; set; }
}
