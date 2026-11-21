namespace Auto_Repair_Managment.Forms;

partial class MechanicEditForm
{
    private System.ComponentModel.IContainer components = null;
    private Label fullNameLabel;
    private TextBox fullNameTextBox;
    private Label qualificationLabel;
    private ComboBox qualificationComboBox;
    private Label experienceLabel;
    private NumericUpDown experienceNumericUpDown;
    private Label specializationLabel;
    private CheckedListBox specializationCheckedListBox;
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
        fullNameLabel = new Label();
        fullNameTextBox = new TextBox();
        qualificationLabel = new Label();
        qualificationComboBox = new ComboBox();
        experienceLabel = new Label();
        experienceNumericUpDown = new NumericUpDown();
        specializationLabel = new Label();
        specializationCheckedListBox = new CheckedListBox();
        saveButton = new Button();
        cancelButton = new Button();
        ((System.ComponentModel.ISupportInitialize)experienceNumericUpDown).BeginInit();
        SuspendLayout();
        fullNameLabel.AutoSize = true;
        fullNameLabel.Location = new Point(12, 18);
        fullNameLabel.Name = "fullNameLabel";
        fullNameLabel.TabIndex = 0;
        fullNameLabel.Text = "ФИО:";
        fullNameTextBox.Location = new Point(150, 15);
        fullNameTextBox.Name = "fullNameTextBox";
        fullNameTextBox.Size = new Size(280, 23);
        fullNameTextBox.TabIndex = 1;
        fullNameTextBox.MaxLength = 200;
        qualificationLabel.AutoSize = true;
        qualificationLabel.Location = new Point(12, 53);
        qualificationLabel.Name = "qualificationLabel";
        qualificationLabel.TabIndex = 2;
        qualificationLabel.Text = "Квалификация:";
        qualificationComboBox.Location = new Point(150, 50);
        qualificationComboBox.Name = "qualificationComboBox";
        qualificationComboBox.Size = new Size(280, 23);
        qualificationComboBox.TabIndex = 3;
        qualificationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        experienceLabel.AutoSize = true;
        experienceLabel.Location = new Point(12, 88);
        experienceLabel.Name = "experienceLabel";
        experienceLabel.TabIndex = 4;
        experienceLabel.Text = "Стаж (лет):";
        experienceNumericUpDown.Location = new Point(150, 85);
        experienceNumericUpDown.Name = "experienceNumericUpDown";
        experienceNumericUpDown.Size = new Size(280, 23);
        experienceNumericUpDown.TabIndex = 5;
        experienceNumericUpDown.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
        specializationLabel.AutoSize = true;
        specializationLabel.Location = new Point(12, 123);
        specializationLabel.Name = "specializationLabel";
        specializationLabel.TabIndex = 6;
        specializationLabel.Text = "Специализация:";
        specializationCheckedListBox.Location = new Point(150, 120);
        specializationCheckedListBox.Name = "specializationCheckedListBox";
        specializationCheckedListBox.Size = new Size(280, 110);
        specializationCheckedListBox.TabIndex = 7;
        specializationCheckedListBox.CheckOnClick = true;
        saveButton.Location = new Point(250, 250);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(90, 30);
        saveButton.TabIndex = 8;
        saveButton.Text = "Сохранить";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += SaveButton_Click;
        cancelButton.DialogResult = DialogResult.Cancel;
        cancelButton.Location = new Point(348, 250);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new Size(90, 30);
        cancelButton.TabIndex = 9;
        cancelButton.Text = "Отмена";
        cancelButton.UseVisualStyleBackColor = true;
        AcceptButton = saveButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = cancelButton;
        ClientSize = new Size(450, 295);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "MechanicEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Механик";
        Controls.Add(fullNameLabel);
        Controls.Add(fullNameTextBox);
        Controls.Add(qualificationLabel);
        Controls.Add(qualificationComboBox);
        Controls.Add(experienceLabel);
        Controls.Add(experienceNumericUpDown);
        Controls.Add(specializationLabel);
        Controls.Add(specializationCheckedListBox);
        Controls.Add(saveButton);
        Controls.Add(cancelButton);
        Load += MechanicEditForm_Load;
        ((System.ComponentModel.ISupportInitialize)experienceNumericUpDown).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
