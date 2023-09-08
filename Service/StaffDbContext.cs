using Microsoft.EntityFrameworkCore;
using StaffManagement.Models;

namespace StaffManagement.Service
{
    public class StaffDbContext : DbContext
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Staff> StaffTb { get; set; }
        
    }
}
