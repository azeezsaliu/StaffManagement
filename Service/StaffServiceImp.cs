using StaffManagement.Models;

namespace StaffManagement.Service
{
    public class StaffServiceImp : IStaffService
    {
        /*
        static List<Staff> staffs = new List<Staff>()
        {
            new Staff(){Id=1, FirstName="John", LastName="Emma", Gender="Male", Age=23},
            new Staff(){Id=2, FirstName="Femi", LastName="AbdKabir", Gender="Female",Age=33},
            new Staff(){Id=3, FirstName="Kaan", LastName="Hassan", Gender="Male",Age=12}
        };
        */
        private StaffDbContext _dbContext;
        public StaffServiceImp(StaffDbContext staffDbContext) 
        {
            _dbContext = staffDbContext;
        }
        public void Create(Staff staff)
        {
            //staffs.Add(staff);
            _dbContext.StaffTb.Add(staff);
            _dbContext.SaveChanges();
        }

        public void Delete(Staff staff)
        {
            //staffs.Remove(staff);
            _dbContext.StaffTb.Remove(staff);
            _dbContext.SaveChanges();
        }

        public List<Staff> ReadAll()
        {
            //return staffs;
            return _dbContext.StaffTb.ToList();
        }

        public Staff ReadById(int id)
        {
            /*
            foreach (Staff staff in staffs)
            {
                if (staff.Id == id)
                {
                    return staff;
                }
            }
            return null;
            */
            return _dbContext.StaffTb.Find(id);
        }

        public void Update(int id, Staff staff)
        {

            Staff staffObj = _dbContext.StaffTb.Find(id);
            staffObj.FirstName = staff.FirstName;
            staffObj.LastName = staff.LastName;
            staffObj.Gender = staff.Gender;
            staffObj.Age = staff.Age;

            _dbContext.Update(staffObj);
            _dbContext.SaveChanges();

            /*
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
            */
        }
    }
}
