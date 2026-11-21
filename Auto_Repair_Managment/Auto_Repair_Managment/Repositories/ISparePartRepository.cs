using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories;

public interface ISparePartRepository
{
    IReadOnlyList<SparePart> GetAll();

    SparePart? GetById(int id);

    void Add(SparePart sparePart);

    void Update(SparePart sparePart);

    void Delete(int id);
}
