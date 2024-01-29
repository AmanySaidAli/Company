
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Linq;
using WebApplication6.BL.Interface;
using WebApplication6.DAL.Database;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.BL.Reprository
{
    public class CountryRep : ICountryRep
    {
        private readonly DbContainer db;

        // private DbContainer db = new DbContainer();
        public CountryRep(DbContainer db)
        {
            this.db = db;
        }

       
        // reffactor
        public IQueryable<CountryVM> Get()
        {
            IQueryable<CountryVM> data = GetAllCountries();
            return data;

        }

        private IQueryable<CountryVM> GetAllCountries()
        {
            return db.Country.Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName });
        }

        public CountryVM GetById(int id)
        {
            CountryVM data = GetCountryByID(id);

            return data;
        }

        private CountryVM GetCountryByID(int id)
        {
            return db.Country.Where(a => a.Id == id)
                                    .Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName })
                                    .FirstOrDefault();
        }
    }
}
