using Microsoft.IdentityModel.Tokens;
using Student_Information_System.Data.Database.Entities;
using Student_Information_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System
{
    public class StudentsProgram
    {
        private IDepartmentService departmentService;
        private ILectureService lectureService;
        private IStudentService studentService;
        private IValidationService validationService;

        public void Start()
        {
            var choice = 0;
            while (true)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine();

                    Console.WriteLine("1. Departamento sukurimo langas");
                    Console.WriteLine("2. Studento sukurimo langas");
                    Console.WriteLine("3. Paskaitos sukurimo langas");
                    Console.WriteLine("4. Ikelti studenta i departamenta");
                    Console.WriteLine("5. Ikelti paskaita i departamenta");
                    Console.WriteLine("6. Studentui priskirti jam priklausancias paskaitas");


                } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6);
                switch (choice)
                {
                    case 1:
                        CreateDepartment();
                        Console.WriteLine("Departamentas sukurtas");
                        Console.ReadKey();
                        break;
                    case 2:
                        CreateStudent();
                        Console.WriteLine("Studentas sukurtas");
                        Console.ReadKey();
                        break;
                    case 3:
                        CreateLecture();
                        Console.WriteLine("Paskaita sukurta");
                        Console.ReadKey();
                        break;
                    case 4:
                        AddStudentToDepartment();
                        Console.WriteLine("Studentas priskirtas departamentui");
                        Console.ReadKey();
                        break;
                    case 5:
                        AddLectureToDepartment();
                        Console.WriteLine("Paskaita priskirta departamentui");
                        Console.ReadKey();
                        break;
                    case 6:
                        AddLectureToStudent();
                        Console.WriteLine("Paskaita priskirta studentui");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }
        }

        public void CreateDepartment()
        {
            string error = string.Empty;
            string departmentCode;
            string departmentName;
            do
            {
                Console.WriteLine("IDepartamento kodas");
                departmentCode = Console.ReadLine();
                error = validationService.ValidateDepartmentCode(departmentCode);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }

            } while (!error.IsNullOrEmpty());

            do
            {
                Console.WriteLine("Departamento pavadinimas");
                departmentName = Console.ReadLine();
                error = validationService.ValidateDepartmentName(departmentName);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }

            } while (!error.IsNullOrEmpty());

            Department newDepartment = new Department(departmentCode, departmentName);
            departmentService.CreateDepartment(newDepartment);
        }

        public void CreateStudent()
        {
            var error = string.Empty;
            string studentNumber;
            string studentFirstName;
            string studentLastName;
            string departmentCode;
            string studentEmail;
            bool isValid;

            do
            {
                Console.WriteLine("Ivesk studento numeri");
                studentNumber = Console.ReadLine();
                error = validationService.ValidateStudentNumber(studentNumber);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }

            } while (!error.IsNullOrEmpty());

            do
            {
                Console.WriteLine("Ivesk studento varda");
                studentFirstName = Console.ReadLine();
                error = validationService.ValidateStudentName(studentFirstName);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }

            } while (!error.IsNullOrEmpty());

            do
            {
                Console.WriteLine("Ivesk studento pavarde");
                studentLastName = Console.ReadLine();
                error = validationService.ValidateStudentLastName(studentLastName);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }

            } while (!error.IsNullOrEmpty());

            do
            {
                Console.WriteLine("Ivesk studento e-mail");
                studentEmail = Console.ReadLine();
                error = validationService.ValidateEmail(studentEmail);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }

            } while (!error.IsNullOrEmpty());

            do
            {
                Console.WriteLine("Ivesk studentui departamenta");
                departmentCode = Console.ReadLine();
                error = validationService.ValidateStudentDepartmentCode(departmentCode);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }

            } while (!error.IsNullOrEmpty());

            Student newStudent = new Student(studentNumber, studentFirstName, studentLastName, studentEmail, departmentCode);
            studentService.CreateStudent(newStudent);
        }

        public void CreateLecture()
        {
            var error = string.Empty;
            string lectureName;
            string lectureTimeFromHours;
            string lectureTimeToHours;
            string lectureDay;


            do
            {
                Console.WriteLine("Ivesk paskaitos pavadinima");
                lectureName = Console.ReadLine();
                error = validationService.ValidateLectureName(lectureName);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }

            } while (!error.IsNullOrEmpty());
            do
            {
                do
                {
                    Console.WriteLine("Ivesk paskaitos pradzia formatu HH:MM");
                    lectureTimeFromHours = Console.ReadLine();
                    error = validationService.ValidateTimeOnly(lectureTimeFromHours);
                    if (!error.IsNullOrEmpty())
                    {
                        Console.WriteLine(error);
                    }

                } while (!error.IsNullOrEmpty());

                do
                {
                    Console.WriteLine("Ivesk paskaitos pabaiga formatu HH:MM");
                    lectureTimeToHours = Console.ReadLine();
                    error = validationService.ValidateTimeOnly(lectureTimeToHours);
                    if (!error.IsNullOrEmpty())
                    {
                        Console.WriteLine(error);
                    }

                } while (!error.IsNullOrEmpty());
                error = validationService.ValidateLectureFromToTime(lectureTimeFromHours, lectureTimeToHours);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }
            } while (!error.IsNullOrEmpty());

            do
            {
                Console.WriteLine("Ivesk paskaitos diena kuriai priskiriama info");
                lectureDay = Console.ReadLine();
                error = validationService.ValidateLectureDay(lectureDay);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }

            } while (!error.IsNullOrEmpty());

            Lecture newLecture = new Lecture(null, lectureName, TimeOnly.Parse(lectureTimeFromHours), TimeOnly.Parse(lectureTimeToHours), lectureDay);
            lectureService.CreateLecture(newLecture);
        }

        public IEnumerable<Student> PrintAllStudents()
        {
            var students = studentService.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"Numeris: {student.StudentNumber}, studento vardas: {student.FirstName}, pavardė: {student.LastName}, departamento kodas: {student.DepartmentCode}");
            }
            return students;
        }

        public IEnumerable<Department> PrintAllDepartments()
        {
            var departments = departmentService.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine($"Kodas: {department.DepartmentCode}, departamento pavadinimas: {department.DepartmentName}");
            }
            return departments;
        }

        public void AddStudentToDepartment()
        {
            string error = string.Empty;
            string studentNumber;
            string departmentCode;
            PrintAllStudents();

            do
            {
                Console.WriteLine("Ivesk studento numeri");
                studentNumber = Console.ReadLine();
                error = validationService.ValidateStudentNumber(studentNumber);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }
                else
                {
                    var student = studentService.GetStudentByNumber(int.Parse(studentNumber));
                    if (student != null)
                    {
                        PrintAllDepartments();
                        do
                        {
                            Console.WriteLine("Ivessk departamento koda");
                            departmentCode = Console.ReadLine();
                            var department = departmentService.GetDepartmentByCode(departmentCode);
                            if (department != null)
                            {
                                studentService.AddStudentToDepartment(departmentCode, student);
                                error = string.Empty;
                            }
                            else
                            {
                                error = "Nerastas departamentas - pasitikrink ar teisingai ivesdei departamento koda";
                                Console.WriteLine(error);
                            }
                        } while (!error.IsNullOrEmpty());
                    }
                    else
                    {
                        error = "Studentas nerastas";
                        Console.WriteLine(error);
                    }
                }
            } while (!error.IsNullOrEmpty());
        }

        public void PrintAllLectures()
        {
            var lectures = lectureService.GetAllLectures();
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"Id: {lecture.LectureId}, pavadinimas: {lecture.LectureName}, nuo: {lecture.LectureTime.TimeOfDay}, iki: {lecture.LectureTime}, diena: {GetLectureDay(lecture.LectureDay)}");
            }
        }

        public string GetLectureDay(string day)
        {
            if (day == null)
            {
                return "Monday,Tuesday,Wednesday,Thursday,Friday";
            }
            return day;
        }

        public void AddLectureToDepartment()
        {
            string error = string.Empty;
            string lectureId;
            string departmentCode;
            PrintAllLectures();
            do
            {
                Console.WriteLine("Ivesk paskaitos id - lectureId");
                lectureId = Console.ReadLine();
                error = validationService.ValidateOnlyNumbers(lectureId);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }
                else
                {
                    var lecture = lectureService.GetLectureById(int.Parse(lectureId));
                    if (lecture != null)
                    {
                        PrintAllDepartments();
                        do
                        {
                            Console.WriteLine("Ivesk departamento koda");
                            departmentCode = Console.ReadLine();
                            var department = departmentService.GetDepartmentByCode(departmentCode);
                            if (department != null)
                            {
                                departmentService.AddLectureToDepartment(department, lecture);
                                error = string.Empty;
                            }
                            else
                            {
                                error = "Departamentas nerastas";
                                Console.WriteLine(error);
                            }
                        } while (!error.IsNullOrEmpty());
                    }
                    else
                    {
                        error = "Paskaitos su siuo lectuteId nerastas";
                        Console.WriteLine(error);
                    }
                }
            } while (!error.IsNullOrEmpty());
        }


        public void AddLectureToStudent()
        {
            string error = string.Empty;
            string lectureId;
            string studentNumber;
            PrintAllLectures();
            do
            {
                Console.WriteLine("Ivesk paskaitos id");
                lectureId = Console.ReadLine();
                error = validationService.ValidateOnlyNumbers(lectureId);
                if (!error.IsNullOrEmpty())
                {
                    Console.WriteLine(error);
                }
                else
                {
                    var lecture = lectureService.GetLectureById(int.Parse(lectureId));
                    if (lecture != null)
                    {
                        PrintAllStudents();
                        do
                        {
                            Console.WriteLine("Ivesk studento numeri");
                            studentNumber = Console.ReadLine();
                            error = validationService.ValidateOnlyNumbers(studentNumber);
                            if (!error.IsNullOrEmpty())
                            {
                                Console.WriteLine(error);
                            }
                            else
                            {
                                var student = studentService.GetStudentByNumber(int.Parse(studentNumber));
                                if (student != null)
                                {
                                    lectureService.AddLectureToStudent(student, lecture);
                                    error = string.Empty;
                                }
                                else
                                {
                                    error = "Studentas nerastas. Pasitikrinkite ar teisingas studento numeris";
                                    Console.WriteLine(error);
                                }
                            }
                        } while (!error.IsNullOrEmpty());
                    }
                    else
                    {
                        error = "Paskaita nerasta. Pasitikrinkite ar teisingas paskaitos id";
                        Console.WriteLine(error);
                    }
                }
            } while (!error.IsNullOrEmpty());
        }
    }
}
