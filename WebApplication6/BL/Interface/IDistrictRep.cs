using System.Linq;
using WebApplication6.Models;

namespace WebApplication6.BL.Interface
{
    public interface IDistrictRep
    {

        IQueryable<DistrictVM> Get();
        DistrictVM GetById(int id);
    }
}
