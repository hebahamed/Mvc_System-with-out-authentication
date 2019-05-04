using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeForm.Models.Entities
{
    public class EmployeeViewModel
    {
        public Employee employee { get; set; }
        public List<Department> departments { get; set; }
    }
}