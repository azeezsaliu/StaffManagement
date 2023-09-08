using StaffManagement.Models;

namespace StaffManagement.Service
{
    public interface IStaffService
    {
        void Create(Staff staff);

        void Update(int id, Staff staff);

        Staff ReadById(int id);

        void Delete(Staff staff);

        List<Staff> ReadAll();

    }
}
