using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories;

public interface IClientRepository
{
    IReadOnlyList<Client> GetAll();

    Client? GetById(int id);
}
