using Student_Information_System.Data.Database.Entities;

namespace Student_Information_System.Services.Interfaces
{
    public interface IStudentService
    {
        Student? GetStudentByNumber(int studentNumber);
        string CreateStudent(Student student);
        Student? GetStudentByEmail(string email);
        IEnumerable<Student> GetAllStudents();
        string AddStudentToDepartment(string departmentCode, Student student);
        
    }
}
