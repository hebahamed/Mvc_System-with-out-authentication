﻿using EmployeeForm.Models;
using EmployeeForm.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeForm.Controllers
{
    public class DepartmentController : Controller
    {
        static Model ctx = new Model();
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var departments = ctx.Departments.ToList();
            return View(departments);

        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
           
        }

        [HttpPost]

        public ActionResult Add(Department dept)
        {
            var departments = ctx.Departments;
            if (ModelState.IsValid)
            {
                departments.Add(dept);
                ctx.SaveChanges();
                return RedirectToAction("List");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Department dept = ctx.Departments.FirstOrDefault(d => d.Id == id);
            if (dept != null)
            {
                return View("Add", dept);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            Department oldDepartment = ctx.Departments.FirstOrDefault(d => d.Id == department.Id);
            if (ModelState.IsValid)
            {
                oldDepartment.Name = department.Name;
                return RedirectToAction("List");

            }
            return View();

        }

        public ActionResult Delete(int id)
        {
            Department dept = ctx.Departments.FirstOrDefault(d => d.Id == id);
            if (dept.Employees == null)
            {
                ctx.Departments.Remove(dept);
                ctx.SaveChanges();
                return RedirectToAction("List");
            }
            return View("List");

        }
    }
}