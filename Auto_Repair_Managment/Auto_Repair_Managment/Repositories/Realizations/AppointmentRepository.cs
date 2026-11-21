using Auto_Repair_Managment.Data;
using Auto_Repair_Managment.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class AppointmentRepository : IAppointmentRepository
{
    private readonly DataContext context;
    private readonly ILogger<AppointmentRepository> logger;

    public AppointmentRepository(DataContext context, ILogger<AppointmentRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(logger);
        this.context = context;
        this.logger = logger;
    }

    public IReadOnlyList<Appointment> GetAll()
    {
        List<Appointment> appointments = context.Appointments
            .AsNoTracking()
            .OrderBy(appointment => appointment.ScheduledAt)
            .ToList();
        logger.LogInformation("Получен список записей на обслуживание: {Count} шт.", appointments.Count);
        return appointments;
    }

    public Appointment? GetById(int id)
    {
        Appointment? appointment = context.Appointments.AsNoTracking().FirstOrDefault(item => item.Id == id);
        logger.LogInformation("Поиск записи Id={Id}: {Result}", id, appointment == null ? "не найдена" : "найдена");
        return appointment;
    }

    public void Add(Appointment appointment)
    {
        ArgumentNullException.ThrowIfNull(appointment);
        logger.LogInformation(
            "Добавление записи: клиент {ClientId}, автомобиль {CarId}, механик {MechanicId}, время {ScheduledAt}, статус {Status}",
            appointment.ClientId,
            appointment.CarId,
            appointment.MechanicId,
            appointment.ScheduledAt,
            appointment.Status);
        context.Appointments.Add(appointment);
        context.SaveChanges();
        logger.LogInformation("Запись добавлена, Id={Id}", appointment.Id);
    }
}
