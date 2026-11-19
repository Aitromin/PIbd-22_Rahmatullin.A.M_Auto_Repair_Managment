using Auto_Repair_Managment.Entity;
using Auto_Repair_Managment.Repositories;

namespace Auto_Repair_Managment.Forms;

public partial class WorkTypeEditForm : Form
{
    private readonly IWorkTypeRepository workTypeRepository;

    public WorkType? EditedWorkType { get; set; }

    public WorkTypeEditForm(IWorkTypeRepository workTypeRepository)
    {
        ArgumentNullException.ThrowIfNull(workTypeRepository);
        InitializeComponent();
        this.workTypeRepository = workTypeRepository;
    }

    private void SaveWorkType()
    {
        string name = nameTextBox.Text;
        decimal normHours = normHoursNumericUpDown.Value;
        decimal price = priceNumericUpDown.Value;

        if (EditedWorkType == null)
        {
            workTypeRepository.Add(WorkType.Create(name, normHours, price));
        }
        else
        {
            EditedWorkType.Update(name, normHours, price);
            workTypeRepository.Update(EditedWorkType);
        }
    }

    private void WorkTypeEditForm_Load(object? sender, EventArgs e)
    {
        if (EditedWorkType == null)
        {
            Text = "Новый вид работы";
            return;
        }

        Text = "Редактирование вида работы";
        nameTextBox.Text = EditedWorkType.Name;
        normHoursNumericUpDown.Value = EditedWorkType.NormHours;
        priceNumericUpDown.Value = EditedWorkType.Price;
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        try
        {
            SaveWorkType();
        }
        catch (ArgumentException exception)
        {
            MessageBox.Show(exception.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
    }
}
