using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories;

public interface IRepairOrderRepository
{
    IReadOnlyList<RepairOrder> GetAll();

    RepairOrder? GetById(int id);

    void Add(RepairOrder repairOrder);
}
