using System.ComponentModel.DataAnnotations.Schema;

namespace Auto_Repair_Managment.Entity;

[Table("spare_part_usage")]
public sealed class SparePartUsage
{
    [ForeignKey(nameof(RepairOrder))]
    [Column("repair_order_id")]
    public int RepairOrderId { get; private set; }

    public RepairOrder? RepairOrder { get; private set; }

    [ForeignKey(nameof(SparePart))]
    [Column("spare_part_id")]
    public int SparePartId { get; private set; }

    public SparePart? SparePart { get; private set; }

    [Column("quantity")]
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
