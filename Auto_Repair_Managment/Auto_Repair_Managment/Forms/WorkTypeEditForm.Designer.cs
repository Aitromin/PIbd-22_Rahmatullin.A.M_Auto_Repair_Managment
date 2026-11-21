namespace Auto_Repair_Managment.Forms;

partial class WorkTypeEditForm
{
    private System.ComponentModel.IContainer components = null;
    private Label nameLabel;
    private TextBox nameTextBox;
    private Label normHoursLabel;
    private NumericUpDown normHoursNumericUpDown;
    private Label priceLabel;
    private NumericUpDown priceNumericUpDown;
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
        nameLabel = new Label();
        nameTextBox = new TextBox();
        normHoursLabel = new Label();
        normHoursNumericUpDown = new NumericUpDown();
        priceLabel = new Label();
        priceNumericUpDown = new NumericUpDown();
        saveButton = new Button();
        cancelButton = new Button();
        ((System.ComponentModel.ISupportInitialize)normHoursNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).BeginInit();
        SuspendLayout();
        nameLabel.AutoSize = true;
        nameLabel.Location = new Point(12, 18);
        nameLabel.Name = "nameLabel";
        nameLabel.TabIndex = 0;
        nameLabel.Text = "Наименование:";
        nameTextBox.Location = new Point(150, 15);
        nameTextBox.Name = "nameTextBox";
        nameTextBox.Size = new Size(280, 23);
        nameTextBox.TabIndex = 1;
        nameTextBox.MaxLength = 200;
        normHoursLabel.AutoSize = true;
        normHoursLabel.Location = new Point(12, 53);
        normHoursLabel.Name = "normHoursLabel";
        normHoursLabel.TabIndex = 2;
        normHoursLabel.Text = "Нормо-часы:";
        normHoursNumericUpDown.Location = new Point(150, 50);
        normHoursNumericUpDown.Name = "normHoursNumericUpDown";
        normHoursNumericUpDown.Size = new Size(280, 23);
        normHoursNumericUpDown.TabIndex = 3;
        normHoursNumericUpDown.DecimalPlaces = 2;
        normHoursNumericUpDown.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
        normHoursNumericUpDown.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
        priceLabel.AutoSize = true;
        priceLabel.Location = new Point(12, 88);
        priceLabel.Name = "priceLabel";
        priceLabel.TabIndex = 4;
        priceLabel.Text = "Стоимость, руб.:";
        priceNumericUpDown.Location = new Point(150, 85);
        priceNumericUpDown.Name = "priceNumericUpDown";
        priceNumericUpDown.Size = new Size(280, 23);
        priceNumericUpDown.TabIndex = 5;
        priceNumericUpDown.DecimalPlaces = 2;
        priceNumericUpDown.Increment = new decimal(new int[] { 100, 0, 0, 0 });
        priceNumericUpDown.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        saveButton.Location = new Point(250, 128);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(90, 30);
        saveButton.TabIndex = 6;
        saveButton.Text = "Сохранить";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += SaveButton_Click;
        cancelButton.DialogResult = DialogResult.Cancel;
        cancelButton.Location = new Point(348, 128);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new Size(90, 30);
        cancelButton.TabIndex = 7;
        cancelButton.Text = "Отмена";
        cancelButton.UseVisualStyleBackColor = true;
        AcceptButton = saveButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = cancelButton;
        ClientSize = new Size(450, 173);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "WorkTypeEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Вид работы";
        Controls.Add(nameLabel);
        Controls.Add(nameTextBox);
        Controls.Add(normHoursLabel);
        Controls.Add(normHoursNumericUpDown);
        Controls.Add(priceLabel);
        Controls.Add(priceNumericUpDown);
        Controls.Add(saveButton);
        Controls.Add(cancelButton);
        Load += WorkTypeEditForm_Load;
        ((System.ComponentModel.ISupportInitialize)normHoursNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
