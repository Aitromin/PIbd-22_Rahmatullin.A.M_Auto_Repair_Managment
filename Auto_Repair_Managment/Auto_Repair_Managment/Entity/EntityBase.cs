using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto_Repair_Managment.Entity;

public abstract class EntityBase
{
    [Key]
    [Column("id")]
    public int Id { get; private set; }
}
