using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories;

public interface IMechanicRepository
{
    IReadOnlyList<Mechanic> GetAll();

    Mechanic? GetById(int id);

    void Add(Mechanic mechanic);

    void Update(Mechanic mechanic);

    void Delete(int id);
}
