using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto_Repair_Managment.Entity;

[Table("client")]
public sealed class Client : EntityBase
{
    [Required]
    [Column("full_name")]
    public string FullName { get; private set; }

    [Required]
    [MaxLength(20)]
    [Column("phone_number")]
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
