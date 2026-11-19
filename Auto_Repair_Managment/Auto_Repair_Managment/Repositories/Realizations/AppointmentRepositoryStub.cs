using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class AppointmentRepositoryStub : IAppointmentRepository
{
    private readonly InMemoryStorage<Appointment> storage = new();

    public IReadOnlyList<Appointment> GetAll()
    {
        return storage.GetAll();
    }

    public Appointment? GetById(int id)
    {
        return storage.GetById(id);
    }

    public void Add(Appointment appointment)
    {
        storage.Add(appointment);
    }
}
