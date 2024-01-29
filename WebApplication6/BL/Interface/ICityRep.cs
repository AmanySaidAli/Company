using System.Linq;
using WebApplication6.Models;

namespace WebApplication6.BL.Interface
{
    public interface ICityRep
    {

        IQueryable<CityVM> Get();
        CityVM GetById(int id);
    }
}
