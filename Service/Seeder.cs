using StaffManagement.Models;

namespace StaffManagement.Service
{
    public static class Seeder
    {

        static List<Staff> staffs = new List<Staff>()
        {
            new Staff(){FirstName="John", LastName="Emma", Gender="Male", Age=23},
            new Staff(){FirstName="Femi", LastName="AbdKa", Gender="Female",Age=33},
            new Staff(){FirstName="Kaan", LastName="Hassa", Gender="Male",Age=12}
        };

        public static void SeedDatabase(StaffDbContext staffDbContext)
        {
            List<Staff> staffList = staffDbContext.StaffTb.ToList();
            if(staffList.Count == 0 ) 
            {
                staffDbContext.StaffTb.AddRange(staffs[0], staffs[1], staffs[2]);
                staffDbContext.SaveChanges();
            }
        }

    }
}
