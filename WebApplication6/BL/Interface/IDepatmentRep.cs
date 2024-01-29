
using System.Linq;
using WebApplication6.Models;

namespace WebApplication6.BL.Interface
{
    public interface IDepatmentRep
    {
        IQueryable<DepartmentVM> Get();
        void Add(DepartmentVM emp );
        DepartmentVM GetById(int id);
        void Edit(DepartmentVM emp);
        void Delete(int id );



    }
}
