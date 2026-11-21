using Auto_Repair_Managment.Data;
using Auto_Repair_Managment.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class ClientRepository : IClientRepository
{
    private readonly DataContext context;
    private readonly ILogger<ClientRepository> logger;

    public ClientRepository(DataContext context, ILogger<ClientRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(logger);
        this.context = context;
        this.logger = logger;
    }

    public IReadOnlyList<Client> GetAll()
    {
        List<Client> clients = context.Clients
            .AsNoTracking()
            .OrderBy(client => client.FullName)
            .ToList();
        logger.LogInformation("Получен список клиентов: {Count} шт.", clients.Count);
        return clients;
    }

    public Client? GetById(int id)
    {
        Client? client = context.Clients.AsNoTracking().FirstOrDefault(item => item.Id == id);
        logger.LogInformation("Поиск клиента Id={Id}: {Result}", id, client == null ? "не найден" : "найден");
        return client;
    }
}
