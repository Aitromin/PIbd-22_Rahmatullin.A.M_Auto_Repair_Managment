using Auto_Repair_Managment.Enums;
using Auto_Repair_Managment.Entity;
using Auto_Repair_Managment.Repositories;

namespace Auto_Repair_Managment.Forms;

public partial class RepairOrderAddForm : Form
{
    private const string UnknownClientText = "Неизвестный клиент";

    private readonly IAppointmentRepository appointmentRepository;
    private readonly IClientRepository clientRepository;
    private readonly IWorkTypeRepository workTypeRepository;
    private readonly ISparePartRepository sparePartRepository;
    private readonly ISparePartUsageRepository sparePartUsageRepository;
    private readonly Dictionary<SparePart, int> usedParts = new();

    public RepairOrderAddForm(
        IAppointmentRepository appointmentRepository,
        IClientRepository clientRepository,
        IWorkTypeRepository workTypeRepository,
        ISparePartRepository sparePartRepository,
        ISparePartUsageRepository sparePartUsageRepository)
    {
        ArgumentNullException.ThrowIfNull(appointmentRepository);
        ArgumentNullException.ThrowIfNull(clientRepository);
        ArgumentNullException.ThrowIfNull(workTypeRepository);
        ArgumentNullException.ThrowIfNull(sparePartRepository);
        ArgumentNullException.ThrowIfNull(sparePartUsageRepository);
        InitializeComponent();
        this.appointmentRepository = appointmentRepository;
        this.clientRepository = clientRepository;
        this.workTypeRepository = workTypeRepository;
        this.sparePartRepository = sparePartRepository;
        this.sparePartUsageRepository = sparePartUsageRepository;
        FillAppointmentItems();
        FillWorkTypeItems();
        FillSparePartItems();
        RefreshTotalCost();
    }

    private void FillAppointmentItems()
    {
        Dictionary<int, Client> clientsById = clientRepository.GetAll().ToDictionary(client => client.Id);
        IEnumerable<Appointment> appointments = appointmentRepository.GetAll()
            .Where(appointment => appointment.Status != AppointmentStatus.Cancelled)
            .OrderBy(appointment => appointment.ScheduledAt);
        foreach (Appointment appointment in appointments)
        {
            string clientName = clientsById.GetValueOrDefault(appointment.ClientId)?.FullName ?? UnknownClientText;
            string itemText = $"{appointment.ScheduledAt:dd.MM.yyyy HH:mm} - {clientName}";
            appointmentComboBox.Items.Add(new LookupItem<Appointment>(itemText, appointment));
        }

        if (appointmentComboBox.Items.Count > 0)
        {
            appointmentComboBox.SelectedIndex = 0;
        }
    }

    private void FillWorkTypeItems()
    {
        foreach (WorkType workType in workTypeRepository.GetAll())
        {
            workTypeComboBox.Items.Add(new LookupItem<WorkType>(workType.Name, workType));
        }

        if (workTypeComboBox.Items.Count > 0)
        {
            workTypeComboBox.SelectedIndex = 0;
        }
    }

    private void FillSparePartItems()
    {
        foreach (SparePart sparePart in sparePartRepository.GetAll())
        {
            string itemText = $"{sparePart.Article} - {sparePart.Name} (остаток: {sparePart.QuantityInStock})";
            sparePartComboBox.Items.Add(new LookupItem<SparePart>(itemText, sparePart));
        }

        if (sparePartComboBox.Items.Count > 0)
        {
            sparePartComboBox.SelectedIndex = 0;
        }
    }

    private decimal CalculateTotalCost()
    {
        decimal workCost = (workTypeComboBox.SelectedItem as LookupItem<WorkType>)?.Value.Price ?? 0m;
        decimal partsCost = usedParts.Sum(usedPart => usedPart.Key.Price * usedPart.Value);
        return workCost + partsCost;
    }

    private void RefreshTotalCost()
    {
        totalCostValueLabel.Text = CalculateTotalCost().ToString("N2");
    }

    private void RefreshUsedParts()
    {
        usedPartsGridView.Rows.Clear();
        foreach ((SparePart sparePart, int quantity) in usedParts)
        {
            int rowIndex = usedPartsGridView.Rows.Add(
                sparePart.Article,
                sparePart.Name,
                quantity,
                (sparePart.Price * quantity).ToString("N2"));
            usedPartsGridView.Rows[rowIndex].Tag = sparePart;
        }

        RefreshTotalCost();
    }

    private void SaveRepairOrder()
    {
        int appointmentId = (appointmentComboBox.SelectedItem as LookupItem<Appointment>)?.Value.Id ?? 0;
        int workTypeId = (workTypeComboBox.SelectedItem as LookupItem<WorkType>)?.Value.Id ?? 0;
        RepairOrder repairOrder = RepairOrder.Create(
            appointmentId,
            workTypeId,
            completedAtDateTimePicker.Value.Date,
            CalculateTotalCost());

        sparePartUsageRepository.AddRepairOrderWithParts(repairOrder, usedParts);
    }

    private void WorkTypeComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        RefreshTotalCost();
    }

    private void AddPartButton_Click(object? sender, EventArgs e)
    {
        if (sparePartComboBox.SelectedItem is not LookupItem<SparePart> selectedItem)
        {
            MessageBox.Show("Выберите запчасть.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        SparePart sparePart = selectedItem.Value;
        usedParts.TryGetValue(sparePart, out int alreadyAddedQuantity);
        int requestedQuantity = alreadyAddedQuantity + (int)quantityNumericUpDown.Value;
        if (requestedQuantity > sparePart.QuantityInStock)
        {
            MessageBox.Show(
                $"Недостаточно запчастей на складе: «{sparePart.Name}» (остаток {sparePart.QuantityInStock}).",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        usedParts[sparePart] = requestedQuantity;
        RefreshUsedParts();
    }

    private void RemovePartButton_Click(object? sender, EventArgs e)
    {
        if (usedPartsGridView.CurrentRow?.Tag is not SparePart sparePart)
        {
            MessageBox.Show("Выберите запчасть в списке.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        usedParts.Remove(sparePart);
        RefreshUsedParts();
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        try
        {
            SaveRepairOrder();
        }
        catch (Exception exception) when (exception is ArgumentException or InvalidOperationException)
        {
            MessageBox.Show(exception.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
    }
}
