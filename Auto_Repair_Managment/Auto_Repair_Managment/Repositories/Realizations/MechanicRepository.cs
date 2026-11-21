using Auto_Repair_Managment.Data;
using Auto_Repair_Managment.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class MechanicRepository : IMechanicRepository
{
    private readonly DataContext context;
    private readonly ILogger<MechanicRepository> logger;

    public MechanicRepository(DataContext context, ILogger<MechanicRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(logger);
        this.context = context;
        this.logger = logger;
    }

    public IReadOnlyList<Mechanic> GetAll()
    {
        List<Mechanic> mechanics = context.Mechanics
            .AsNoTracking()
            .OrderBy(mechanic => mechanic.FullName)
            .ToList();
        logger.LogInformation("Получен список механиков: {Count} шт.", mechanics.Count);
        return mechanics;
    }

    public Mechanic? GetById(int id)
    {
        Mechanic? mechanic = context.Mechanics.AsNoTracking().FirstOrDefault(item => item.Id == id);
        logger.LogInformation("Поиск механика Id={Id}: {Result}", id, mechanic == null ? "не найден" : "найден");
        return mechanic;
    }

    public void Add(Mechanic mechanic)
    {
        ArgumentNullException.ThrowIfNull(mechanic);
        logger.LogInformation("Добавление механика: {FullName}, квалификация {Qualification}", mechanic.FullName, mechanic.Qualification);
        context.Mechanics.Add(mechanic);
        context.SaveChanges();
        logger.LogInformation("Механик добавлен, Id={Id}", mechanic.Id);
    }

    public void Update(Mechanic mechanic)
    {
        ArgumentNullException.ThrowIfNull(mechanic);
        logger.LogInformation("Изменение механика Id={Id}: {FullName}", mechanic.Id, mechanic.FullName);
        context.Mechanics.Update(mechanic);
        context.SaveChanges();
        logger.LogInformation("Механик Id={Id} изменен", mechanic.Id);
    }

    public void Delete(int id)
    {
        logger.LogInformation("Удаление механика Id={Id}", id);
        Mechanic? mechanic = context.Mechanics.Find(id);
        if (mechanic == null)
        {
            logger.LogWarning("Механик Id={Id} для удаления не найден", id);
            return;
        }

        try
        {
            context.Mechanics.Remove(mechanic);
            context.SaveChanges();
        }
        catch (DbUpdateException exception)
        {
            context.ChangeTracker.Clear();
            logger.LogWarning(exception, "Не удалось удалить механика Id={Id}", id);
            throw new InvalidOperationException(
                $"Нельзя удалить механика «{mechanic.FullName}»: он указан в записях на обслуживание.",
                exception);
        }

        logger.LogInformation("Механик Id={Id} удален", id);
    }
}
