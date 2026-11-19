namespace Auto_Repair_Managment.Forms;

partial class RepairOrderListForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView repairOrdersGridView;
    private DataGridViewTextBoxColumn numberColumn;
    private DataGridViewTextBoxColumn completedAtColumn;
    private DataGridViewTextBoxColumn clientColumn;
    private DataGridViewTextBoxColumn workTypeColumn;
    private DataGridViewTextBoxColumn totalCostColumn;
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
        repairOrdersGridView = new DataGridView();
        numberColumn = new DataGridViewTextBoxColumn();
        completedAtColumn = new DataGridViewTextBoxColumn();
        clientColumn = new DataGridViewTextBoxColumn();
        workTypeColumn = new DataGridViewTextBoxColumn();
        totalCostColumn = new DataGridViewTextBoxColumn();
        buttonsPanel = new Panel();
        addButton = new Button();
        ((System.ComponentModel.ISupportInitialize)repairOrdersGridView).BeginInit();
        buttonsPanel.SuspendLayout();
        SuspendLayout();
        repairOrdersGridView.AllowUserToAddRows = false;
        repairOrdersGridView.AllowUserToDeleteRows = false;
        repairOrdersGridView.AllowUserToResizeRows = false;
        repairOrdersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        repairOrdersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        repairOrdersGridView.Dock = DockStyle.Fill;
        repairOrdersGridView.MultiSelect = false;
        repairOrdersGridView.Name = "repairOrdersGridView";
        repairOrdersGridView.ReadOnly = true;
        repairOrdersGridView.RowHeadersVisible = false;
        repairOrdersGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        repairOrdersGridView.TabIndex = 0;
        repairOrdersGridView.Columns.AddRange(new DataGridViewColumn[] { numberColumn, completedAtColumn, clientColumn, workTypeColumn, totalCostColumn });
        numberColumn.HeaderText = "№";
        numberColumn.Name = "numberColumn";
        completedAtColumn.HeaderText = "Дата выполнения";
        completedAtColumn.Name = "completedAtColumn";
        clientColumn.HeaderText = "Клиент";
        clientColumn.Name = "clientColumn";
        workTypeColumn.HeaderText = "Вид работы";
        workTypeColumn.Name = "workTypeColumn";
        totalCostColumn.HeaderText = "Итоговая стоимость, руб.";
        totalCostColumn.Name = "totalCostColumn";
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
        Name = "RepairOrderListForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Заказ-наряды";
        Controls.Add(repairOrdersGridView);
        Controls.Add(buttonsPanel);
        ((System.ComponentModel.ISupportInitialize)repairOrdersGridView).EndInit();
        buttonsPanel.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }
}
