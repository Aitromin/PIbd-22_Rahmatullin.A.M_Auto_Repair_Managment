namespace Auto_Repair_Managment.Entity;

public sealed class SparePartUsage
{
    public int RepairOrderId { get; private set; }

    public int SparePartId { get; private set; }

    public int Quantity { get; private set; }

    private SparePartUsage(int repairOrderId, int sparePartId, int quantity)
    {
        RepairOrderId = repairOrderId;
        SparePartId = sparePartId;
        Quantity = quantity;
    }

    public static SparePartUsage Create(int repairOrderId, int sparePartId, int quantity)
    {
        return new SparePartUsage(
            Guard.RequireSelected(repairOrderId, "Заказ-наряд"),
            Guard.RequireSelected(sparePartId, "Запчасть"),
            Guard.RequirePositive(quantity, "Количество"));
    }
}
