
namespace Student_Information_System.Data.Database.Entities
{
    public class Department
    {
        //privalomi laukai uztikrinant, kad nebutu pamirstas ne vienas property
        public Department(int departmentId, string departmentCode, string departmentName, ICollection<Student> students, ICollection<Lecture> lectures)
        {
            DepartmentId = departmentId;
            DepartmentCode = departmentCode;
            DepartmentName = departmentName;
            Students = students;
            Lectures = lectures;
        }

        public Department(string departmentCode, string departmentName)
        {
            DepartmentCode = departmentCode;
            DepartmentName = departmentName;
        }

        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }


        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();



        //NUMATOMI APRIBOJIMAI PAGAL UZDUOTI


        //public int Id { get; set; }

        //[Required(ErrorMessage = "Department name is required.")]
        //[StringLength(100, MinimumLength = 3, ErrorMessage = "Department name must be between 3 and 100 characters.")]
        //public string Name { get; set; }

        //[Required(ErrorMessage = "Department code is required.")]
        //[RegularExpression(@"^[a-zA-Z0-9]{6}$", ErrorMessage = "Department code must be exactly 6 alphanumeric characters.")]
        //public string Code { get; set; }
    }
}
