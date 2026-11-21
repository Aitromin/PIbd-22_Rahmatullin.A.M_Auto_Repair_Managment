using Auto_Repair_Managment.Data;
using Auto_Repair_Managment.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class SparePartUsageRepository : ISparePartUsageRepository
{
    private readonly DataContext context;
    private readonly ILogger<SparePartUsageRepository> logger;

    public SparePartUsageRepository(DataContext context, ILogger<SparePartUsageRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(logger);
        this.context = context;
        this.logger = logger;
    }

    public IReadOnlyList<SparePartUsage> GetByRepairOrderId(int repairOrderId)
    {
        List<SparePartUsage> usages = context.SparePartUsages
            .AsNoTracking()
            .Where(usage => usage.RepairOrderId == repairOrderId)
            .ToList();
        logger.LogInformation("Для заказ-наряда {RepairOrderId} получено запчастей: {Count} шт.", repairOrderId, usages.Count);
        return usages;
    }

    public void AddRepairOrderWithParts(RepairOrder repairOrder, IReadOnlyDictionary<SparePart, int> usedParts)
    {
        ArgumentNullException.ThrowIfNull(repairOrder);
        ArgumentNullException.ThrowIfNull(usedParts);
        logger.LogInformation(
            "Создание заказ-наряда по записи {AppointmentId}: вид работы {WorkTypeId}, позиций запчастей {PartsCount}",
            repairOrder.AppointmentId,
            repairOrder.WorkTypeId,
            usedParts.Count);

        using IDbContextTransaction transaction = context.Database.BeginTransaction();
        try
        {
            context.RepairOrders.Add(repairOrder);
            context.SaveChanges();
            AddUsagesAndWriteOffStock(repairOrder, usedParts);
            context.SaveChanges();
            transaction.Commit();
        }
        catch (DbUpdateException exception)
        {
            DiscardChanges(exception, repairOrder);
            throw new InvalidOperationException("Не удалось сохранить заказ-наряд в базе данных.", exception);
        }
        catch (Exception exception)
        {
            DiscardChanges(exception, repairOrder);
            throw;
        }

        logger.LogInformation("Заказ-наряд Id={Id} создан, транзакция подтверждена", repairOrder.Id);
    }

    private void AddUsagesAndWriteOffStock(RepairOrder repairOrder, IReadOnlyDictionary<SparePart, int> usedParts)
    {
        foreach ((SparePart usedPart, int quantity) in usedParts)
        {
            SparePart storedPart = context.SpareParts.Find(usedPart.Id)
                ?? throw new InvalidOperationException($"Запчасть «{usedPart.Name}» не найдена в базе данных.");
            storedPart.WriteOff(quantity);
            context.SparePartUsages.Add(SparePartUsage.Create(repairOrder.Id, storedPart.Id, quantity));
            logger.LogInformation(
                "Запчасть Id={SparePartId} списана в количестве {Quantity}, остаток {QuantityInStock}",
                storedPart.Id,
                quantity,
                storedPart.QuantityInStock);
        }
    }

    private void DiscardChanges(Exception exception, RepairOrder repairOrder)
    {
        context.ChangeTracker.Clear();
        logger.LogError(
            exception,
            "Не удалось создать заказ-наряд по записи {AppointmentId}, транзакция отменена",
            repairOrder.AppointmentId);
    }
}
