namespace EmployeeForm.Models
{
    using EmployeeForm.Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model : DbContext
    {
       
        public Model()
            : base("name=Model")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


    }


}