using Autofac;
using Auto_Repair_Managment.Forms;
using Auto_Repair_Managment.Infrastructure;

namespace Auto_Repair_Managment;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        using IContainer container = ContainerConfigurator.BuildContainer();
        Application.Run(container.Resolve<MainForm>());
    }
}
