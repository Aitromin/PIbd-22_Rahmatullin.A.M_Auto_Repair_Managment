using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories;

public interface ICarRepository
{
    IReadOnlyList<Car> GetAll();

    Car? GetById(int id);
}
