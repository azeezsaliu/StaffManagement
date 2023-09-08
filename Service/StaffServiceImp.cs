using StaffManagement.Models;

namespace StaffManagement.Service
{
    public class StaffServiceImp : IStaffService
    {
        static List<Staff> staffs = new List<Staff>()
        {
            new Staff(){Id=1, FirstName="John", LastName="Emma", Gender="Male", Age=23},
            new Staff(){Id=2, FirstName="Femi", LastName="AbdKabir", Gender="Female",Age=33},
            new Staff(){Id=3, FirstName="Kaan", LastName="Hassan", Gender="Male",Age=12}
        };
        public void Create(Staff staff)
        {
            staffs.Add(staff);
        }

        public void Delete(Staff staff)
        {
            staffs.Remove(staff);
        }

        public List<Staff> ReadAll()
        {
            return staffs;
        }

        public Staff ReadById(int id)
        {
            foreach (Staff staff in staffs)
            {
                if (staff.Id == id)
                {
                    return staff;
                }
            }
            return null;
        }

        public void Update(int id, Staff staff)
        {
            var stu = from s in staffs
                      where s.Id == id
                      select s;

            Staff st = stu.ToList()[0];

            int index = staffs.IndexOf(st);

            staffs.Remove(st);

            st.FirstName = staff.FirstName;
            st.LastName = staff.LastName;
            st.Gender = staff.Gender;
            st.Age = staff.Age;

            staffs.Insert(index, st);
        }
    }
}
