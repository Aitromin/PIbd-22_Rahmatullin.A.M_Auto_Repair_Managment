using Autofac;
using Auto_Repair_Managment.Forms;
using Auto_Repair_Managment.Infrastructure;
using Serilog;

namespace Auto_Repair_Managment;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        LoggingConfigurator.ConfigureLogger();
        Application.ThreadException += HandleUnhandledException;
        Log.Information("Приложение запущено");

        try
        {
            using IContainer container = ContainerConfigurator.BuildContainer();
            Application.Run(container.Resolve<MainForm>());
        }
        finally
        {
            Log.Information("Приложение закрыто");
            Log.CloseAndFlush();
        }
    }

    private static void HandleUnhandledException(object sender, ThreadExceptionEventArgs e)
    {
        Log.Error(e.Exception, "Необработанная ошибка в интерфейсе");
        MessageBox.Show(
            $"Произошла ошибка: {e.Exception.Message}",
            "Ошибка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
