namespace Auto_Repair_Managment.Entity;

public sealed class Client : EntityBase
{
    public string FullName { get; private set; }

    public string PhoneNumber { get; private set; }

    private Client(string fullName, string phoneNumber)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }

    public static Client Create(string fullName, string phoneNumber)
    {
        return new Client(
            Guard.RequireText(fullName, "ФИО клиента"),
            Guard.RequireText(phoneNumber, "Номер телефона", 20));
    }
}
