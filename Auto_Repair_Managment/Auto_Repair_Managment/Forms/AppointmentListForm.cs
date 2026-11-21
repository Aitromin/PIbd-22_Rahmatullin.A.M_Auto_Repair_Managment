using Auto_Repair_Managment.Enums;
using Auto_Repair_Managment.Entity;
using Auto_Repair_Managment.Repositories;

namespace Auto_Repair_Managment.Forms;

public partial class AppointmentListForm : Form
{
    private const string MissingValueText = "-";

    private readonly IAppointmentRepository appointmentRepository;
    private readonly IClientRepository clientRepository;
    private readonly ICarRepository carRepository;
    private readonly IMechanicRepository mechanicRepository;
    private readonly Func<AppointmentAddForm> appointmentAddFormFactory;

    public AppointmentListForm(
        IAppointmentRepository appointmentRepository,
        IClientRepository clientRepository,
        ICarRepository carRepository,
        IMechanicRepository mechanicRepository,
        Func<AppointmentAddForm> appointmentAddFormFactory)
    {
        ArgumentNullException.ThrowIfNull(appointmentRepository);
        ArgumentNullException.ThrowIfNull(clientRepository);
        ArgumentNullException.ThrowIfNull(carRepository);
        ArgumentNullException.ThrowIfNull(mechanicRepository);
        ArgumentNullException.ThrowIfNull(appointmentAddFormFactory);
        InitializeComponent();
        this.appointmentRepository = appointmentRepository;
        this.clientRepository = clientRepository;
        this.carRepository = carRepository;
        this.mechanicRepository = mechanicRepository;
        this.appointmentAddFormFactory = appointmentAddFormFactory;
        LoadAppointments();
    }

    private void LoadAppointments()
    {
        Dictionary<int, Client> clientsById = clientRepository.GetAll().ToDictionary(client => client.Id);
        Dictionary<int, Car> carsById = carRepository.GetAll().ToDictionary(car => car.Id);
        Dictionary<int, Mechanic> mechanicsById = mechanicRepository.GetAll().ToDictionary(mechanic => mechanic.Id);

        appointmentsGridView.Rows.Clear();
        foreach (Appointment appointment in appointmentRepository.GetAll().OrderBy(item => item.ScheduledAt))
        {
            Car? car = carsById.GetValueOrDefault(appointment.CarId);
            string carText = car == null ? MissingValueText : $"{car.Brand} {car.Model}";
            int rowIndex = appointmentsGridView.Rows.Add(
                appointment.ScheduledAt.ToString("dd.MM.yyyy HH:mm"),
                clientsById.GetValueOrDefault(appointment.ClientId)?.FullName ?? MissingValueText,
                carText,
                mechanicsById.GetValueOrDefault(appointment.MechanicId)?.FullName ?? MissingValueText,
                appointment.Status.ToString());
            appointmentsGridView.Rows[rowIndex].Tag = appointment;
        }
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        using AppointmentAddForm addForm = appointmentAddFormFactory();
        if (addForm.ShowDialog(this) == DialogResult.OK)
        {
            LoadAppointments();
        }
    }
}
