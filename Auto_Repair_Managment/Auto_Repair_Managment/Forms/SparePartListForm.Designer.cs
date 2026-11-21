namespace Auto_Repair_Managment.Forms;

partial class SparePartListForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView sparePartsGridView;
    private DataGridViewTextBoxColumn articleColumn;
    private DataGridViewTextBoxColumn nameColumn;
    private DataGridViewTextBoxColumn priceColumn;
    private DataGridViewTextBoxColumn quantityInStockColumn;
    private Panel buttonsPanel;
    private Button addButton;
    private Button editButton;
    private Button deleteButton;

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
        sparePartsGridView = new DataGridView();
        articleColumn = new DataGridViewTextBoxColumn();
        nameColumn = new DataGridViewTextBoxColumn();
        priceColumn = new DataGridViewTextBoxColumn();
        quantityInStockColumn = new DataGridViewTextBoxColumn();
        buttonsPanel = new Panel();
        addButton = new Button();
        editButton = new Button();
        deleteButton = new Button();
        ((System.ComponentModel.ISupportInitialize)sparePartsGridView).BeginInit();
        buttonsPanel.SuspendLayout();
        SuspendLayout();
        sparePartsGridView.AllowUserToAddRows = false;
        sparePartsGridView.AllowUserToDeleteRows = false;
        sparePartsGridView.AllowUserToResizeRows = false;
        sparePartsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        sparePartsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        sparePartsGridView.Dock = DockStyle.Fill;
        sparePartsGridView.MultiSelect = false;
        sparePartsGridView.Name = "sparePartsGridView";
        sparePartsGridView.ReadOnly = true;
        sparePartsGridView.RowHeadersVisible = false;
        sparePartsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        sparePartsGridView.TabIndex = 0;
        sparePartsGridView.Columns.AddRange(new DataGridViewColumn[] { articleColumn, nameColumn, priceColumn, quantityInStockColumn });
        articleColumn.HeaderText = "Артикул";
        articleColumn.Name = "articleColumn";
        nameColumn.HeaderText = "Наименование";
        nameColumn.Name = "nameColumn";
        priceColumn.HeaderText = "Цена, руб.";
        priceColumn.Name = "priceColumn";
        quantityInStockColumn.HeaderText = "Остаток на складе";
        quantityInStockColumn.Name = "quantityInStockColumn";
        buttonsPanel.Dock = DockStyle.Bottom;
        buttonsPanel.Name = "buttonsPanel";
        buttonsPanel.Size = new Size(720, 52);
        buttonsPanel.TabIndex = 1;
        buttonsPanel.Controls.Add(addButton);
        buttonsPanel.Controls.Add(editButton);
        buttonsPanel.Controls.Add(deleteButton);
        addButton.Location = new Point(12, 10);
        addButton.Name = "addButton";
        addButton.Size = new Size(110, 32);
        addButton.TabIndex = 0;
        addButton.Text = "Добавить";
        addButton.UseVisualStyleBackColor = true;
        addButton.Click += AddButton_Click;
        editButton.Location = new Point(134, 10);
        editButton.Name = "editButton";
        editButton.Size = new Size(110, 32);
        editButton.TabIndex = 1;
        editButton.Text = "Изменить";
        editButton.UseVisualStyleBackColor = true;
        editButton.Click += EditButton_Click;
        deleteButton.Location = new Point(256, 10);
        deleteButton.Name = "deleteButton";
        deleteButton.Size = new Size(110, 32);
        deleteButton.TabIndex = 2;
        deleteButton.Text = "Удалить";
        deleteButton.UseVisualStyleBackColor = true;
        deleteButton.Click += DeleteButton_Click;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(720, 420);
        MinimumSize = new Size(520, 300);
        Name = "SparePartListForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Запчасти";
        Controls.Add(sparePartsGridView);
        Controls.Add(buttonsPanel);
        ((System.ComponentModel.ISupportInitialize)sparePartsGridView).EndInit();
        buttonsPanel.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }
}
