using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.Service;

namespace StaffManagement.Controllers
{
    public class StaffController : Controller
    {
        /*
        static List<Staff> staffs = new List<Staff>()
        {
            new Staff(){Id=1, FirstName="John", LastName="Emma", Gender="Male", Age=23},
            new Staff(){Id=2, FirstName="Femi", LastName="AbdKabir", Gender="Female",Age=33},
            new Staff(){Id=3, FirstName="Kaan", LastName="Hassan", Gender="Male",Age=12}
        };

        */

        private IStaffService staffService;

        public StaffController(IStaffService staffService) 
        {
            this.staffService = staffService;
        }

        [HttpGet]
        [ActionName("Home")]
        public IActionResult Index(string name)
        {
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetInt32("age", 30);


            ViewBag.HeaderName = "Elev8 Index";
            return View();

        }
        
        public IActionResult List()
        {

            string name = HttpContext.Session.GetString("name");

            ViewData["Name"] = name;
            List<Staff> staffs = staffService.ReadAll();
            return View(staffs);
        }
        [HttpPost]
        public IActionResult Create([FromForm] Staff staff)
        {

            if (ModelState.IsValid)
            {
                TempData["HeaderName"] = "Elev8 Create Redirect";

                staffService.Create(staff);
                return RedirectToAction("List");
            }
            return View(staff);
        }
        [HttpGet]
        public IActionResult Create()
        {
            //TempData["HeaderName"] = "Elev8 Create";
            return View(new Staff());
        }

        public IActionResult Detail([FromRoute] int id)
        {

            Staff staff = staffService.ReadById(id);
            return View(staff);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Staff staff = staffService.ReadById(id);
            return View(staff);
        }
        [HttpPut]
        public IActionResult Edit(int id, Staff staff)
        {
            //please complete this
            staffService.Update(id, staff);
            return View();
        }

        [NonAction]
        public IActionResult Error()
        {
            return View();
        }
    }
}
