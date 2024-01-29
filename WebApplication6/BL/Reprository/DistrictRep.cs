
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Linq;
using WebApplication6.BL.Interface;
using WebApplication6.DAL.Database;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;


namespace WebApplication6.BL.Reprository
{
    public class DistrictRep : IDistrictRep
    {
        private readonly DbContainer db;

        // private DbContainer db = new DbContainer();
        public DistrictRep(DbContainer db)
        {
            this.db = db;
        }


        // reffactor
        public IQueryable<DistrictVM> Get()
        {
            IQueryable<DistrictVM> data = GetAllDistricties();
            return data;

        }

        private IQueryable<DistrictVM> GetAllDistricties()
        {
            return db.District.Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName , CityId= a.CityId});
        }

        public DistrictVM GetById(int id)
        {
            DistrictVM data = GetCityByID(id);

            return data;
        }

        private DistrictVM GetCityByID(int id)
        {
            return db.District.Where(a => a.Id == id)
                                    .Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName, CityId = a.CityId })
                                    .FirstOrDefault();
        }

    }
}
