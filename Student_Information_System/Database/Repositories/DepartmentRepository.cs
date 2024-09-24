using Microsoft.EntityFrameworkCore;
using Student_Information_System.Data.Database.Entities;
using Student_Information_System.Data.Repositories.Interfaces;

namespace Student_Information_System.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StudentsContext _departmentsContext;

        public DepartmentRepository(StudentsContext context)
        {
            _departmentsContext = context;
        }

        public void Create(Department department)
        {
            _departmentsContext.Departments.Add(department);
            _departmentsContext.SaveChanges();
        }

        public void Update(Department department)
        {
            _departmentsContext.Departments.Update(department);
            _departmentsContext.SaveChanges();
        }

        public void Delete(string departmentCode)
        {
            var department = _departmentsContext.Departments.SingleOrDefault(d => d.DepartmentCode.Equals(departmentCode));
            if (department != null)
            {
                _departmentsContext.Departments.Remove(department);
                _departmentsContext.SaveChanges();
            }
        }

        public Department GetById(int id)
        {
            return _departmentsContext.Departments.Include(x => x.Students).FirstOrDefault(x => x.DepartmentId == id);
        }

        public Department? GetDepartmentByCode(string departmentCode)
        {
            return _departmentsContext.Departments.Include(d => d.Lectures).SingleOrDefault(d => d.DepartmentCode.Equals(departmentCode));
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentsContext.Departments.Include(d => d.Students).ThenInclude(d => d.Lectures).ToList();
        }

        public void AddLectureToDepartment(Department department, Lecture lecture)
        {
            department.Lectures.Add(lecture);
            _departmentsContext.SaveChanges();
        }

        public void TransferStudentToDepartment(Student student, Department department)
        {
            student.Lectures.Clear();
            student.DepartmentCode = department.DepartmentCode;
            _departmentsContext.SaveChanges();
        }
    }
}
