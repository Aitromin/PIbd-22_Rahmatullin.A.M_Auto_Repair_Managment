using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class ClientRepositoryStub : IClientRepository
{
    private readonly InMemoryStorage<Client> storage = new();

    public ClientRepositoryStub()
    {
        storage.Add(Client.Create("Иванов Иван Петрович", "+7 900 111-22-33"));
        storage.Add(Client.Create("Петрова Анна Сергеевна", "+7 900 222-33-44"));
        storage.Add(Client.Create("Сидоров Алексей Николаевич", "+7 900 333-44-55"));
    }

    public IReadOnlyList<Client> GetAll()
    {
        return storage.GetAll();
    }

    public Client? GetById(int id)
    {
        return storage.GetById(id);
    }
}
