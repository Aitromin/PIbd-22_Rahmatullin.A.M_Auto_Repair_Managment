namespace Auto_Repair_Managment.Forms;

partial class RepairOrderListForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView repairOrdersGridView;
    private DataGridViewTextBoxColumn numberColumn;
    private DataGridViewTextBoxColumn completedAtColumn;
    private DataGridViewTextBoxColumn clientColumn;
    private DataGridViewTextBoxColumn workTypeColumn;
    private DataGridViewTextBoxColumn sparePartsColumn;
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
        sparePartsColumn = new DataGridViewTextBoxColumn();
        buttonsPanel = new Panel();
        addButton = new Button();
        ((System.ComponentModel.ISupportInitialize)repairOrdersGridView).BeginInit();
        buttonsPanel.SuspendLayout();
        SuspendLayout();
        // 
        // repairOrdersGridView
        // 
        repairOrdersGridView.AllowUserToAddRows = false;
        repairOrdersGridView.AllowUserToDeleteRows = false;
        repairOrdersGridView.AllowUserToResizeRows = false;
        repairOrdersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        repairOrdersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        repairOrdersGridView.Columns.AddRange(new DataGridViewColumn[] { numberColumn, completedAtColumn, clientColumn, workTypeColumn, sparePartsColumn, totalCostColumn });
        repairOrdersGridView.Dock = DockStyle.Fill;
        repairOrdersGridView.Location = new Point(0, 0);
        repairOrdersGridView.Margin = new Padding(3, 4, 3, 4);
        repairOrdersGridView.MultiSelect = false;
        repairOrdersGridView.Name = "repairOrdersGridView";
        repairOrdersGridView.ReadOnly = true;
        repairOrdersGridView.RowHeadersVisible = false;
        repairOrdersGridView.RowHeadersWidth = 51;
        repairOrdersGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        repairOrdersGridView.Size = new Size(823, 491);
        repairOrdersGridView.TabIndex = 0;
        // 
        // numberColumn
        // 
        numberColumn.HeaderText = "№";
        numberColumn.MinimumWidth = 6;
        numberColumn.Name = "numberColumn";
        numberColumn.ReadOnly = true;
        // 
        // completedAtColumn
        // 
        completedAtColumn.HeaderText = "Дата выполнения";
        completedAtColumn.MinimumWidth = 6;
        completedAtColumn.Name = "completedAtColumn";
        completedAtColumn.ReadOnly = true;
        // 
        // clientColumn
        // 
        clientColumn.HeaderText = "Клиент";
        clientColumn.MinimumWidth = 6;
        clientColumn.Name = "clientColumn";
        clientColumn.ReadOnly = true;
        // 
        // workTypeColumn
        // 
        workTypeColumn.HeaderText = "Вид работы";
        workTypeColumn.MinimumWidth = 6;
        workTypeColumn.Name = "workTypeColumn";
        workTypeColumn.ReadOnly = true;
        //
        //sparePartsColumn
        //
        sparePartsColumn.HeaderText = "Запчасти";
        sparePartsColumn.MinimumWidth = 6;
        sparePartsColumn.Name = "sparePartsColumn";
        sparePartsColumn.ReadOnly = true;
        // 
        // totalCostColumn
        // 

        totalCostColumn.HeaderText = "Итоговая стоимость, руб.";
        totalCostColumn.MinimumWidth = 6;
        totalCostColumn.Name = "totalCostColumn";
        totalCostColumn.ReadOnly = true;
        // 
        // buttonsPanel
        // 
        buttonsPanel.Controls.Add(addButton);
        buttonsPanel.Dock = DockStyle.Bottom;
        buttonsPanel.Location = new Point(0, 491);
        buttonsPanel.Margin = new Padding(3, 4, 3, 4);
        buttonsPanel.Name = "buttonsPanel";
        buttonsPanel.Size = new Size(823, 69);
        buttonsPanel.TabIndex = 1;
        // 
        // addButton
        // 
        addButton.Location = new Point(14, 13);
        addButton.Margin = new Padding(3, 4, 3, 4);
        addButton.Name = "addButton";
        addButton.Size = new Size(126, 43);
        addButton.TabIndex = 0;
        addButton.Text = "Добавить";
        addButton.UseVisualStyleBackColor = true;
        addButton.Click += AddButton_Click;
        // 
        // RepairOrderListForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(823, 560);
        Controls.Add(repairOrdersGridView);
        Controls.Add(buttonsPanel);
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(592, 384);
        Name = "RepairOrderListForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Заказ-наряды";
        ((System.ComponentModel.ISupportInitialize)repairOrdersGridView).EndInit();
        buttonsPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
}
