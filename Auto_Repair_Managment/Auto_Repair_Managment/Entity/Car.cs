using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto_Repair_Managment.Entity;

[Table("car")]
public sealed class Car : EntityBase
{
    [ForeignKey(nameof(Client))]
    [Column("client_id")]
    public int ClientId { get; private set; }

    public Client? Client { get; private set; }

    [Required]
    [Column("brand")]
    public string Brand { get; private set; }

    [Required]
    [Column("model")]
    public string Model { get; private set; }

    private Car(int clientId, string brand, string model)
    {
        ClientId = clientId;
        Brand = brand;
        Model = model;
    }

    public static Car Create(int clientId, string brand, string model)
    {
        return new Car(
            Guard.RequireSelected(clientId, "Владелец"),
            Guard.RequireText(brand, "Марка"),
            Guard.RequireText(model, "Модель"));
    }
}
