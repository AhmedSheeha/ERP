using ERP.Data;
using ERP.Models;
using ERP.Repositories.Base;

namespace ERP.Repositories
{
    public class EmpRepo : Repository<Employee>, IEmpRepo
    {
        private readonly AppDbContext _context;
        public EmpRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public decimal GetSalary(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void SetPayRoll(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
