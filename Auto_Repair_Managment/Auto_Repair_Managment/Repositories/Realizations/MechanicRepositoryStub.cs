using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class MechanicRepositoryStub : IMechanicRepository
{
    private readonly InMemoryStorage<Mechanic> storage = new();

    public IReadOnlyList<Mechanic> GetAll()
    {
        return storage.GetAll();
    }

    public Mechanic? GetById(int id)
    {
        return storage.GetById(id);
    }

    public void Add(Mechanic mechanic)
    {
        storage.Add(mechanic);
    }

    public void Update(Mechanic mechanic)
    {
        storage.Update(mechanic);
    }

    public void Delete(int id)
    {
        storage.Delete(id);
    }
}
