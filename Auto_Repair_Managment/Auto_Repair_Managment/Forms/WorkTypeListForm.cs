using Auto_Repair_Managment.Entity;
using Auto_Repair_Managment.Repositories;

namespace Auto_Repair_Managment.Forms;

public partial class WorkTypeListForm : Form
{
    private readonly IWorkTypeRepository workTypeRepository;
    private readonly Func<WorkTypeEditForm> workTypeEditFormFactory;

    public WorkTypeListForm(IWorkTypeRepository workTypeRepository, Func<WorkTypeEditForm> workTypeEditFormFactory)
    {
        ArgumentNullException.ThrowIfNull(workTypeRepository);
        ArgumentNullException.ThrowIfNull(workTypeEditFormFactory);
        InitializeComponent();
        this.workTypeRepository = workTypeRepository;
        this.workTypeEditFormFactory = workTypeEditFormFactory;
        LoadWorkTypes();
    }

    private void LoadWorkTypes()
    {
        workTypesGridView.Rows.Clear();
        foreach (WorkType workType in workTypeRepository.GetAll())
        {
            int rowIndex = workTypesGridView.Rows.Add(
                workType.Name,
                workType.NormHours.ToString("N2"),
                workType.Price.ToString("N2"));
            workTypesGridView.Rows[rowIndex].Tag = workType;
        }
    }

    private WorkType? GetSelectedWorkType()
    {
        return workTypesGridView.CurrentRow?.Tag as WorkType;
    }

    private void ShowEditForm(WorkType? workType)
    {
        using WorkTypeEditForm editForm = workTypeEditFormFactory();
        editForm.EditedWorkType = workType;
        if (editForm.ShowDialog(this) == DialogResult.OK)
        {
            LoadWorkTypes();
        }
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        ShowEditForm(null);
    }

    private void EditButton_Click(object? sender, EventArgs e)
    {
        WorkType? workType = GetSelectedWorkType();
        if (workType == null)
        {
            MessageBox.Show("Выберите вид работы для редактирования.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        ShowEditForm(workType);
    }

    private void DeleteButton_Click(object? sender, EventArgs e)
    {
        WorkType? workType = GetSelectedWorkType();
        if (workType == null)
        {
            MessageBox.Show("Выберите вид работы для удаления.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        DialogResult answer = MessageBox.Show(
            $"Удалить вид работы «{workType.Name}»?",
            Text,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (answer == DialogResult.Yes)
        {
            workTypeRepository.Delete(workType.Id);
            LoadWorkTypes();
        }
    }
}
