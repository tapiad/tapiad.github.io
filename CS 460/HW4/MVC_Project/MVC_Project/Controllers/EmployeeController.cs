using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/Details
        public ActionResult Details()
        {
            Employee employee = new Employee()
            {
                EmployeeId = 101,
                Name = "Daniel",
                Gender = "Male",
                City = "Hubbard"
            };
            return View (employee);
        }

    }
}
