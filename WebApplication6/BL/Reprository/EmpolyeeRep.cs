using AutoMapper;
using System.Linq;
using WebApplication6.BL.Interface;
using WebApplication6.DAL.Database;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.BL.Reprository
{
    public class EmpolyeeRep : IEmployeeRep
    {

        private readonly DbContainer db;
        private readonly IMapper mapper;

        // private DbContainer db = new DbContainer();
        public EmpolyeeRep(DbContainer db, IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }

        public void Add(EmployeeVM emp)
        {
            // Department d = new Department();
            //d.DepartmentName = dpt.DepartmentName;  
            //d.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Employee>(emp);
            db.Employee.Add(data);
            db.SaveChanges();


        }

        public void Delete(int id)
        {
            var DeletedObject = db.Employee.Find(id);
            db.Employee.Remove(DeletedObject);
            db.SaveChanges();


        }

        public void Edit(EmployeeVM emp)
        {
            //var OldData = db.Department.Find(dpt.Id);
            //OldData.DepartmentName = dpt.DepartmentName;
            //OldData.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Employee>(emp);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

        }

        // reffactor
        public IQueryable<EmployeeVM> Get()
        {
            IQueryable<EmployeeVM> data = GetAllEmps();
            return data;

        }

        private IQueryable<EmployeeVM> GetAllEmps()
        {
            return db.Employee.Select(a => new EmployeeVM { Id = a.Id, Name = a.Name , Email = a.Email , 
            Address = a.Address , HirData = a.HirData , IsActive = a.IsActive , Salary = a.Salary , Notes = a.Notes ,DepartmentId= a.Department.DepartmentName , DistrictId = a.District.DistrictName});
        }

        public EmployeeVM GetById(int id)
        {
            EmployeeVM data = GetEmployeeByID(id);

            return data;
        }

        private EmployeeVM GetEmployeeByID(int id)
        {
            return db.Employee.Where(a => a.Id == id)
                                    .Select(a => new EmployeeVM { Id = a.Id,
                                        Name = a.Name,
                                        Email = a.Email,
                                        Address = a.Address,
                                        HirData = a.HirData,
                                        IsActive = a.IsActive,
                                        Salary = a.Salary,
                                        Notes = a.Notes
                                        ,
                                        DepartmentId = a.Department.DepartmentName
                                        ,DistrictId = a.District.DistrictName
                                    })
                                    .FirstOrDefault();
        }
    }
}

