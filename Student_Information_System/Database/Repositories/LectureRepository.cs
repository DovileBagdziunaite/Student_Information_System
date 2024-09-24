using Microsoft.EntityFrameworkCore;
using Student_Information_System.Data.Database.Entities;
using Student_Information_System.Data.Repositories.Interfaces;

namespace Student_Information_System.Data.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly StudentsContext _lecturescontext;

        public LectureRepository(StudentsContext context)
        {
            _lecturescontext = context;
        }

        public void Create(Lecture lecture)
        {
            _lecturescontext.Lectures.Add(lecture);
            _lecturescontext.SaveChanges();
        }

        public void Update(Lecture lecture)
        {
            _lecturescontext.Lectures.Update(lecture);
            _lecturescontext.SaveChanges();
        }

        public void Delete(int lectureId)
        {
            var lecture = _lecturescontext.Lectures.SingleOrDefault(c => c.LectureId == lectureId);
            if (lecture != null)
            {
                _lecturescontext.Lectures.Remove(lecture);
                _lecturescontext.SaveChanges();
            }
        }

        public Lecture GetLecturesById(int lectureId)
        {
            return _lecturescontext.Lectures.SingleOrDefault(c => c.LectureId == lectureId);
        }

        public IEnumerable<Lecture> GetAll()
        {
            return _lecturescontext.Lectures.Include(c => c.Departments).ThenInclude(c => c.Lectures).ToList();
        }

        public IEnumerable<Lecture> GetAllLectures()
        {
            return _lecturescontext.Lectures;
        }

        public void AddLectureToStudent(Student student, Lecture lecture)
        {
            student.Lectures.Add(lecture);
            _lecturescontext.SaveChanges();
        }
    }
}
