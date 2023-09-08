using System.ComponentModel.DataAnnotations;

namespace StaffManagement.Models
{
    public class Staff
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is compulsory")]
        //[Compare("LastName")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(5)]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
