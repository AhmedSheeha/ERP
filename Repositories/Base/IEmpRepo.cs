using ERP.Models;

namespace ERP.Repositories.Base
{
    public interface IEmpRepo : IRepository<Employee>
    {
        void SetPayRoll(Employee employee);
        decimal GetSalary(Employee employee);
    }
}
