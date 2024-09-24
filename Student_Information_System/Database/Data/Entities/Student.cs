using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Information_System.Data.Database.Entities
{
    [Table(nameof(Student))]
    public class Student
    {

        //privalomi laukai uztikrinant, kad nebutu pamirstas ne vienas property
        public Student(
                            int studentId, string? firstName, 
                            string? lastName, string? studentNumber, 
                            string? studentEmail, string? departmentCode, 
                            ICollection<Lecture> lectures, Department? department)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            StudentNumber = studentNumber;
            StudentEmail = studentEmail;
            DepartmentCode = departmentCode;
            Lectures = lectures;
            Department = department;
        }

        public Student(string? studentNumber, string? firstName, string? lastName, string? studentEmail)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentNumber = studentNumber;
            StudentEmail = studentEmail;
        }

        public Student(string? firstName, string? lastName, string? studentNumber, string? studentEmail, string? departmentCode) : this(firstName, lastName, studentNumber, studentEmail)
        {
            DepartmentCode = departmentCode;
        }

        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StudentNumber { get; set; }
        public string? StudentEmail { get; set; }
        public string? DepartmentCode { get; set; }
        public Department? Department { get; set; }

        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();



        //NUMATOMI APRIBOJIMAI PAGAL UZDUOTI


        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //public int StudentId { get; set; }

        //[Required(ErrorMessage = "First name is required.")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters.")]
        //public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last name is required.")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters.")]
        //public string LastName { get; set; }

        //[Required(ErrorMessage = "Student number is required.")]
        //[StringLength(8, MinimumLength = 8, ErrorMessage = "Student number must be exactly 8 digits.")]
        //[RegularExpression(@"^[0-9]+$", ErrorMessage = "Student number can only contain numbers.")]
        //public string StudentNumber { get; set; }

        //[Required(ErrorMessage = "Email is required.")]
        //[EmailAddress(ErrorMessage = "Invalid email address format.")]
        //public string Email { get; set; }
    }
}
