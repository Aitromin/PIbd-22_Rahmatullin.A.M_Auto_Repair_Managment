using Auto_Repair_Managment.Enums;
using Auto_Repair_Managment.Entity;
using Auto_Repair_Managment.Repositories;

namespace Auto_Repair_Managment.Forms;

public partial class MechanicEditForm : Form
{
    private readonly IMechanicRepository mechanicRepository;

    public Mechanic? EditedMechanic { get; set; }

    public MechanicEditForm(IMechanicRepository mechanicRepository)
    {
        ArgumentNullException.ThrowIfNull(mechanicRepository);
        InitializeComponent();
        this.mechanicRepository = mechanicRepository;
        FillQualificationItems();
        FillSpecializationItems();
    }

    private void FillQualificationItems()
    {
        foreach (QualificationLevel qualification in Enum.GetValues<QualificationLevel>())
        {
            qualificationComboBox.Items.Add(new LookupItem<QualificationLevel>(qualification.ToString(), qualification));
        }

        qualificationComboBox.SelectedIndex = 0;
    }

    private void FillSpecializationItems()
    {
        IEnumerable<MechanicSpecialization> specializations = Enum.GetValues<MechanicSpecialization>()
            .Where(specialization => specialization != MechanicSpecialization.None);
        foreach (MechanicSpecialization specialization in specializations)
        {
            specializationCheckedListBox.Items.Add(new LookupItem<MechanicSpecialization>(specialization.ToString(), specialization));
        }
    }

    private void ShowEditedMechanic(Mechanic mechanic)
    {
        fullNameTextBox.Text = mechanic.FullName;
        experienceNumericUpDown.Value = mechanic.ExperienceYears;
        qualificationComboBox.SelectedItem = qualificationComboBox.Items
            .Cast<LookupItem<QualificationLevel>>()
            .First(item => item.Value == mechanic.Qualification);
        for (int index = 0; index < specializationCheckedListBox.Items.Count; index++)
        {
            var item = (LookupItem<MechanicSpecialization>)specializationCheckedListBox.Items[index];
            specializationCheckedListBox.SetItemChecked(index, mechanic.Specialization.HasFlag(item.Value));
        }
    }

    private void SaveMechanic()
    {
        string fullName = fullNameTextBox.Text;
        QualificationLevel qualification = (qualificationComboBox.SelectedItem as LookupItem<QualificationLevel>)?.Value ?? default;
        MechanicSpecialization specialization = specializationCheckedListBox.CheckedItems
            .Cast<LookupItem<MechanicSpecialization>>()
            .Aggregate(MechanicSpecialization.None, (selected, item) => selected | item.Value);
        int experienceYears = (int)experienceNumericUpDown.Value;

        if (EditedMechanic == null)
        {
            mechanicRepository.Add(Mechanic.Create(fullName, qualification, specialization, experienceYears));
        }
        else
        {
            EditedMechanic.Update(fullName, qualification, specialization, experienceYears);
            mechanicRepository.Update(EditedMechanic);
        }
    }

    private void MechanicEditForm_Load(object? sender, EventArgs e)
    {
        if (EditedMechanic == null)
        {
            Text = "Новый механик";
            return;
        }

        Text = "Редактирование механика";
        ShowEditedMechanic(EditedMechanic);
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        try
        {
            SaveMechanic();
        }
        catch (ArgumentException exception)
        {
            MessageBox.Show(exception.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
    }
}
