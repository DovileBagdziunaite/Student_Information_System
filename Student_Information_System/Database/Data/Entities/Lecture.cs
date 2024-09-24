
namespace Student_Information_System.Data.Database.Entities
{
    public class Lecture
    {
        //privalomi laukai uztikrinant, kad nebutu pamirstas ne vienas property
        public Lecture(int lectureId, string? lectureName, DateTime lectureTime, ICollection<Department> departments)
        {
            LectureId = lectureId;
            LectureName = lectureName;
            LectureTime = lectureTime;
            Departments = departments;
        }

        public Lecture(object value, string lectureName, TimeOnly timeOnly1, TimeOnly timeOnly2, string? lectureDay)
        {
            Value = value;
            LectureName = lectureName;
            TimeOnly1 = timeOnly1;
            TimeOnly2 = timeOnly2;
            LectureDay = lectureDay;
        }

        public int LectureId { get; set; }
        public string? LectureName { get; set; }
        public DateTime LectureTime { get; set; }

        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public object Value { get; }
        public TimeOnly TimeOnly1 { get; }
        public TimeOnly TimeOnly2 { get; }
        public string? LectureDay { get; }



        //NUMATOMI APRIBOJIMAI PAGAL UZDUOTI


        //public int Id { get; set; }

        //[Required(ErrorMessage = "Lecture name is required.")]
        //[StringLength(255, MinimumLength = 5, ErrorMessage = "Lecture name must be at least 5 characters long.")]
        //public string Name { get; set; }

        //[Required(ErrorMessage = "Lecture time is required.")]
        //[Range(typeof(DateTime), "00:00", "23:59", ErrorMessage = "Lecture time must be valid.")]
        //public DateTime Time { get; set; }
    }
}
