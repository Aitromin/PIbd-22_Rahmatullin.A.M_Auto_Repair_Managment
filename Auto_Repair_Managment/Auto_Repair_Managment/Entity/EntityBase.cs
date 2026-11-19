namespace Auto_Repair_Managment.Entity;

public abstract class EntityBase
{
    public int Id { get; private set; }

    internal void AssignId(int id)
    {
        Id = id;
    }
}
