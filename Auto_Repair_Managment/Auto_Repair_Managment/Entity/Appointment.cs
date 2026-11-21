using Auto_Repair_Managment.Enums;

namespace Auto_Repair_Managment.Entity;

public sealed class Appointment : EntityBase
{
    public int ClientId { get; private set; }

    public int MechanicId { get; private set; }

    public int CarId { get; private set; }

    public DateTime ScheduledAt { get; private set; }

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
