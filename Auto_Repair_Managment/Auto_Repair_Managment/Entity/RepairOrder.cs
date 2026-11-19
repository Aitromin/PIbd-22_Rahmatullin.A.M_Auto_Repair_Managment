namespace Auto_Repair_Managment.Entity;

public sealed class RepairOrder : EntityBase
{
    public int AppointmentId { get; private set; }

    public int WorkTypeId { get; private set; }

    public DateTime CompletedAt { get; private set; }

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
