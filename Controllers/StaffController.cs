using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;

namespace StaffManagement.Controllers
{
    public class StaffController : Controller
    {
        static List<Staff> staffs = new List<Staff>()
        {
            new Staff(){Id=1, FirstName="John", LastName="Emma", Gender="Male", Age=23},
            new Staff(){Id=2, FirstName="Femi", LastName="AbdKabir", Gender="Female",Age=33},
            new Staff(){Id=3, FirstName="Kaan", LastName="Hassan", Gender="Male",Age=12}
        };

        static int index = 2;

        [HttpGet]
        [ActionName("Home")]
        public IActionResult Index()
        {
            ViewBag.HeaderName = "Elev8 Index";
            return View();

            //return RedirectToAction("Index", "Home");

        }
        
        public IActionResult List()
        {
            //ViewData["HeaderName"] = "Elev8 List";
            return View(staffs);
        }
        [HttpPost]
        public IActionResult Create(int id, string firstName, string lastName, string gender, int age)
        {
            TempData["HeaderName"] = "Elev8 Create Redirect";
            Staff staff = new Staff()
            {
                Id = id, FirstName = firstName, LastName = lastName, Gender = gender, Age=age
            };
            staffs.Add(staff);
            //return View();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Create()
        {
            //TempData["HeaderName"] = "Elev8 Create";
            return View();
        }

        public IActionResult Detail(int id)
        {

            var stu = from st in staffs
                      where st.Id == id
                      select st;

            Staff staff = stu.ToList()[0];

            return View(staff);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var stu = from st in staffs
                      where st.Id == id
                      select st;

            Staff staff = stu.ToList()[0];

            return View(staff);
        }
        [HttpPost]
        public IActionResult Edit(int id, string firstName, string lastName, string gender, int age)
        {
            //please complete this

            return View();
        }

        [NonAction]
        public IActionResult Error()
        {
            return View();
        }
    }
}
