using Microsoft.IdentityModel.Tokens;
using Student_Information_System.Data.Database.Entities;
using Student_Information_System.Data.Repositories;
using Student_Information_System.Data.Repositories.Interfaces;
using Student_Information_System.Services.Interfaces;

namespace Student_Information_System.Services
{
    public class DepartmentService: IDepartmentService
    {
        private IDepartmentRepository departmentRepository;
        private IValidationService validationService;

        public string CreateDepartment(Department department)
        {
            string error = string.Empty;
            error = validationService.ValidateDepartment(department);
            if (!error.IsNullOrEmpty())
            {
                return error;
            }
            departmentRepository.Create(department);
            return error;

        }
        
        public IEnumerable<Department> GetAllDepartments()
        {
            return departmentRepository.GetAllDepartments();
        }

        public Department? GetDepartmentByCode(string departmentCode)
        {
            return departmentRepository.GetDepartmentByCode(departmentCode);
        }

        public string AddLectureToDepartment(Department department, Lecture lecture)
        {
            string error = string.Empty;
            error = validationService.ValidateAddLectureToDepartment(department.DepartmentCode, lecture.LectureId);
            if (!error.IsNullOrEmpty())
            {
                return error;
            }
            departmentRepository.AddLectureToDepartment(department, lecture);
            return error;
        }

        public void TransferStudentToDepartment(Department department, Student student)
        {
            departmentRepository.TransferStudentToDepartment(student, department);
        }
    }
}
