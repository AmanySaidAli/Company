using System.Linq;
using WebApplication6.Models;

namespace WebApplication6.BL.Interface
{
    public interface IEmployeeRep
    {
        IQueryable<EmployeeVM> Get();
        void Add(EmployeeVM emp);
        EmployeeVM GetById(int id);
        void Edit(EmployeeVM emp);
        void Delete(int id);

    }
}
