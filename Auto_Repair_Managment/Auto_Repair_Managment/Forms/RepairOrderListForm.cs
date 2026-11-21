using Auto_Repair_Managment.Entity;
using Auto_Repair_Managment.Repositories;

namespace Auto_Repair_Managment.Forms;

public partial class RepairOrderListForm : Form
{
    private const string MissingValueText = "-";

    private readonly IRepairOrderRepository repairOrderRepository;
    private readonly IAppointmentRepository appointmentRepository;
    private readonly IClientRepository clientRepository;
    private readonly IWorkTypeRepository workTypeRepository;
    private readonly ISparePartRepository sparePartRepository;
    private readonly ISparePartUsageRepository sparePartUsageRepository;
    private readonly Func<RepairOrderAddForm> repairOrderAddFormFactory;

    public RepairOrderListForm(
        IRepairOrderRepository repairOrderRepository,
        IAppointmentRepository appointmentRepository,
        IClientRepository clientRepository,
        IWorkTypeRepository workTypeRepository,
        ISparePartRepository sparePartRepository,
        ISparePartUsageRepository sparePartUsageRepository,
        Func<RepairOrderAddForm> repairOrderAddFormFactory)
    {
        ArgumentNullException.ThrowIfNull(repairOrderRepository);
        ArgumentNullException.ThrowIfNull(appointmentRepository);
        ArgumentNullException.ThrowIfNull(clientRepository);
        ArgumentNullException.ThrowIfNull(workTypeRepository);
        ArgumentNullException.ThrowIfNull(sparePartRepository);
        ArgumentNullException.ThrowIfNull(sparePartUsageRepository);
        ArgumentNullException.ThrowIfNull(repairOrderAddFormFactory);
        InitializeComponent();
        this.repairOrderRepository = repairOrderRepository;
        this.appointmentRepository = appointmentRepository;
        this.clientRepository = clientRepository;
        this.workTypeRepository = workTypeRepository;
        this.sparePartRepository = sparePartRepository;
        this.sparePartUsageRepository = sparePartUsageRepository;
        this.repairOrderAddFormFactory = repairOrderAddFormFactory;
        LoadRepairOrders();
    }

    private void LoadRepairOrders()
    {
        Dictionary<int, Appointment> appointmentsById = appointmentRepository.GetAll().ToDictionary(item => item.Id);
        Dictionary<int, Client> clientsById = clientRepository.GetAll().ToDictionary(client => client.Id);
        Dictionary<int, WorkType> workTypesById = workTypeRepository.GetAll().ToDictionary(workType => workType.Id);
        Dictionary<int, SparePart> sparePartsById = sparePartRepository.GetAll().ToDictionary(sparePart => sparePart.Id);

        repairOrdersGridView.Rows.Clear();
        foreach (RepairOrder repairOrder in repairOrderRepository.GetAll().OrderBy(item => item.CompletedAt))
        {
            Appointment? appointment = appointmentsById.GetValueOrDefault(repairOrder.AppointmentId);
            string clientName = appointment == null
                ? MissingValueText
                : clientsById.GetValueOrDefault(appointment.ClientId)?.FullName ?? MissingValueText;
            int rowIndex = repairOrdersGridView.Rows.Add(
                repairOrder.Id,
                repairOrder.CompletedAt.ToString("dd.MM.yyyy"),
                clientName,
                workTypesById.GetValueOrDefault(repairOrder.WorkTypeId)?.Name ?? MissingValueText,
                DescribeUsedParts(repairOrder.Id, sparePartsById),
                repairOrder.TotalCost.ToString("N2"));
            repairOrdersGridView.Rows[rowIndex].Tag = repairOrder;
        }
    }

    private string DescribeUsedParts(int repairOrderId, Dictionary<int, SparePart> sparePartsById)
    {
        IEnumerable<string> descriptions = sparePartUsageRepository.GetByRepairOrderId(repairOrderId)
            .Select(usage =>
                $"{sparePartsById.GetValueOrDefault(usage.SparePartId)?.Name ?? MissingValueText}: {usage.Quantity} רע.");
        string usedParts = string.Join("; ", descriptions);
        return usedParts.Length > 0 ? usedParts : MissingValueText;
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        using RepairOrderAddForm addForm = repairOrderAddFormFactory();
        if (addForm.ShowDialog(this) == DialogResult.OK)
        {
            LoadRepairOrders();
        }
    }
}