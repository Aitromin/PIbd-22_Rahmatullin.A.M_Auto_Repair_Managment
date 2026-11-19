using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class SparePartUsageRepositoryStub : ISparePartUsageRepository
{
    private readonly List<SparePartUsage> items = new();

    public IReadOnlyList<SparePartUsage> GetByRepairOrderId(int repairOrderId)
    {
        return items.Where(item => item.RepairOrderId == repairOrderId).ToList();
    }

    public void Add(SparePartUsage sparePartUsage)
    {
        ArgumentNullException.ThrowIfNull(sparePartUsage);
        items.Add(sparePartUsage);
    }
}
