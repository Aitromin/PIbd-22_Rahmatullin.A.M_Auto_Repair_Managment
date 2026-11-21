using Auto_Repair_Managment.Enums;
using Auto_Repair_Managment.Entity;
using Auto_Repair_Managment.Repositories;

namespace Auto_Repair_Managment.Forms;

public partial class MechanicListForm : Form
{
    private readonly IMechanicRepository mechanicRepository;
    private readonly Func<MechanicEditForm> mechanicEditFormFactory;

    public MechanicListForm(IMechanicRepository mechanicRepository, Func<MechanicEditForm> mechanicEditFormFactory)
    {
        ArgumentNullException.ThrowIfNull(mechanicRepository);
        ArgumentNullException.ThrowIfNull(mechanicEditFormFactory);
        InitializeComponent();
        this.mechanicRepository = mechanicRepository;
        this.mechanicEditFormFactory = mechanicEditFormFactory;
        LoadMechanics();
    }

    private void LoadMechanics()
    {
        mechanicsGridView.Rows.Clear();
        foreach (Mechanic mechanic in mechanicRepository.GetAll())
        {
            int rowIndex = mechanicsGridView.Rows.Add(
                mechanic.FullName,
                 mechanic.Qualification.ToString(),
                 mechanic.Specialization.ToString(),
                 mechanic.ExperienceYears);
            mechanicsGridView.Rows[rowIndex].Tag = mechanic;
        }
    }

    private Mechanic? GetSelectedMechanic()
    {
        return mechanicsGridView.CurrentRow?.Tag as Mechanic;
    }

    private void ShowEditForm(Mechanic? mechanic)
    {
        using MechanicEditForm editForm = mechanicEditFormFactory();
        editForm.EditedMechanic = mechanic;
        if (editForm.ShowDialog(this) == DialogResult.OK)
        {
            LoadMechanics();
        }
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        ShowEditForm(null);
    }

    private void EditButton_Click(object? sender, EventArgs e)
    {
        Mechanic? mechanic = GetSelectedMechanic();
        if (mechanic == null)
        {
            MessageBox.Show("Выберите механика для редактирования.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        ShowEditForm(mechanic);
    }

    private void DeleteButton_Click(object? sender, EventArgs e)
    {
        Mechanic? mechanic = GetSelectedMechanic();
        if (mechanic == null)
        {
            MessageBox.Show("Выберите механика для удаления.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        DialogResult answer = MessageBox.Show(
            $"Удалить механика «{mechanic.FullName}»?",
            Text,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (answer == DialogResult.Yes)
        {
            mechanicRepository.Delete(mechanic.Id);
            LoadMechanics();
        }
    }
}
