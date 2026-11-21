using Auto_Repair_Managment.Data;
using Auto_Repair_Managment.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class WorkTypeRepository : IWorkTypeRepository
{
    private readonly DataContext context;
    private readonly ILogger<WorkTypeRepository> logger;

    public WorkTypeRepository(DataContext context, ILogger<WorkTypeRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(logger);
        this.context = context;
        this.logger = logger;
    }

    public IReadOnlyList<WorkType> GetAll()
    {
        List<WorkType> workTypes = context.WorkTypes
            .AsNoTracking()
            .OrderBy(workType => workType.Name)
            .ToList();
        logger.LogInformation("Получен список видов работ: {Count} шт.", workTypes.Count);
        return workTypes;
    }

    public WorkType? GetById(int id)
    {
        WorkType? workType = context.WorkTypes.AsNoTracking().FirstOrDefault(item => item.Id == id);
        logger.LogInformation("Поиск вида работы Id={Id}: {Result}", id, workType == null ? "не найден" : "найден");
        return workType;
    }

    public void Add(WorkType workType)
    {
        ArgumentNullException.ThrowIfNull(workType);
        logger.LogInformation(
            "Добавление вида работы: {Name}, {NormHours} н/ч, {Price} руб.",
            workType.Name,
            workType.NormHours,
            workType.Price);
        context.WorkTypes.Add(workType);
        context.SaveChanges();
        logger.LogInformation("Вид работы добавлен, Id={Id}", workType.Id);
    }

    public void Update(WorkType workType)
    {
        ArgumentNullException.ThrowIfNull(workType);
        logger.LogInformation("Изменение вида работы Id={Id}: {Name}", workType.Id, workType.Name);
        context.WorkTypes.Update(workType);
        context.SaveChanges();
        logger.LogInformation("Вид работы Id={Id} изменен", workType.Id);
    }

    public void Delete(int id)
    {
        logger.LogInformation("Удаление вида работы Id={Id}", id);
        WorkType? workType = context.WorkTypes.Find(id);
        if (workType == null)
        {
            logger.LogWarning("Вид работы Id={Id} для удаления не найден", id);
            return;
        }

        try
        {
            context.WorkTypes.Remove(workType);
            context.SaveChanges();
        }
        catch (DbUpdateException exception)
        {
            context.ChangeTracker.Clear();
            logger.LogWarning(exception, "Не удалось удалить вид работы Id={Id}", id);
            throw new InvalidOperationException(
                $"Нельзя удалить вид работы «{workType.Name}»: он указан в заказ-нарядах.",
                exception);
        }

        logger.LogInformation("Вид работы Id={Id} удален", id);
    }
}
