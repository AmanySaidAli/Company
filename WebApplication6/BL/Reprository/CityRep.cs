
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Linq;
using WebApplication6.BL.Interface;
using WebApplication6.DAL.Database;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.BL.Reprository
{
    public class CityRep : ICityRep
    {
        private readonly DbContainer db;

        // private DbContainer db = new DbContainer();
        public CityRep(DbContainer db)
        {
            this.db = db;
        }


        // reffactor
        public IQueryable<CityVM> Get()
        {
            IQueryable<CityVM> data = GetAllCities();
            return data;

        }

        private IQueryable<CityVM> GetAllCities()
        {
            return db.City.Select(a => new CityVM { Id = a.Id, CityName = a.CityName , CountryId = a.CountryId});
        }

        public CityVM GetById(int id)
        {
            CityVM data = GetCityByID(id);

            return data;
        }

        private CityVM GetCityByID(int id)
        {
            return db.City.Where(a => a.Id == id)
                                    .Select(a => new CityVM { Id = a.Id, CityName = a.CityName  , CountryId = a.CountryId})
                                    .FirstOrDefault();
        }
    }
}
