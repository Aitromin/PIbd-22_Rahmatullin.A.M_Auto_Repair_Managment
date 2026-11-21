using System.ComponentModel.DataAnnotations.Schema;
using Auto_Repair_Managment.Enums;

namespace Auto_Repair_Managment.Entity;

[Table("appointment")]
public sealed class Appointment : EntityBase
{
    [ForeignKey(nameof(Client))]
    [Column("client_id")]
    public int ClientId { get; private set; }

    public Client? Client { get; private set; }

    [ForeignKey(nameof(Mechanic))]
    [Column("mechanic_id")]
    public int MechanicId { get; private set; }

    public Mechanic? Mechanic { get; private set; }

    [ForeignKey(nameof(Car))]
    [Column("car_id")]
    public int CarId { get; private set; }

    public Car? Car { get; private set; }

    [Column("date_time", TypeName = "timestamp without time zone")]
    public DateTime ScheduledAt { get; private set; }

    [Column("status")]
    public AppointmentStatus Status { get; private set; }

    private Appointment(int clientId, int mechanicId, int carId, DateTime scheduledAt, AppointmentStatus status)
    {
        ClientId = clientId;
        MechanicId = mechanicId;
        CarId = carId;
        ScheduledAt = scheduledAt;
        Status = status;
    }

    public static Appointment Create(
        int clientId,
        int mechanicId,
        int carId,
        DateTime scheduledAt,
        AppointmentStatus status)
    {
        return new Appointment(
            Guard.RequireSelected(clientId, "Клиент"),
            Guard.RequireSelected(mechanicId, "Механик"),
            Guard.RequireSelected(carId, "Автомобиль"),
            scheduledAt,
            Guard.RequireDefined(status, "Статус"));
    }
}
