namespace Auto_Repair_Managment.Entity;

public sealed class WorkType : EntityBase
{
    public string Name { get; private set; }

    public decimal NormHours { get; private set; }

    public decimal Price { get; private set; }

    private WorkType(string name, decimal normHours, decimal price)
    {
        Name = name;
        NormHours = normHours;
        Price = price;
    }

    public static WorkType Create(string name, decimal normHours, decimal price)
    {
        return new WorkType(
            Guard.RequireText(name, "Наименование работы"),
            Guard.RequirePositive(normHours, "Нормо-часы"),
            Guard.RequireNonNegative(price, "Стоимость"));
    }

    public void Update(string name, decimal normHours, decimal price)
    {
        string validatedName = Guard.RequireText(name, "Наименование работы");
        decimal validatedNormHours = Guard.RequirePositive(normHours, "Нормо-часы");
        decimal validatedPrice = Guard.RequireNonNegative(price, "Стоимость");
        Name = validatedName;
        NormHours = validatedNormHours;
        Price = validatedPrice;
    }
}
