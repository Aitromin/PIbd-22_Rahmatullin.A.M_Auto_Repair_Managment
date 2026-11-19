using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class RepairOrderRepositoryStub : IRepairOrderRepository
{
    private readonly InMemoryStorage<RepairOrder> storage = new();

    public IReadOnlyList<RepairOrder> GetAll()
    {
        return storage.GetAll();
    }

    public RepairOrder? GetById(int id)
    {
        return storage.GetById(id);
    }

    public void Add(RepairOrder repairOrder)
    {
        storage.Add(repairOrder);
    }
}
