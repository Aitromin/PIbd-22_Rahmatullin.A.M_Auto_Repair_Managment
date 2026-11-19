using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class CarRepositoryStub : ICarRepository
{
    private readonly InMemoryStorage<Car> storage = new();

    public CarRepositoryStub(IClientRepository clientRepository)
    {
        ArgumentNullException.ThrowIfNull(clientRepository);
        IReadOnlyList<Client> clients = clientRepository.GetAll();
        (int ClientIndex, string Brand, string Model)[] demoCars =
        {
            (0, "Toyota", "Camry"),
            (0, "Kia", "Rio"),
            (1, "Lada", "Vesta"),
            (2, "Volkswagen", "Polo")
        };

        foreach ((int clientIndex, string brand, string model) in demoCars)
        {
            if (clientIndex < clients.Count)
            {
                storage.Add(Car.Create(clients[clientIndex].Id, brand, model));
            }
        }
    }

    public IReadOnlyList<Car> GetAll()
    {
        return storage.GetAll();
    }

    public Car? GetById(int id)
    {
        return storage.GetById(id);
    }
}
