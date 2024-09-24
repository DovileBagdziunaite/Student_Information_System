using Student_Information_System.Data.Database.Entities;

namespace Student_Information_System.Data.Repositories.Interfaces
{
    internal interface ILectureRepository
    {
        void Create(Lecture lecture);
        void Update(Lecture lecture);
        Lecture? GetLecturesById(int lectureId);
        IEnumerable<Lecture> GetAllLectures();
        void Delete(int lectureId);
        void AddLectureToStudent(Student student, Lecture lecture);
    }
}
