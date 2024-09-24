using Microsoft.IdentityModel.Tokens;
using Student_Information_System.Data.Database.Entities;
using Student_Information_System.Data.Repositories.Interfaces;
using Student_Information_System.Services.Interfaces;

namespace Student_Information_System.Services
{
    public class LectureService : ILectureService
    {
        private ILectureRepository lectureRepository;
        private IValidationService validService;

        public string CreateLecture(Lecture lecture)
        {
            string error = string.Empty;
            if (!error.IsNullOrEmpty())
            {
                return error;
            }
            lectureRepository.Create(lecture);
            return error;
        }

        public IEnumerable<Lecture> GetAllLectures()
        {
            return lectureRepository.GetAllLectures();
        }

        public Lecture GetLectureById(int lectureId)
        {
            return lectureRepository.GetLecturesById(lectureId);
        }

        public string AddLectureToStudent(Student student, Lecture lecture)
        {
            string error = string.Empty;
            error = validService.ValidateAddLectureToStudent(student.StudentId, lecture.LectureId);
            if (!error.IsNullOrEmpty())
            {
                return error;
            }
            lectureRepository.AddLectureToStudent(student, lecture);
            return string.Empty;
        }
    }
}
