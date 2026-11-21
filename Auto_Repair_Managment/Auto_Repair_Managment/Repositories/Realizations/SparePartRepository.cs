using Auto_Repair_Managment.Data;
using Auto_Repair_Managment.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class SparePartRepository : ISparePartRepository
{
    private readonly DataContext context;
    private readonly ILogger<SparePartRepository> logger;

    public SparePartRepository(DataContext context, ILogger<SparePartRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(logger);
        this.context = context;
        this.logger = logger;
    }

    public IReadOnlyList<SparePart> GetAll()
    {
        List<SparePart> spareParts = context.SpareParts
            .AsNoTracking()
            .OrderBy(sparePart => sparePart.Name)
            .ToList();
        logger.LogInformation("Получен список запчастей: {Count} шт.", spareParts.Count);
        return spareParts;
    }

    public SparePart? GetById(int id)
    {
        SparePart? sparePart = context.SpareParts.AsNoTracking().FirstOrDefault(item => item.Id == id);
        logger.LogInformation("Поиск запчасти Id={Id}: {Result}", id, sparePart == null ? "не найдена" : "найдена");
        return sparePart;
    }

    public void Add(SparePart sparePart)
    {
        ArgumentNullException.ThrowIfNull(sparePart);
        logger.LogInformation(
            "Добавление запчасти: артикул {Article}, {Name}, остаток {QuantityInStock}",
            sparePart.Article,
            sparePart.Name,
            sparePart.QuantityInStock);
        context.SpareParts.Add(sparePart);
        context.SaveChanges();
        logger.LogInformation("Запчасть добавлена, Id={Id}", sparePart.Id);
    }

    public void Update(SparePart sparePart)
    {
        ArgumentNullException.ThrowIfNull(sparePart);
        logger.LogInformation(
            "Изменение запчасти Id={Id}: артикул {Article}, остаток {QuantityInStock}",
            sparePart.Id,
            sparePart.Article,
            sparePart.QuantityInStock);
        context.SpareParts.Update(sparePart);
        context.SaveChanges();
        logger.LogInformation("Запчасть Id={Id} изменена", sparePart.Id);
    }

    public void Delete(int id)
    {
        logger.LogInformation("Удаление запчасти Id={Id}", id);
        SparePart? sparePart = context.SpareParts.Find(id);
        if (sparePart == null)
        {
            logger.LogWarning("Запчасть Id={Id} для удаления не найдена", id);
            return;
        }

        try
        {
            context.SpareParts.Remove(sparePart);
            context.SaveChanges();
        }
        catch (DbUpdateException exception)
        {
            context.ChangeTracker.Clear();
            logger.LogWarning(exception, "Не удалось удалить запчасть Id={Id}", id);
            throw new InvalidOperationException(
                $"Нельзя удалить запчасть «{sparePart.Name}»: она использована в заказ-нарядах.",
                exception);
        }

        logger.LogInformation("Запчасть Id={Id} удалена", id);
    }
}
