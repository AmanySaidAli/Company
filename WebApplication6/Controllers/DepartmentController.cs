using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication6.BL.Reprository;
using WebApplication6.DAL.Database;
using WebApplication6.Models;
using System.Diagnostics;
using WebApplication6.DAL.Entities;
using WebApplication6.BL.Interface;

namespace WebApplication6.Controllers
{
    public class DepartmentController : Controller
    {
        // loosly coupl
        private readonly IDepatmentRep department;



        // tightly coupl

        //private readonly DepartmentRep department;

        public DepartmentController(IDepatmentRep Department)
        {
            department = Department;
        }

        public IActionResult Index()
        {
            //DepartmentVM dept1 = new DepartmentVM() { Id = 1, DepartmentName = " HR", DepartmentCode = "A100" };
            //DepartmentVM dept2 = new DepartmentVM() { Id = 2, DepartmentName = " IT", DepartmentCode = "A200" };
            //DepartmentVM dept3 = new DepartmentVM() { Id = 3, DepartmentName = " Seals", DepartmentCode = "A300" };
            //List <DepartmentVM> DeptData = new List<DepartmentVM> { dept1, dept2, dept3 };

            //var data = DeptData;
            var data = department.Get(); 
            return View(data);
            //return RedirectToAction("Index","Home");
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM dpt )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Add(dpt);
                    return RedirectToAction("Index", "Department");

                }
                return View(dpt);

            }
            catch (Exception ex )
            {
                EventLog log = new EventLog();
                log.Source ="Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(dpt);

            }
        }
        public IActionResult Edit( int id)
        {
            var data = department.GetById(id);
            return View(data);
        }
        public IActionResult Delete(int id)
        {
            var data = department.GetById(id);
       
            return View(data);
        }
        [HttpPost] 
        public IActionResult Edit(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Edit(dpt);
                    return RedirectToAction("Index", "Department");

                }
                return View(dpt);

            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(dpt);

            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {

                department.Delete(id);
                    return RedirectToAction("Index", "Department");

                

            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();

            }
        }
    }
}
