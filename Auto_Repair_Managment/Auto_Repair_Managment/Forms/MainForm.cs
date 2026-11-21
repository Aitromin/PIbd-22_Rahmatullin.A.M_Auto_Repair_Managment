namespace Auto_Repair_Managment.Forms;

public partial class MainForm : Form
{
    private readonly Func<MechanicListForm> mechanicListFormFactory;
    private readonly Func<WorkTypeListForm> workTypeListFormFactory;
    private readonly Func<SparePartListForm> sparePartListFormFactory;
    private readonly Func<AppointmentListForm> appointmentListFormFactory;
    private readonly Func<RepairOrderListForm> repairOrderListFormFactory;

    public MainForm(
        Func<MechanicListForm> mechanicListFormFactory,
        Func<WorkTypeListForm> workTypeListFormFactory,
        Func<SparePartListForm> sparePartListFormFactory,
        Func<AppointmentListForm> appointmentListFormFactory,
        Func<RepairOrderListForm> repairOrderListFormFactory)
    {
        ArgumentNullException.ThrowIfNull(mechanicListFormFactory);
        ArgumentNullException.ThrowIfNull(workTypeListFormFactory);
        ArgumentNullException.ThrowIfNull(sparePartListFormFactory);
        ArgumentNullException.ThrowIfNull(appointmentListFormFactory);
        ArgumentNullException.ThrowIfNull(repairOrderListFormFactory);
        InitializeComponent();
        this.mechanicListFormFactory = mechanicListFormFactory;
        this.workTypeListFormFactory = workTypeListFormFactory;
        this.sparePartListFormFactory = sparePartListFormFactory;
        this.appointmentListFormFactory = appointmentListFormFactory;
        this.repairOrderListFormFactory = repairOrderListFormFactory;
    }

    private void ShowListForm<TForm>(Func<TForm> formFactory) where TForm : Form
    {
        using TForm form = formFactory();
        form.ShowDialog(this);
    }

    private void MechanicsMenuItem_Click(object? sender, EventArgs e)
    {
        ShowListForm(mechanicListFormFactory);
    }

    private void WorkTypesMenuItem_Click(object? sender, EventArgs e)
    {
        ShowListForm(workTypeListFormFactory);
    }

    private void SparePartsMenuItem_Click(object? sender, EventArgs e)
    {
        ShowListForm(sparePartListFormFactory);
    }

    private void AppointmentsMenuItem_Click(object? sender, EventArgs e)
    {
        ShowListForm(appointmentListFormFactory);
    }

    private void RepairOrdersMenuItem_Click(object? sender, EventArgs e)
    {
        ShowListForm(repairOrderListFormFactory);
    }
}
