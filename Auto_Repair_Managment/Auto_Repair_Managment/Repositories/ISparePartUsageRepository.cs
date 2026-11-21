using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories;

public interface ISparePartUsageRepository
{
    IReadOnlyList<SparePartUsage> GetByRepairOrderId(int repairOrderId);

    void Add(SparePartUsage sparePartUsage);
}
