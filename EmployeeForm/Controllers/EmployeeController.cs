using EmployeeForm.Models;
using EmployeeForm.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeForm.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        static Model ctx = new Model();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.departments = ctx.Departments.ToList();
            ViewBag.Action = "Add";
            return View(evm);
        }
        public ActionResult List()
        {
            var employees = ctx.Employees.Include("Department").ToList();
            return View(employees);
        }
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                
                var employees = ctx.Employees;
                employees.Add(employee);
                ctx.SaveChanges();
                return RedirectToAction("List");

            }
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.departments = ctx.Departments.ToList();
            evm.employee = employee;
            return View(evm);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
           
            Employee employee = ctx.Employees.FirstOrDefault(e => e.Id == id);
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.departments = ctx.Departments.ToList();
            evm.employee = employee;
            ViewBag.Action = "Edit";
            if (employee != null)
            {
                return View("Add", evm);
            }
           
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel em)
        {
           
            Employee oldEmployee = ctx.Employees.FirstOrDefault(e => e.Id == em.employee.Id);
            if (ModelState.IsValid)
            {

            oldEmployee.Name = em.employee.Name;
            oldEmployee.Age = em.employee.Age;
            oldEmployee.Gender = em.employee.Gender;
            oldEmployee.Email = em.employee.Email;
            oldEmployee.Department.Id = em.employee.Fk_DepartmentId;
            ctx.SaveChanges();
              return RedirectToAction("List");
            }
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.departments = ctx.Departments.ToList();
            evm.employee = em.employee;
            return View(evm);

        }

        public ActionResult Details(Employee emp)
        {
            Employee employee = ctx.Employees.FirstOrDefault(e => e.Id == emp.Id);
            if (employee != null)
            {
                return View("Details", employee);
            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            Employee employee = ctx.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                ctx.Employees.Remove(employee);
                ctx.SaveChanges();
                return RedirectToAction("List");
            }
            return View("List");
        }


    }
}