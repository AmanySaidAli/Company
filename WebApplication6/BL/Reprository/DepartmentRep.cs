using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Linq;
using WebApplication6.BL.Interface;
using WebApplication6.DAL.Database;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;


namespace WebApplication6.BL.Reprository
{
    public class DepartmentRep : IDepatmentRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        // private DbContainer db = new DbContainer();
        public DepartmentRep(DbContainer db , IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }

        public void Add(DepartmentVM dpt)
        {
           // Department d = new Department();
            //d.DepartmentName = dpt.DepartmentName;  
            //d.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Department>(dpt);
            db.Department.Add(data);
            db.SaveChanges();   
            
                    
        }

        public void Delete(int id)
        {
            var DeletedObject = db.Department.Find(id);
            db.Department.Remove(DeletedObject);
            db.SaveChanges(); 


        }

        public void Edit(DepartmentVM dpt)
        {
            //var OldData = db.Department.Find(dpt.Id);
            //OldData.DepartmentName = dpt.DepartmentName;
            //OldData.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Department>(dpt);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;       
            db.SaveChanges();

        }

        // reffactor
        public IQueryable<DepartmentVM> Get()
        {
            IQueryable<DepartmentVM> data = GetAllDepts();
            return data;

        }

        private IQueryable<DepartmentVM> GetAllDepts()
        {
            return db.Department.Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
        }

        public DepartmentVM GetById(int id)
        {
            DepartmentVM data = GetDepartmentByID(id);

            return data;
        }

        private DepartmentVM GetDepartmentByID(int id)
        {
            return db.Department.Where(a => a.Id == id)
                                    .Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                                    .FirstOrDefault();
        }
    }
}
