using Microsoft.EntityFrameworkCore;
using Student_Information_System.Data.Database.Entities;
using Student_Information_System.Data.Repositories.Interfaces;

namespace Student_Information_System.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsContext _studentsContext;

        public StudentRepository(StudentsContext context)
        {
            _studentsContext = context;
        }

        public void Create(Student student)
        {
            _studentsContext.Students.Add(student);
            _studentsContext.SaveChanges();
        }

        public void Update(Student student)
        {
            //_studentsContext.Entry(student).CurrentValues.SetValues(student);   ???
            //_studentsContext.SaveChanges();                                     ???
            _studentsContext.Students.Update(student);
            _studentsContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _studentsContext.Students.Find(id);
            if (student != null)
            {
                _studentsContext.Students.Remove(student);
                _studentsContext.SaveChanges();
            }
        }

        //public void Delete(Student student)
        //{
        //    _studentContext.Students.Remove(student);
        //    _studentContext.SaveChanges();
        //}

        public Student GetById(int id)
        {
            //return _studentContext.Students.FirstOrDefault(x => x.StudentId == id);
            return _studentsContext.Students.Include(x => x.Lectures).FirstOrDefault(x => x.StudentId == id);
            //return _studentContext.Students.Find(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentsContext.Students.Include(l => l.Lectures).ToList();
        }

        public void DeleteStudentsLectures(Student student)
        {
            student.Lectures.Clear();
            _studentsContext.SaveChanges();
        }

        public Student? GetStudentByEmail(string email)
        {
            return _studentsContext.Students.SingleOrDefault(n => n.StudentEmail.Equals(email));
        }
    }
}