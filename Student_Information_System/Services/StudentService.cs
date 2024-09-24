using Microsoft.IdentityModel.Tokens;
using Student_Information_System.Data.Database.Entities;
using Student_Information_System.Data.Repositories.Interfaces;
using Student_Information_System.Services.Interfaces;

namespace Student_Information_System.Services
{
    public class StudentService: IStudentService
    {
        private IStudentRepository studentRepository;
        private IValidationService validationService;

        //public StudentService(IStudentRepository studentRepository, IValidationService validationService)
        //{
        //    this.studentRepository = studentRepository;
        //    this.validationService = validationService;
        //}

        public string CreateStudent(Student student)
        {
            string error = string.Empty;
            if (!error.IsNullOrEmpty())
            {
                return error;
            }
            studentRepository.Create(student);
            return error;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return studentRepository.GetAllStudents();
        }

        public Student? GetStudentByNumber(int studentId)
        {
            return studentRepository.GetById(studentId);
        }

        public string AddStudentToDepartment(string departmentCode, Student student)
        {
            var error = string.Empty;
            error = validationService.ValidateAddStudentDepartment(departmentCode, student.StudentId);
            if (!error.IsNullOrEmpty())
            {
                return error;
            }
            student.DepartmentCode = departmentCode;
            studentRepository.Update(student);
            return string.Empty;
        }

        public Student? GetStudentByEmail(string email)
        {
            return studentRepository.GetStudentByEmail(email);
        }

    }
}
