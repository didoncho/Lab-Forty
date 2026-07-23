using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class DataContext : DbContext
{
    // Toggle to true to use an in-memory database instead of MySQL/MariaDB.
    public static bool UseInMemoryDatabase = false;

    public DbSet<Fencer>  Fencers { get; set; }
    public DbSet<FencerInformation>  FencerInformations { get; set; }
    public DbSet<Coach>  Coaches { get; set; }
    public DbSet<Competition>  Competitions { get; set; }
    public DbSet<CompetitionResult>  CompetitionResults { get; set; }
    public DbSet<CompetitionFile>  CompetitionFiles { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (UseInMemoryDatabase)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }
        else
        {
            string connectionString = "Host=localhost;Port=3306;Username=root;Password=D!di2008;Database=Manjaro Local;";

            optionsBuilder.UseMySql(
                connectionString,
                //ServerVersion.AutoDetect(connectionString)
                new MariaDbServerVersion(new Version(12, 2, 2))
            );
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<UserInformation>().Property(u => u.Address).HasMaxLength(20);
    }
}