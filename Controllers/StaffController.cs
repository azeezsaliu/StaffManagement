using Microsoft.AspNetCore.Mvc;

namespace StaffManagement.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HeaderName = "Elev8 Index";
            return View();
        }

        public IActionResult List()
        {
            ViewData["HeaderName"] = "Elev8 List";
            return View();
        }

        public IActionResult Create()
        {
            TempData["HeaderName"] = "Elev8 Create";
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
