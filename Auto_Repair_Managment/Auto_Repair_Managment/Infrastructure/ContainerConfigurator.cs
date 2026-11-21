using Autofac;
using Auto_Repair_Managment.Data;
using Auto_Repair_Managment.Forms;
using Auto_Repair_Managment.Repositories;
using Auto_Repair_Managment.Repositories.Realizations;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace Auto_Repair_Managment.Infrastructure;

public static class ContainerConfigurator
{
    public static IContainer BuildContainer()
    {
        ContainerBuilder builder = new();
        RegisterLogging(builder);
        RegisterDataContext(builder);
        RegisterRepositories(builder);
        RegisterForms(builder);
        return builder.Build();
    }

    private static void RegisterLogging(ContainerBuilder builder)
    {
        builder.RegisterInstance<ILoggerFactory>(new SerilogLoggerFactory(Log.Logger)).SingleInstance();
        builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>)).SingleInstance();
    }

    private static void RegisterDataContext(ContainerBuilder builder)
    {
        builder.RegisterType<DataContext>().AsSelf().InstancePerDependency();
    }

    private static void RegisterRepositories(ContainerBuilder builder)
    {
        builder.RegisterType<ClientRepository>().As<IClientRepository>().InstancePerDependency();
        builder.RegisterType<CarRepository>().As<ICarRepository>().InstancePerDependency();
        builder.RegisterType<MechanicRepository>().As<IMechanicRepository>().InstancePerDependency();
        builder.RegisterType<WorkTypeRepository>().As<IWorkTypeRepository>().InstancePerDependency();
        builder.RegisterType<SparePartRepository>().As<ISparePartRepository>().InstancePerDependency();
        builder.RegisterType<AppointmentRepository>().As<IAppointmentRepository>().InstancePerDependency();
        builder.RegisterType<RepairOrderRepository>().As<IRepairOrderRepository>().InstancePerDependency();
        builder.RegisterType<SparePartUsageRepository>().As<ISparePartUsageRepository>().InstancePerDependency();
    }

    private static void RegisterForms(ContainerBuilder builder)
    {
        builder.RegisterType<MainForm>().AsSelf().ExternallyOwned();
        builder.RegisterType<MechanicListForm>().AsSelf().ExternallyOwned();
        builder.RegisterType<MechanicEditForm>().AsSelf().ExternallyOwned();
        builder.RegisterType<WorkTypeListForm>().AsSelf().ExternallyOwned();
        builder.RegisterType<WorkTypeEditForm>().AsSelf().ExternallyOwned();
        builder.RegisterType<SparePartListForm>().AsSelf().ExternallyOwned();
        builder.RegisterType<SparePartEditForm>().AsSelf().ExternallyOwned();
        builder.RegisterType<AppointmentListForm>().AsSelf().ExternallyOwned();
        builder.RegisterType<AppointmentAddForm>().AsSelf().ExternallyOwned();
        builder.RegisterType<RepairOrderListForm>().AsSelf().ExternallyOwned();
        builder.RegisterType<RepairOrderAddForm>().AsSelf().ExternallyOwned();
    }
}
