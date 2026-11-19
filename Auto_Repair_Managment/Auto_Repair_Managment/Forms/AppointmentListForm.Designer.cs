namespace Auto_Repair_Managment.Forms;

partial class AppointmentListForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView appointmentsGridView;
    private DataGridViewTextBoxColumn scheduledAtColumn;
    private DataGridViewTextBoxColumn clientColumn;
    private DataGridViewTextBoxColumn carColumn;
    private DataGridViewTextBoxColumn mechanicColumn;
    private DataGridViewTextBoxColumn statusColumn;
    private Panel buttonsPanel;
    private Button addButton;

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
        appointmentsGridView = new DataGridView();
        scheduledAtColumn = new DataGridViewTextBoxColumn();
        clientColumn = new DataGridViewTextBoxColumn();
        carColumn = new DataGridViewTextBoxColumn();
        mechanicColumn = new DataGridViewTextBoxColumn();
        statusColumn = new DataGridViewTextBoxColumn();
        buttonsPanel = new Panel();
        addButton = new Button();
        ((System.ComponentModel.ISupportInitialize)appointmentsGridView).BeginInit();
        buttonsPanel.SuspendLayout();
        SuspendLayout();
        appointmentsGridView.AllowUserToAddRows = false;
        appointmentsGridView.AllowUserToDeleteRows = false;
        appointmentsGridView.AllowUserToResizeRows = false;
        appointmentsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        appointmentsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        appointmentsGridView.Dock = DockStyle.Fill;
        appointmentsGridView.MultiSelect = false;
        appointmentsGridView.Name = "appointmentsGridView";
        appointmentsGridView.ReadOnly = true;
        appointmentsGridView.RowHeadersVisible = false;
        appointmentsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        appointmentsGridView.TabIndex = 0;
        appointmentsGridView.Columns.AddRange(new DataGridViewColumn[] { scheduledAtColumn, clientColumn, carColumn, mechanicColumn, statusColumn });
        scheduledAtColumn.HeaderText = "Дата и время";
        scheduledAtColumn.Name = "scheduledAtColumn";
        clientColumn.HeaderText = "Клиент";
        clientColumn.Name = "clientColumn";
        carColumn.HeaderText = "Автомобиль";
        carColumn.Name = "carColumn";
        mechanicColumn.HeaderText = "Механик";
        mechanicColumn.Name = "mechanicColumn";
        statusColumn.HeaderText = "Статус";
        statusColumn.Name = "statusColumn";
        buttonsPanel.Dock = DockStyle.Bottom;
        buttonsPanel.Name = "buttonsPanel";
        buttonsPanel.Size = new Size(720, 52);
        buttonsPanel.TabIndex = 1;
        buttonsPanel.Controls.Add(addButton);
        addButton.Location = new Point(12, 10);
        addButton.Name = "addButton";
        addButton.Size = new Size(110, 32);
        addButton.TabIndex = 0;
        addButton.Text = "Добавить";
        addButton.UseVisualStyleBackColor = true;
        addButton.Click += AddButton_Click;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(720, 420);
        MinimumSize = new Size(520, 300);
        Name = "AppointmentListForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Записи на обслуживание";
        Controls.Add(appointmentsGridView);
        Controls.Add(buttonsPanel);
        ((System.ComponentModel.ISupportInitialize)appointmentsGridView).EndInit();
        buttonsPanel.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }
}
