using Student_Information_System.Data.Database.Entities;

namespace Student_Information_System.Data.Repositories.Interfaces
{
    internal interface IStudentRepository
    {
        void Create(Student student);
        void Update(Student student);
        Student GetById(int id);
        IEnumerable<Student> GetAllStudents();
        Student? GetStudentByEmail(string email);
        void Delete(int id);
        void DeleteStudentsLectures(Student student);
    }
}
