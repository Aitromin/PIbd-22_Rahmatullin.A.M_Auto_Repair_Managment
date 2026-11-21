namespace Auto_Repair_Managment.Forms;

partial class WorkTypeListForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView workTypesGridView;
    private DataGridViewTextBoxColumn nameColumn;
    private DataGridViewTextBoxColumn normHoursColumn;
    private DataGridViewTextBoxColumn priceColumn;
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
        workTypesGridView = new DataGridView();
        nameColumn = new DataGridViewTextBoxColumn();
        normHoursColumn = new DataGridViewTextBoxColumn();
        priceColumn = new DataGridViewTextBoxColumn();
        buttonsPanel = new Panel();
        addButton = new Button();
        editButton = new Button();
        deleteButton = new Button();
        ((System.ComponentModel.ISupportInitialize)workTypesGridView).BeginInit();
        buttonsPanel.SuspendLayout();
        SuspendLayout();
        workTypesGridView.AllowUserToAddRows = false;
        workTypesGridView.AllowUserToDeleteRows = false;
        workTypesGridView.AllowUserToResizeRows = false;
        workTypesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        workTypesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        workTypesGridView.Dock = DockStyle.Fill;
        workTypesGridView.MultiSelect = false;
        workTypesGridView.Name = "workTypesGridView";
        workTypesGridView.ReadOnly = true;
        workTypesGridView.RowHeadersVisible = false;
        workTypesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        workTypesGridView.TabIndex = 0;
        workTypesGridView.Columns.AddRange(new DataGridViewColumn[] { nameColumn, normHoursColumn, priceColumn });
        nameColumn.HeaderText = "Наименование";
        nameColumn.Name = "nameColumn";
        normHoursColumn.HeaderText = "Нормо-часы";
        normHoursColumn.Name = "normHoursColumn";
        priceColumn.HeaderText = "Стоимость, руб.";
        priceColumn.Name = "priceColumn";
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
        Name = "WorkTypeListForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Виды работ";
        Controls.Add(workTypesGridView);
        Controls.Add(buttonsPanel);
        ((System.ComponentModel.ISupportInitialize)workTypesGridView).EndInit();
        buttonsPanel.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }
}
