namespace Auto_Repair_Managment.Forms;

partial class SparePartEditForm
{
    private System.ComponentModel.IContainer components = null;
    private Label articleLabel;
    private TextBox articleTextBox;
    private Label nameLabel;
    private TextBox nameTextBox;
    private Label priceLabel;
    private NumericUpDown priceNumericUpDown;
    private Label quantityInStockLabel;
    private NumericUpDown quantityInStockNumericUpDown;
    private Button saveButton;
    private Button cancelButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        articleLabel = new Label();
        articleTextBox = new TextBox();
        nameLabel = new Label();
        nameTextBox = new TextBox();
        priceLabel = new Label();
        priceNumericUpDown = new NumericUpDown();
        quantityInStockLabel = new Label();
        quantityInStockNumericUpDown = new NumericUpDown();
        saveButton = new Button();
        cancelButton = new Button();
        ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)quantityInStockNumericUpDown).BeginInit();
        SuspendLayout();
        articleLabel.AutoSize = true;
        articleLabel.Location = new Point(12, 18);
        articleLabel.Name = "articleLabel";
        articleLabel.TabIndex = 0;
        articleLabel.Text = "Артикул:";
        articleTextBox.Location = new Point(150, 15);
        articleTextBox.Name = "articleTextBox";
        articleTextBox.Size = new Size(280, 23);
        articleTextBox.TabIndex = 1;
        articleTextBox.MaxLength = 50;
        nameLabel.AutoSize = true;
        nameLabel.Location = new Point(12, 53);
        nameLabel.Name = "nameLabel";
        nameLabel.TabIndex = 2;
        nameLabel.Text = "Наименование:";
        nameTextBox.Location = new Point(150, 50);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new Size(280, 23);
        nameTextBox.TabIndex = 3;
        nameTextBox.MaxLength = 200;
        priceLabel.AutoSize = true;
        priceLabel.Location = new Point(12, 88);
        priceLabel.Name = "priceLabel";
        priceLabel.TabIndex = 4;
        priceLabel.Text = "Цена, руб.:";
        priceNumericUpDown.Location = new Point(150, 85);
        priceNumericUpDown.Name = "priceNumericUpDown";
        priceNumericUpDown.Size = new Size(280, 23);
        priceNumericUpDown.TabIndex = 5;
        priceNumericUpDown.DecimalPlaces = 2;
        priceNumericUpDown.Increment = new decimal(new int[] { 100, 0, 0, 0 });
        priceNumericUpDown.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        quantityInStockLabel.AutoSize = true;
        quantityInStockLabel.Location = new Point(12, 123);
        quantityInStockLabel.Name = "quantityInStockLabel";
        quantityInStockLabel.TabIndex = 6;
        quantityInStockLabel.Text = "Остаток на складе:";
        quantityInStockNumericUpDown.Location = new Point(150, 120);
        quantityInStockNumericUpDown.Name = "quantityInStockNumericUpDown";
        quantityInStockNumericUpDown.Size = new Size(280, 23);
        quantityInStockNumericUpDown.TabIndex = 7;
        quantityInStockNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        saveButton.Location = new Point(250, 163);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(90, 30);
        saveButton.TabIndex = 8;
        saveButton.Text = "Сохранить";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += SaveButton_Click;
        cancelButton.DialogResult = DialogResult.Cancel;
        cancelButton.Location = new Point(348, 163);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new Size(90, 30);
        cancelButton.TabIndex = 9;
        cancelButton.Text = "Отмена";
        cancelButton.UseVisualStyleBackColor = true;
        AcceptButton = saveButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = cancelButton;
        ClientSize = new Size(450, 208);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SparePartEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Запчасть";
        Controls.Add(articleLabel);
        Controls.Add(articleTextBox);
        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(priceLabel);
        Controls.Add(priceNumericUpDown);
        Controls.Add(quantityInStockLabel);
        Controls.Add(quantityInStockNumericUpDown);
        Controls.Add(saveButton);
        Controls.Add(cancelButton);
        Load += SparePartEditForm_Load;
        ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)quantityInStockNumericUpDown).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
