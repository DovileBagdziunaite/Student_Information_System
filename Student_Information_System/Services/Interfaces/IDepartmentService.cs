using Student_Information_System.Data.Database.Entities;

namespace Student_Information_System.Services.Interfaces
{
    public interface IDepartmentService
    {
        string CreateDepartment(Department department);
        string AddLectureToDepartment(Department department, Lecture lecture);
        IEnumerable<Department> GetAllDepartments();
        void TransferStudentToDepartment(Department department, Student student);
        Department? GetDepartmentByCode(string departmentCode);
    }
}
