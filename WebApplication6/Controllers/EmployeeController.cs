using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using WebApplication6.BL.Interface;
using WebApplication6.Models;
using WebApplication6.BL.Reprository;
using WebApplication6.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;
using WebApplication6.Resource;

namespace WebApplication6.Controllers
{
    public class EmployeeController : Controller
    {
       
           // loosly coupl
            private readonly IEmployeeRep employee;
        private readonly IDepatmentRep depatment;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;
       // private readonly IStringLocalizer<SharedResource> SharedLocalizer;




        // tightly coupl

        //private readonly DepartmentRep department;

        public EmployeeController(IEmployeeRep Employee , IDepatmentRep Depatment , ICountryRep Country, ICityRep City, IDistrictRep District)
            {
                this.employee = Employee;
                this.depatment= Depatment;  
                this.country=Country;
                this.city=City;
                this.district = District;
               //sharedLocalizer = SharedLocalizer;
            }

            public IActionResult Index()
            {
                //DepartmentVM dept1 = new DepartmentVM() { Id = 1, DepartmentName = " HR", DepartmentCode = "A100" };
                //DepartmentVM dept2 = new DepartmentVM() { Id = 2, DepartmentName = " IT", DepartmentCode = "A200" };
                //DepartmentVM dept3 = new DepartmentVM() { Id = 3, DepartmentName = " Seals", DepartmentCode = "A300" };
                //List <DepartmentVM> DeptData = new List<DepartmentVM> { dept1, dept2, dept3 };

                //var data = DeptData;
                var data = employee.Get();
                return View(data);
                //return RedirectToAction("Index","Home");
            }
            public IActionResult Create()
            {

                var data = depatment.Get();
                var countrydata = country.Get();

            ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
            ViewBag.CountryList = new SelectList(countrydata, "Id", "CountryName");

            return View();
            }
            [HttpPost]
            public IActionResult Create(EmployeeVM emp)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                         employee.Add(emp);
                        return RedirectToAction("Index", "Employee");

                    }
                var data = depatment.Get();

                ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");

                return View(emp);

                }
                catch (Exception ex)
                {
                    EventLog log = new EventLog();
                    log.Source = "Admin Dashboard";
                    log.WriteEntry(ex.Message, EventLogEntryType.Error);

                    return View(emp);

                }
            }
            public IActionResult Edit(int id)
            {

                var data = employee.GetById(id);
            var Deptdata = depatment.Get();

            ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName" , data.DepartmentId);

            return View(data);
            }
            public IActionResult Delete(int id)
            {
                var data = employee.GetById(id);

            var Deptdata = depatment.Get();

            ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName", data.DepartmentId);

            return View(data);
            }
            [HttpPost]
            public IActionResult Edit(EmployeeVM emp)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                       employee.Edit(emp);
                        return RedirectToAction("Index", "Employee");

                    }
                var Deptdata = depatment.Get();

                ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName", emp.DepartmentId);

                return View(emp);

                }
                catch (Exception ex)
                {
                    EventLog log = new EventLog();
                    log.Source = "Admin Dashboard";
                    log.WriteEntry(ex.Message, EventLogEntryType.Error);

                    return View(emp);

                }
            }
            [HttpPost]
            [ActionName("Delete")]
            public IActionResult ConfirmDelete(int id)
            {
                try
                {

                    employee.Delete(id);
                    return RedirectToAction("Index", "Employee");



                }
                catch (Exception ex)
                {
                    EventLog log = new EventLog();
                    log.Source = "Admin Dashboard";
                    log.WriteEntry(ex.Message, EventLogEntryType.Error);

                    return View();

                }
            }


        //    Ajax Calls 
        //[HttpPost]
        //public JsonResult GetCityDataByCountryId( int CntryID)
        //{
        //    var data = city.Get().Where( a => a.CountryId == CntryID) ;
        //        return Json(data);
        //}
        //[HttpPost]
        //public JsonResult GetDistrictDataByDistrictId(int CityID)
        //{
        //    var data = district.Get().Where(a => a.CityId == CityID);
        //    return Json(data);
        //}


        [HttpPost]
        public JsonResult GetCityDataByCountryId(int CntryID)
        {
            var data = city.Get().Where(a => a.CountryId == CntryID);
            return Json(data);
        }


        [HttpPost]
        public JsonResult GetDistrictDataByCityId(int cityId)
        {
            var data = district.Get().Where(a => a.CityId == cityId);
            return Json(data);
        }

    }
    }
    

