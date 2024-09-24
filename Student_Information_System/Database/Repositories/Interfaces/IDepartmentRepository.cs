using Student_Information_System.Data.Database.Entities;

namespace Student_Information_System.Data.Repositories.Interfaces
{
    internal interface IDepartmentRepository
    {
        void Create(Department department);
        void Update(Department department);
        Department GetById(int id);
        IEnumerable<Department> GetAllDepartments();
        void AddLectureToDepartment(Department department, Lecture lecture);
        void Delete(string departmentCode);
        Department? GetDepartmentByCode(string departmentCode);
        void TransferStudentToDepartment(Student student, Department department);
    }
}
