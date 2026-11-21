using Auto_Repair_Managment.Entity;

namespace Auto_Repair_Managment.Repositories;

public interface IWorkTypeRepository
{
    IReadOnlyList<WorkType> GetAll();

    WorkType? GetById(int id);

    void Add(WorkType workType);

    void Update(WorkType workType);

    void Delete(int id);
}
