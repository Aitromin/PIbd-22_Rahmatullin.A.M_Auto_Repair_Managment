namespace Auto_Repair_Managment.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private MenuStrip mainMenuStrip;
    private ToolStripMenuItem referencesMenuItem;
    private ToolStripMenuItem mechanicsMenuItem;
    private ToolStripMenuItem workTypesMenuItem;
    private ToolStripMenuItem sparePartsMenuItem;
    private ToolStripMenuItem operationsMenuItem;
    private ToolStripMenuItem appointmentsMenuItem;
    private ToolStripMenuItem repairOrdersMenuItem;
    private ToolStripMenuItem reportsMenuItem;

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
        mainMenuStrip = new MenuStrip();
        referencesMenuItem = new ToolStripMenuItem();
        mechanicsMenuItem = new ToolStripMenuItem();
        workTypesMenuItem = new ToolStripMenuItem();
        sparePartsMenuItem = new ToolStripMenuItem();
        operationsMenuItem = new ToolStripMenuItem();
        appointmentsMenuItem = new ToolStripMenuItem();
        repairOrdersMenuItem = new ToolStripMenuItem();
        reportsMenuItem = new ToolStripMenuItem();
        mainMenuStrip.SuspendLayout();
        SuspendLayout();
        mainMenuStrip.Items.AddRange(new ToolStripItem[] { referencesMenuItem, operationsMenuItem, reportsMenuItem });
        mainMenuStrip.Location = new Point(0, 0);
        mainMenuStrip.Name = "mainMenuStrip";
        mainMenuStrip.Size = new Size(800, 24);
        mainMenuStrip.TabIndex = 0;
        referencesMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mechanicsMenuItem, workTypesMenuItem, sparePartsMenuItem });
        referencesMenuItem.Name = "referencesMenuItem";
        referencesMenuItem.Text = "Справочники";
        mechanicsMenuItem.Name = "mechanicsMenuItem";
        mechanicsMenuItem.Text = "Механики";
        mechanicsMenuItem.Click += MechanicsMenuItem_Click;
        workTypesMenuItem.Name = "workTypesMenuItem";
        workTypesMenuItem.Text = "Виды работ";
        workTypesMenuItem.Click += WorkTypesMenuItem_Click;
        sparePartsMenuItem.Name = "sparePartsMenuItem";
        sparePartsMenuItem.Text = "Запчасти";
        sparePartsMenuItem.Click += SparePartsMenuItem_Click;
        operationsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { appointmentsMenuItem, repairOrdersMenuItem });
        operationsMenuItem.Name = "operationsMenuItem";
        operationsMenuItem.Text = "Операции";
        appointmentsMenuItem.Name = "appointmentsMenuItem";
        appointmentsMenuItem.Text = "Записи на обслуживание";
        appointmentsMenuItem.Click += AppointmentsMenuItem_Click;
        repairOrdersMenuItem.Name = "repairOrdersMenuItem";
        repairOrdersMenuItem.Text = "Заказ-наряды";
        repairOrdersMenuItem.Click += RepairOrdersMenuItem_Click;
        reportsMenuItem.Name = "reportsMenuItem";
        reportsMenuItem.Text = "Отчеты";
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(mainMenuStrip);
        MainMenuStrip = mainMenuStrip;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Учет работы автосервиса";
        mainMenuStrip.ResumeLayout(false);
        mainMenuStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
