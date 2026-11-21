using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class InMemoryStorage<TEntity> where TEntity : EntityBase
{
    private readonly List<TEntity> items = new();
    private int lastAssignedId;

    public IReadOnlyList<TEntity> GetAll()
    {
        return items.ToList();
    }

    public TEntity? GetById(int id)
    {
        return items.FirstOrDefault(item => item.Id == id);
    }

    public void Add(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        lastAssignedId++;
        entity.AssignId(lastAssignedId);
        items.Add(entity);
    }

    public void Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        int index = items.FindIndex(item => item.Id == entity.Id);
        if (index < 0)
        {
            throw new KeyNotFoundException($"Запись с идентификатором {entity.Id} не найдена.");
        }

        items[index] = entity;
    }

    public void Delete(int id)
    {
        items.RemoveAll(item => item.Id == id);
    }
}
