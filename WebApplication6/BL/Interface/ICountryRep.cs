using System.Linq;
using WebApplication6.Models;

namespace WebApplication6.BL.Interface
{
    public interface ICountryRep
    {
        IQueryable<CountryVM> Get();
        CountryVM GetById(int id);
    }
}
