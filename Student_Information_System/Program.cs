using Student_Information_System.Data.Repositories.Interfaces;
using Student_Information_System.Data.Repositories;
using Student_Information_System.Services.Interfaces;
using Student_Information_System.Services;

namespace Student_Information_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentsContext context = new StudentsContext();
            IDepartmentRepository departmentRepository = new DepartmentRepository(context);
            ILectureRepository lectureRepository = new LectureRepository(context);
            IStudentRepository studentRepository = new StudentRepository(context);
            IDepartmentService departmentService = new DepartmentService();
            ILectureService lectureService = new LectureService();
            IStudentService studentService = new StudentService();
            StudentsProgram studentsProject = new StudentsProgram();
            studentsProject.Start();
        }
    }
}
