namespace Auto_Repair_Managment.Forms;

partial class MechanicListForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView mechanicsGridView;
    private DataGridViewTextBoxColumn fullNameColumn;
    private DataGridViewTextBoxColumn qualificationColumn;
    private DataGridViewTextBoxColumn specializationColumn;
    private DataGridViewTextBoxColumn experienceColumn;
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
        mechanicsGridView = new DataGridView();
        fullNameColumn = new DataGridViewTextBoxColumn();
        qualificationColumn = new DataGridViewTextBoxColumn();
        specializationColumn = new DataGridViewTextBoxColumn();
        experienceColumn = new DataGridViewTextBoxColumn();
        buttonsPanel = new Panel();
        addButton = new Button();
        editButton = new Button();
        deleteButton = new Button();
        ((System.ComponentModel.ISupportInitialize)mechanicsGridView).BeginInit();
        buttonsPanel.SuspendLayout();
        SuspendLayout();
        mechanicsGridView.AllowUserToAddRows = false;
        mechanicsGridView.AllowUserToDeleteRows = false;
        mechanicsGridView.AllowUserToResizeRows = false;
        mechanicsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        mechanicsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        mechanicsGridView.Dock = DockStyle.Fill;
        mechanicsGridView.MultiSelect = false;
        mechanicsGridView.Name = "mechanicsGridView";
        mechanicsGridView.ReadOnly = true;
        mechanicsGridView.RowHeadersVisible = false;
        mechanicsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        mechanicsGridView.TabIndex = 0;
        mechanicsGridView.Columns.AddRange(new DataGridViewColumn[] { fullNameColumn, qualificationColumn, specializationColumn, experienceColumn });
        fullNameColumn.HeaderText = "ФИО";
        fullNameColumn.Name = "fullNameColumn";
        qualificationColumn.HeaderText = "Квалификация";
        qualificationColumn.Name = "qualificationColumn";
        specializationColumn.HeaderText = "Специализация";
        specializationColumn.Name = "specializationColumn";
        experienceColumn.HeaderText = "Стаж (лет)";
        experienceColumn.Name = "experienceColumn";
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
        Name = "MechanicListForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Механики";
        Controls.Add(mechanicsGridView);
        Controls.Add(buttonsPanel);
        ((System.ComponentModel.ISupportInitialize)mechanicsGridView).EndInit();
        buttonsPanel.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }
}
