namespace Auto_Repair_Managment.Entity;

public sealed class Car : EntityBase
{
    public int ClientId { get; private set; }

    public string Brand { get; private set; }

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
