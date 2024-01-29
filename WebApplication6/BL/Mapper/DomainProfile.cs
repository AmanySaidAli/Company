using AutoMapper;
using System.Threading;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;
using WebApplication6.DAL.Entities;

namespace WebApplication6.BL.Mapper
{
    public class DomainProfile :Profile 
    {
       public DomainProfile()
        {
            CreateMap< Department , DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();
        }
    }
}
