using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto_Repair_Managment.Entity;

[Table("work_type")]
public sealed class WorkType : EntityBase
{
    [Required]
    [Column("name")]
    public string Name { get; private set; }

    [Column("norm_hours", TypeName = "numeric(10,2)")]
    public decimal NormHours { get; private set; }

    [Column("price", TypeName = "numeric(19,2)")]
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
