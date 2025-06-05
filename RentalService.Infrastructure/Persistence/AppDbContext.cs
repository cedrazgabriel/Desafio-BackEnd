using Microsoft.EntityFrameworkCore;
using RentalService.Domain.Entities;

namespace RentalService.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Moto> Motorcycle  => Set<Moto>();
    public DbSet<Deliveryman> Deliverymen => Set<Deliveryman>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<NotificationEvent> NotificationEvents => Set<NotificationEvent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Moto>(e =>
        {
            e.ToTable("Motorcycles");
            e.HasKey(m => m.Id);
            e.Property(m => m.Model).IsRequired();
            e.Property(m => m.Year).IsRequired();
            e.Property<string>("_licensePlateValue")
                .HasColumnName("LicensePlate")
                .IsRequired();
            e.HasIndex("_licensePlateValue").IsUnique();
        });

        modelBuilder.Entity<Deliveryman>(e =>
        {
            e.ToTable("Deliverymen");
            e.HasKey(d => d.Id);
            e.Property(d => d.Name).IsRequired();
            e.Property<string>("_cnpjValue").HasColumnName("CNPJ").IsRequired();
            e.Property<string>("_cnhValue").HasColumnName("CNH").IsRequired();
            e.Property(d => d.BirthDate).IsRequired();
            e.Property(d => d.CnhType).IsRequired();
            e.HasIndex("_cnpjValue").IsUnique();
            e.HasIndex("_cnhValue").IsUnique();
        });

        modelBuilder.Entity<Location>(e =>
        {
            e.HasKey(l => l.Id);
            e.Property(l => l.MotorcycleId).IsRequired();
            e.Property(l => l.DeliveryManId).IsRequired();
            e.Property(l => l.Plan).IsRequired();
            e.Property(l => l.StartDate).IsRequired();
            e.Property(l => l.ExpectedEndDate).IsRequired();
        });

        modelBuilder.Entity<NotificationEvent>(e =>
        {
            e.HasKey(n => n.Id);
            e.Property(n => n.EventType).IsRequired();
            e.Property(n => n.Data).IsRequired();
            e.Property(n => n.RegisteredAt).IsRequired();
        });
    }
}
