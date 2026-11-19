namespace Auto_Repair_Managment.Forms;

partial class AppointmentAddForm
{
    private System.ComponentModel.IContainer components = null;
    private Label clientLabel;
    private ComboBox clientComboBox;
    private Label carLabel;
    private ComboBox carComboBox;
    private Label mechanicLabel;
    private ComboBox mechanicComboBox;
    private Label scheduledAtLabel;
    private DateTimePicker scheduledAtDateTimePicker;
    private Label statusLabel;
    private ComboBox statusComboBox;
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
        clientLabel = new Label();
        clientComboBox = new ComboBox();
        carLabel = new Label();
        carComboBox = new ComboBox();
        mechanicLabel = new Label();
        mechanicComboBox = new ComboBox();
        scheduledAtLabel = new Label();
        scheduledAtDateTimePicker = new DateTimePicker();
        statusLabel = new Label();
        statusComboBox = new ComboBox();
        saveButton = new Button();
        cancelButton = new Button();
        SuspendLayout();
        clientLabel.AutoSize = true;
        clientLabel.Location = new Point(12, 18);
        clientLabel.Name = "clientLabel";
        clientLabel.TabIndex = 0;
        clientLabel.Text = "Клиент:";
        clientComboBox.Location = new Point(150, 15);
        clientComboBox.Name = "clientComboBox";
        clientComboBox.Size = new Size(280, 23);
        clientComboBox.TabIndex = 1;
        clientComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        clientComboBox.SelectedIndexChanged += ClientComboBox_SelectedIndexChanged;
        carLabel.AutoSize = true;
        carLabel.Location = new Point(12, 53);
        carLabel.Name = "carLabel";
        carLabel.TabIndex = 2;
        carLabel.Text = "Автомобиль:";
        carComboBox.Location = new Point(150, 50);
        carComboBox.Name = "carComboBox";
        carComboBox.Size = new Size(280, 23);
        carComboBox.TabIndex = 3;
        carComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        mechanicLabel.AutoSize = true;
        mechanicLabel.Location = new Point(12, 88);
        mechanicLabel.Name = "mechanicLabel";
        mechanicLabel.TabIndex = 4;
        mechanicLabel.Text = "Механик:";
        mechanicComboBox.Location = new Point(150, 85);
        mechanicComboBox.Name = "mechanicComboBox";
        mechanicComboBox.Size = new Size(280, 23);
        mechanicComboBox.TabIndex = 5;
        mechanicComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        scheduledAtLabel.AutoSize = true;
        scheduledAtLabel.Location = new Point(12, 123);
        scheduledAtLabel.Name = "scheduledAtLabel";
        scheduledAtLabel.TabIndex = 6;
        scheduledAtLabel.Text = "Дата и время:";
        scheduledAtDateTimePicker.Location = new Point(150, 120);
        scheduledAtDateTimePicker.Name = "scheduledAtDateTimePicker";
        scheduledAtDateTimePicker.Size = new Size(280, 23);
        scheduledAtDateTimePicker.TabIndex = 7;
        scheduledAtDateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
        scheduledAtDateTimePicker.Format = DateTimePickerFormat.Custom;
        statusLabel.AutoSize = true;
        statusLabel.Location = new Point(12, 158);
        statusLabel.Name = "statusLabel";
        statusLabel.TabIndex = 8;
        statusLabel.Text = "Статус:";
        statusComboBox.Location = new Point(150, 155);
        statusComboBox.Name = "statusComboBox";
        statusComboBox.Size = new Size(280, 23);
        statusComboBox.TabIndex = 9;
        statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        saveButton.Location = new Point(250, 198);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(90, 30);
        saveButton.TabIndex = 10;
        saveButton.Text = "Сохранить";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += SaveButton_Click;
        cancelButton.DialogResult = DialogResult.Cancel;
        cancelButton.Location = new Point(348, 198);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new Size(90, 30);
        cancelButton.TabIndex = 11;
        cancelButton.Text = "Отмена";
        cancelButton.UseVisualStyleBackColor = true;
        AcceptButton = saveButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = cancelButton;
        ClientSize = new Size(450, 243);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AppointmentAddForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Новая запись на обслуживание";
        Controls.Add(clientLabel);
        Controls.Add(clientComboBox);
        Controls.Add(carLabel);
        Controls.Add(carComboBox);
        Controls.Add(mechanicLabel);
        Controls.Add(mechanicComboBox);
        Controls.Add(scheduledAtLabel);
        Controls.Add(scheduledAtDateTimePicker);
        Controls.Add(statusLabel);
        Controls.Add(statusComboBox);
        Controls.Add(saveButton);
        Controls.Add(cancelButton);
        ResumeLayout(false);
        PerformLayout();
    }
}
