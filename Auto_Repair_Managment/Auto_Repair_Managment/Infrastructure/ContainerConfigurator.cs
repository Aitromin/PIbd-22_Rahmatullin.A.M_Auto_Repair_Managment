using Autofac;
using Auto_Repair_Managment.Forms;
using Auto_Repair_Managment.Repositories;
using Auto_Repair_Managment.Repositories.Realizations;

namespace Auto_Repair_Managment.Infrastructure;

public static class ContainerConfigurator
{
    public static IContainer BuildContainer()
    {
        ContainerBuilder builder = new();
        RegisterRepositories(builder);
        RegisterForms(builder);
        return builder.Build();
    }

    private static void RegisterRepositories(ContainerBuilder builder)
    {
        builder.RegisterType<ClientRepositoryStub>().As<IClientRepository>().SingleInstance();
        builder.RegisterType<CarRepositoryStub>().As<ICarRepository>().SingleInstance();
        builder.RegisterType<MechanicRepositoryStub>().As<IMechanicRepository>().SingleInstance();
        builder.RegisterType<WorkTypeRepositoryStub>().As<IWorkTypeRepository>().SingleInstance();
        builder.RegisterType<SparePartRepositoryStub>().As<ISparePartRepository>().SingleInstance();
        builder.RegisterType<AppointmentRepositoryStub>().As<IAppointmentRepository>().SingleInstance();
        builder.RegisterType<RepairOrderRepositoryStub>().As<IRepairOrderRepository>().SingleInstance();
        builder.RegisterType<SparePartUsageRepositoryStub>().As<ISparePartUsageRepository>().SingleInstance();
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
