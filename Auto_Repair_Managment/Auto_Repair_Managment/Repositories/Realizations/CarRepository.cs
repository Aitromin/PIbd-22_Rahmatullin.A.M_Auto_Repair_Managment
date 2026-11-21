using Auto_Repair_Managment.Data;
using Auto_Repair_Managment.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auto_Repair_Managment.Repositories.Realizations;

public sealed class CarRepository : ICarRepository
{
    private readonly DataContext context;
    private readonly ILogger<CarRepository> logger;

    public CarRepository(DataContext context, ILogger<CarRepository> logger)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(logger);
        this.context = context;
        this.logger = logger;
    }

    public IReadOnlyList<Car> GetAll()
    {
        List<Car> cars = context.Cars
            .AsNoTracking()
            .OrderBy(car => car.Brand)
            .ThenBy(car => car.Model)
            .ToList();
        logger.LogInformation("Получен список автомобилей: {Count} шт.", cars.Count);
        return cars;
    }

    public Car? GetById(int id)
    {
        Car? car = context.Cars.AsNoTracking().FirstOrDefault(item => item.Id == id);
        logger.LogInformation("Поиск автомобиля Id={Id}: {Result}", id, car == null ? "не найден" : "найден");
        return car;
    }
}
