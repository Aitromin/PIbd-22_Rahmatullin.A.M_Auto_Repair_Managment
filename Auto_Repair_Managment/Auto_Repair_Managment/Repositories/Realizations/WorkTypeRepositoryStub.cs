using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class WorkTypeRepositoryStub : IWorkTypeRepository
{
    private readonly InMemoryStorage<WorkType> storage = new();

    public IReadOnlyList<WorkType> GetAll()
    {
        return storage.GetAll();
    }

    public WorkType? GetById(int id)
    {
        return storage.GetById(id);
    }

    public void Add(WorkType workType)
    {
        storage.Add(workType);
    }

    public void Update(WorkType workType)
    {
        storage.Update(workType);
    }

    public void Delete(int id)
    {
        storage.Delete(id);
    }
}
