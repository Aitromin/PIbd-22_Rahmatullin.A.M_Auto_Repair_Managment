using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories;

public interface IAppointmentRepository
{
    IReadOnlyList<Appointment> GetAll();

    Appointment? GetById(int id);

    void Add(Appointment appointment);
}
