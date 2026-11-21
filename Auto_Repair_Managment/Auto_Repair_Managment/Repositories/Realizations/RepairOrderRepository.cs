using Auto_Repair_Managment.Data;
using Auto_Repair_Managment.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class RepairOrderRepository : IRepairOrderRepository
{
    private readonly DataContext context;
    private readonly ILogger<RepairOrderRepository> logger;

    public RepairOrderRepository(DataContext context, ILogger<RepairOrderRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(logger);
        this.context = context;
        this.logger = logger;
    }

    public IReadOnlyList<RepairOrder> GetAll()
    {
        List<RepairOrder> repairOrders = context.RepairOrders
            .AsNoTracking()
            .OrderBy(repairOrder => repairOrder.CompletedAt)
            .ToList();
        logger.LogInformation("Получен список заказ-нарядов: {Count} шт.", repairOrders.Count);
        return repairOrders;
    }

    public RepairOrder? GetById(int id)
    {
        RepairOrder? repairOrder = context.RepairOrders.AsNoTracking().FirstOrDefault(item => item.Id == id);
        logger.LogInformation("Поиск заказ-наряда Id={Id}: {Result}", id, repairOrder == null ? "не найден" : "найден");
        return repairOrder;
    }

    public void Add(RepairOrder repairOrder)
    {
        ArgumentNullException.ThrowIfNull(repairOrder);
        logger.LogInformation(
            "Добавление заказ-наряда: запись {AppointmentId}, вид работы {WorkTypeId}, стоимость {TotalCost}",
            repairOrder.AppointmentId,
            repairOrder.WorkTypeId,
            repairOrder.TotalCost);
        context.RepairOrders.Add(repairOrder);
        context.SaveChanges();
        logger.LogInformation("Заказ-наряд добавлен, Id={Id}", repairOrder.Id);
    }
}
