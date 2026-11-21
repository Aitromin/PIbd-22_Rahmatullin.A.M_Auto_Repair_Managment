using System.ComponentModel.DataAnnotations.Schema;

namespace Auto_Repair_Managment.Entity;

[Table("repair_order")]
public sealed class RepairOrder : EntityBase
{
    [ForeignKey(nameof(Appointment))]
    [Column("appointment_id")]
    public int AppointmentId { get; private set; }

    public Appointment? Appointment { get; private set; }

    [ForeignKey(nameof(WorkType))]
    [Column("work_type_id")]
    public int WorkTypeId { get; private set; }

    public WorkType? WorkType { get; private set; }

    [Column("completed_at", TypeName = "date")]
    public DateTime CompletedAt { get; private set; }

    [Column("total_cost", TypeName = "numeric(19,2)")]
    public decimal TotalCost { get; private set; }

    private RepairOrder(int appointmentId, int workTypeId, DateTime completedAt, decimal totalCost)
    {
        AppointmentId = appointmentId;
        WorkTypeId = workTypeId;
        CompletedAt = completedAt;
        TotalCost = totalCost;
    }

    public static RepairOrder Create(int appointmentId, int workTypeId, DateTime completedAt, decimal totalCost)
    {
        return new RepairOrder(
            Guard.RequireSelected(appointmentId, "Запись на обслуживание"),
            Guard.RequireSelected(workTypeId, "Вид работы"),
            completedAt,
            Guard.RequireNonNegative(totalCost, "Итоговая стоимость"));
    }
}
