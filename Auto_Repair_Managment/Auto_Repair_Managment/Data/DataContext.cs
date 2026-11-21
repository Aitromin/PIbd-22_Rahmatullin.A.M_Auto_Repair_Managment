using Auto_Repair_Managment.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Auto_Repair_Managment.Data;

public class DataContext : DbContext
{
    private const string ConnectionString =
        "Host=localhost;Port=5432;Database=auto_repair;Username=Airat;Password=12345678";

    public DbSet<Client> Clients => Set<Client>();

    public DbSet<Car> Cars => Set<Car>();

    public DbSet<Mechanic> Mechanics => Set<Mechanic>();

    public DbSet<WorkType> WorkTypes => Set<WorkType>();

    public DbSet<SparePart> SpareParts => Set<SparePart>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<RepairOrder> RepairOrders => Set<RepairOrder>();

    public DbSet<SparePartUsage> SparePartUsages => Set<SparePartUsage>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(ConnectionString)
            .LogTo(message => Log.Information("{EntityFrameworkMessage}", message), LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureOneToManyRelations(modelBuilder);
        ConfigureSparePartUsage(modelBuilder);
        SeedClientsAndCars(modelBuilder);
    }

    private static void ConfigureOneToManyRelations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasOne(car => car.Client)
            .WithMany()
            .HasForeignKey(car => car.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>(appointment =>
        {
            appointment.HasOne(item => item.Client)
                .WithMany()
                .HasForeignKey(item => item.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
            appointment.HasOne(item => item.Mechanic)
                .WithMany()
                .HasForeignKey(item => item.MechanicId)
                .OnDelete(DeleteBehavior.Restrict);
            appointment.HasOne(item => item.Car)
                .WithMany()
                .HasForeignKey(item => item.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<RepairOrder>(repairOrder =>
        {
            repairOrder.HasOne(item => item.Appointment)
                .WithMany()
                .HasForeignKey(item => item.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);
            repairOrder.HasOne(item => item.WorkType)
                .WithMany()
                .HasForeignKey(item => item.WorkTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureSparePartUsage(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SparePartUsage>(usage =>
        {
            usage.HasKey(item => new { item.RepairOrderId, item.SparePartId });
            usage.HasOne(item => item.RepairOrder)
                .WithMany()
                .HasForeignKey(item => item.RepairOrderId)
                .OnDelete(DeleteBehavior.Cascade);
            usage.HasOne(item => item.SparePart)
                .WithMany()
                .HasForeignKey(item => item.SparePartId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void SeedClientsAndCars(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(
            new { Id = 1, FullName = "Иванов Иван Петрович", PhoneNumber = "+7 900 111-22-33" },
            new { Id = 2, FullName = "Петрова Анна Сергеевна", PhoneNumber = "+7 900 222-33-44" },
            new { Id = 3, FullName = "Сидоров Алексей Николаевич", PhoneNumber = "+7 900 333-44-55" });

        modelBuilder.Entity<Car>().HasData(
            new { Id = 1, ClientId = 1, Brand = "Toyota", Model = "Camry" },
            new { Id = 2, ClientId = 1, Brand = "Kia", Model = "Rio" },
            new { Id = 3, ClientId = 2, Brand = "Lada", Model = "Vesta" },
            new { Id = 4, ClientId = 3, Brand = "Volkswagen", Model = "Polo" });
    }
}
