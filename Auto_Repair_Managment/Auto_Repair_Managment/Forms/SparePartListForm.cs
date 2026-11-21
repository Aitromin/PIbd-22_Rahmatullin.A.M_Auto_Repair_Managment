using Auto_Repair_Managment.Entity;
using Auto_Repair_Managment.Repositories;

namespace Auto_Repair_Managment.Forms;

public partial class SparePartListForm : Form
{
    private readonly ISparePartRepository sparePartRepository;
    private readonly Func<SparePartEditForm> sparePartEditFormFactory;

    public SparePartListForm(ISparePartRepository sparePartRepository, Func<SparePartEditForm> sparePartEditFormFactory)
    {
        ArgumentNullException.ThrowIfNull(sparePartRepository);
        ArgumentNullException.ThrowIfNull(sparePartEditFormFactory);
        InitializeComponent();
        this.sparePartRepository = sparePartRepository;
        this.sparePartEditFormFactory = sparePartEditFormFactory;
        LoadSpareParts();
    }

    private void LoadSpareParts()
    {
        sparePartsGridView.Rows.Clear();
        foreach (SparePart sparePart in sparePartRepository.GetAll())
        {
            int rowIndex = sparePartsGridView.Rows.Add(
                sparePart.Article,
                sparePart.Name,
                sparePart.Price.ToString("N2"),
                sparePart.QuantityInStock);
            sparePartsGridView.Rows[rowIndex].Tag = sparePart;
        }
    }

    private SparePart? GetSelectedSparePart()
    {
        return sparePartsGridView.CurrentRow?.Tag as SparePart;
    }

    private void ShowEditForm(SparePart? sparePart)
    {
        using SparePartEditForm editForm = sparePartEditFormFactory();
        editForm.EditedSparePart = sparePart;
        if (editForm.ShowDialog(this) == DialogResult.OK)
        {
            LoadSpareParts();
        }
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        ShowEditForm(null);
    }

    private void EditButton_Click(object? sender, EventArgs e)
    {
        SparePart? sparePart = GetSelectedSparePart();
        if (sparePart == null)
        {
            MessageBox.Show("Выберите запчасть для редактирования.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        ShowEditForm(sparePart);
    }

    private void DeleteButton_Click(object? sender, EventArgs e)
    {
        SparePart? sparePart = GetSelectedSparePart();
        if (sparePart == null)
        {
            MessageBox.Show("Выберите запчасть для удаления.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        DialogResult answer = MessageBox.Show(
            $"Удалить запчасть «{sparePart.Name}» (артикул {sparePart.Article})?",
            Text,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (answer == DialogResult.Yes)
        {
            sparePartRepository.Delete(sparePart.Id);
            LoadSpareParts();
        }
    }
}
