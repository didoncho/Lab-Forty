using Business;
using Microsoft.EntityFrameworkCore;
using Business.NewEntities;

namespace DatabaseLayer;

public class DataContext : DbContext
{
    public DbSet<User>  Users { get; set; }
    public DbSet<UserInformation>  UserInformations { get; set; }
    public DbSet<Products>  Products { get; set; }
    public DbSet<Order>   Orders { get; set; }
    public DbSet<Class1>  Class1s { get; set; }
    public DbSet<Class2>  Class2s { get; set; }
    public DbSet<Class3>  Class3s { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseInMemoryDatabase("AASAFSF");

        string connectionString = "Host=localhost;Port=3306;Username=root;Password=D!di2008;Database=Manjaro Local;";
        
        optionsBuilder.UseMySql(
            connectionString,
            //ServerVersion.AutoDetect(connectionString)
            new MariaDbServerVersion(new Version(12, 2, 2))
            );
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<UserInformation>().Property(u => u.Address).HasMaxLength(20);
    }
}