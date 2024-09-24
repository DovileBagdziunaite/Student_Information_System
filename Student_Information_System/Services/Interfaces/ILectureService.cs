using Student_Information_System.Data.Database.Entities;

namespace Student_Information_System.Services.Interfaces
{
    public interface ILectureService
    {
        IEnumerable<Lecture> GetAllLectures();
        string AddLectureToStudent(Student student, Lecture lecture);
        Lecture GetLectureById(int lectureId);
        string CreateLecture(Lecture lecture);
    }
}
