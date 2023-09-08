using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.Service;

namespace StaffManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffApiController : ControllerBase
    {
        private IStaffService staffService;
        public StaffApiController(IStaffService staffService)
        {
            this.staffService = staffService;
        }
        //?name="John"&age=34
        [HttpGet]
        public string Index([FromQuery] string name, [FromQuery]int age)
        {
            return "Hello Api: " + name;
        }
        [HttpGet("ListStaff")]
        public List<Staff> List()
        {
            return staffService.ReadAll();
        }

        [HttpPost]
        public string Create(Staff staff)
        {
            staffService.Create(staff);
            return ("success");
        }
        [HttpGet("{id}")]
        public Staff GetStaff(int id)
        {
            return staffService.ReadById(id);
        }
        [HttpPut("{id}")]
        public string EditStaff(int id, Staff staff)
        {
            staffService.Update(id, staff);
            return ("success");
        }
    }
}
