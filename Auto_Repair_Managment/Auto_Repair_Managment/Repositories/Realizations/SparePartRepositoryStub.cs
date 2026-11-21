using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class SparePartRepositoryStub : ISparePartRepository
{
    private readonly InMemoryStorage<SparePart> storage = new();

    public IReadOnlyList<SparePart> GetAll()
    {
        return storage.GetAll();
    }

    public SparePart? GetById(int id)
    {
        return storage.GetById(id);
    }

    public void Add(SparePart sparePart)
    {
        storage.Add(sparePart);
    }

    public void Update(SparePart sparePart)
    {
        storage.Update(sparePart);
    }

    public void Delete(int id)
    {
        storage.Delete(id);
    }
}
