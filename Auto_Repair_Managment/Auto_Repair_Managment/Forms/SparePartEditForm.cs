using Auto_Repair_Managment.Entity;
using Auto_Repair_Managment.Repositories;

namespace Auto_Repair_Managment.Forms;

public partial class SparePartEditForm : Form
{
    private readonly ISparePartRepository sparePartRepository;

    public SparePart? EditedSparePart { get; set; }

    public SparePartEditForm(ISparePartRepository sparePartRepository)
    {
        ArgumentNullException.ThrowIfNull(sparePartRepository);
        InitializeComponent();
        this.sparePartRepository = sparePartRepository;
    }

    private void SaveSparePart()
    {
        string article = articleTextBox.Text;
        string name = nameTextBox.Text;
        decimal price = priceNumericUpDown.Value;
        int quantityInStock = (int)quantityInStockNumericUpDown.Value;

        if (EditedSparePart == null)
        {
            sparePartRepository.Add(SparePart.Create(article, name, price, quantityInStock));
        }
        else
        {
            EditedSparePart.Update(article, name, price, quantityInStock);
            sparePartRepository.Update(EditedSparePart);
        }
    }

    private void SparePartEditForm_Load(object? sender, EventArgs e)
    {
        if (EditedSparePart == null)
        {
            Text = "Новая запчасть";
            return;
        }

        Text = "Редактирование запчасти";
        articleTextBox.Text = EditedSparePart.Article;
        nameTextBox.Text = EditedSparePart.Name;
        priceNumericUpDown.Value = EditedSparePart.Price;
        quantityInStockNumericUpDown.Value = EditedSparePart.QuantityInStock;
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        try
        {
            SaveSparePart();
        }
        catch (ArgumentException exception)
        {
            MessageBox.Show(exception.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
    }
}
