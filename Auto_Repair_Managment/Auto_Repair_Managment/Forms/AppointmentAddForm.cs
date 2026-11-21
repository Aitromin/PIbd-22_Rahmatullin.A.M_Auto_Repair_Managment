using Auto_Repair_Managment.Enums;
using Auto_Repair_Managment.Entity;
using Auto_Repair_Managment.Repositories;

namespace Auto_Repair_Managment.Forms;

public partial class AppointmentAddForm : Form
{
    private readonly IAppointmentRepository appointmentRepository;
    private readonly IClientRepository clientRepository;
    private readonly ICarRepository carRepository;
    private readonly IMechanicRepository mechanicRepository;

    public AppointmentAddForm(
        IAppointmentRepository appointmentRepository,
        IClientRepository clientRepository,
        ICarRepository carRepository,
        IMechanicRepository mechanicRepository)
    {
        ArgumentNullException.ThrowIfNull(appointmentRepository);
        ArgumentNullException.ThrowIfNull(clientRepository);
        ArgumentNullException.ThrowIfNull(carRepository);
        ArgumentNullException.ThrowIfNull(mechanicRepository);
        InitializeComponent();
        this.appointmentRepository = appointmentRepository;
        this.clientRepository = clientRepository;
        this.carRepository = carRepository;
        this.mechanicRepository = mechanicRepository;
        FillClientItems();
        FillMechanicItems();
        FillStatusItems();
    }

    private void FillClientItems()
    {
        foreach (Client client in clientRepository.GetAll())
        {
            clientComboBox.Items.Add(new LookupItem<Client>(client.FullName, client));
        }

        if (clientComboBox.Items.Count > 0)
        {
            clientComboBox.SelectedIndex = 0;
        }
    }

    private void FillCarItems()
    {
        carComboBox.Items.Clear();
        if (clientComboBox.SelectedItem is not LookupItem<Client> selectedClient)
        {
            return;
        }

        IEnumerable<Car> clientCars = carRepository.GetAll().Where(car => car.ClientId == selectedClient.Value.Id);
        foreach (Car car in clientCars)
        {
            carComboBox.Items.Add(new LookupItem<Car>($"{car.Brand} {car.Model}", car));
        }

        if (carComboBox.Items.Count > 0)
        {
            carComboBox.SelectedIndex = 0;
        }
    }

    private void FillMechanicItems()
    {
        foreach (Mechanic mechanic in mechanicRepository.GetAll())
        {
            mechanicComboBox.Items.Add(new LookupItem<Mechanic>(mechanic.FullName, mechanic));
        }

        if (mechanicComboBox.Items.Count > 0)
        {
            mechanicComboBox.SelectedIndex = 0;
        }
    }

    private void FillStatusItems()
    {
        foreach (AppointmentStatus status in Enum.GetValues<AppointmentStatus>())
        {
            statusComboBox.Items.Add(new LookupItem<AppointmentStatus>(status.ToString(), status));
        }

        statusComboBox.SelectedIndex = 0;
    }

    private void EnsureMechanicIsFree(Appointment appointment)
    {
        bool isMechanicBusy = appointmentRepository.GetAll().Any(existing =>
            existing.MechanicId == appointment.MechanicId
            && existing.ScheduledAt == appointment.ScheduledAt
            && existing.Status != AppointmentStatus.Cancelled);
        if (isMechanicBusy)
        {
            throw new ArgumentException("У выбранного механика уже есть запись на это время.");
        }
    }

    private void SaveAppointment()
    {
        int clientId = (clientComboBox.SelectedItem as LookupItem<Client>)?.Value.Id ?? 0;
        int carId = (carComboBox.SelectedItem as LookupItem<Car>)?.Value.Id ?? 0;
        int mechanicId = (mechanicComboBox.SelectedItem as LookupItem<Mechanic>)?.Value.Id ?? 0;
        AppointmentStatus status = (statusComboBox.SelectedItem as LookupItem<AppointmentStatus>)?.Value ?? default;
        DateTime selectedDateTime = scheduledAtDateTimePicker.Value;
        DateTime scheduledAt = new(
            selectedDateTime.Year,
            selectedDateTime.Month,
            selectedDateTime.Day,
            selectedDateTime.Hour,
            selectedDateTime.Minute,
            0);

        Appointment appointment = Appointment.Create(clientId, mechanicId, carId, scheduledAt, status);
        EnsureMechanicIsFree(appointment);
        appointmentRepository.Add(appointment);
    }

    private void ClientComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        FillCarItems();
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        try
        {
            SaveAppointment();
        }
        catch (ArgumentException exception)
        {
            MessageBox.Show(exception.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
    }
}
