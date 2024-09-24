using Student_Information_System.Data.Database.Entities;
using Student_Information_System.Data.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using Student_Information_System.Services.Interfaces;
using Student_Information_System.Data.Repositories;

namespace Student_Information_System.Services
{
    public class ValidationService: IValidationService
    {
        private readonly StudentsContext _studentscontext;
        private IDepartmentRepository departmentRepository;
        private ILectureRepository lectureRepository;
        private IStudentRepository studentRepository;

        public ValidationService(StudentsContext context, DepartmentRepository departmentRepository, LectureRepository lectureRepository, StudentRepository studentRepository)
        {
            Context = context;
            DepartmentRepository = departmentRepository;
            LectureRepository = lectureRepository;
            StudentRepository = studentRepository;
        }

        public StudentsContext Context { get; }
        public DepartmentRepository DepartmentRepository { get; }
        public LectureRepository LectureRepository { get; }
        public StudentRepository StudentRepository { get; }

        public string ValidateDepartment(Department department)
        {
            string error = string.Empty;
            error = ValidateDepartmentCode(department.DepartmentCode);
            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }
            error = ValidateDepartmentName(department.DepartmentName);
            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            return error;
        }

        public string ValidateAddLectureToDepartment(string departmentCode, int lectureId)
        {
            string error = string.Empty;
            var departmentDb = departmentRepository.GetDepartmentByCode(departmentCode);
            if (departmentDb == null)
            {
                return "Departmentas neegzistuoja";
            }
            var lectureDb = lectureRepository.GetLecturesById(lectureId);
            if (lectureDb == null)
            {
                return "Paskaita neegzistuoja";
            }
            var lectureExists = departmentDb.Lectures.SingleOrDefault(l => l.LectureId == lectureId);
            if (lectureExists != null)
            {
                return "Paskaita departamente jau yra";
            }

            return string.Empty;
        }

        public string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return "E-mail yra privalomas";
            }
            else
            {
                var emailAttribute = new EmailAddressAttribute();
                if (!emailAttribute.IsValid(email))
                {
                    return "Netinkamas e-mail'o formatas";
                }
            }
            var parts = email.Split('@');
            var domainParts = parts[1].Split('.');
            if (domainParts.Length < 2)
                return "Netinkamas e-mail'o formatas";

            if (string.IsNullOrWhiteSpace(email))
            {
                return "E-mail privalomas";
            }
            var student = studentRepository.GetStudentByEmail(email);
            if (student != null)
            {
                return "E-mail jau egzistuoja";
            }
            return string.Empty;
        }

        public string ValidateStudentName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (name.Length < 2)
                {
                    return "Studento vardas privalo but ne trumpesnis kaip 2 simboliai";
                }
                if (name.Length > 50)
                {
                    return "Studento vardas privalo but ne ilgesnis kaip 50 simboliu";
                }

                foreach (char c in name)
                {
                    if (!char.IsLetter(c))
                    {
                        return "Vardas privalo but tik is raidziu";
                    }
                }
            }
            else
            {
                return "Laukelis studento vardas turi privalo but nurodytas";
            }
            return string.Empty;
        }

        public string ValidateStudentLastName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (name.Length < 2)
                {
                    return "Studento pavarde privalo but ne trumpesnis kaip 2 simboliai";
                }
                if (name.Length > 50)
                {
                    return "Studento pavarde privalo but ne ilgesnis kaip 50 simboliu";
                }

                // Check if all characters are letters
                foreach (char c in name)
                {
                    if (!char.IsLetter(c))
                    {
                        return "Laukelis studento pavarde turi privalo but nurodytas";
                    }
                }
            }
            else
            {
                return "Laukelis studento vardas privalo buti nurodytas";
            }
            return string.Empty;
        }

        public string ValidateOnlyNumbers(string input)
        {
            if (!int.TryParse(input, out int number))
            {
                return "Privaloma ivesti tik skaicius";
            }
            return string.Empty;
        }

        public string ValidateStudentNumber(string number)
        {
            if (!int.TryParse(number, out int studentNumber))
            {
                return "Studento numeris privalo buti tik is skaiciu";
            }

            if (studentNumber > 99999999 || studentNumber < 10000000)
            {
                return "Studento numeris privalo buti tikslus - 8 simboliu ilgis";
            }
            return string.Empty;
        }

        public string ValidateStudentIdExists(int studentId)
        {
            var student = studentRepository.GetById(studentId);
            if (student != null)
            {
                return "Studentas siuo numeriu jau egzistuoja";
            }

            return string.Empty;
        }

        public string ValidateStudentDepartmentCode(string departmentCode)
        {
            if (string.IsNullOrWhiteSpace(departmentCode))
            {
                return "Departamento kodas yra butinas";
            }

            if (departmentCode.Length != 6)
            {
                return "Departamento kodas privalo butti 6 simbolių ilgio";
            }
            var department = departmentRepository.GetDepartmentByCode(departmentCode);
            if (department == null)
            {
                return "Departmento kodas neegzistuoja";
            }

            return string.Empty;
        }

        public string ValidateDepartmentCode(string departmentCode)
        {
            if (string.IsNullOrWhiteSpace(departmentCode))
            {
                return "Departamento kodas yra butinas";
            }
            foreach (char c in departmentCode)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return "Departamento kodas privalomai tuti butti tik raides ir skaiciai";
                }
            }
            if (departmentCode.Length != 6)
            {
                return "Departamento kodas privalo buti - 6 simboliu ilgis";
            }
            var department = departmentRepository.GetDepartmentByCode(departmentCode);
            if (department != null)
            {
                return "Departmento kodas egzistuoja jauu";
            }

            return string.Empty;
        }

        public string ValidateDepartmentName(string departmentName)
        {
            if (string.IsNullOrWhiteSpace(departmentName))
            {
                return "Departamento pavadinimas yra butinas";
            }
            foreach (char c in departmentName)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return "Departamento pavadinimas privalomumas buti tik raidss ir skaiciai";
                }
            }
            if (departmentName.Length < 3)
            {
                return "Departamento pavadinimas - ne trumpesnis kaip 3 simboliai";
            }
            return string.Empty;
        }

        public string ValidateLectureName(string lectureName)
        {
            if (string.IsNullOrWhiteSpace(lectureName))
            {
                return "Paskaitos pavadinimas yra privalomas";
            }
            if (lectureName.Length < 5)
            {
                return "Paskaitos pavadinimas turi būti ne trumpesnis kaip 5 simboliai";
            }
            return string.Empty;
        }

        public string ValidateLectureFromToTime(string startTime, string endTime)
        {
            if (!TimeOnly.TryParse(startTime, out TimeOnly start) || !TimeOnly.TryParse(endTime, out TimeOnly end))
            {
                return "Llaiko formatas neteisingas.";
            }

            if (start.Hour >= 24 || end.Hour >= 24)
            {
                return "Laiko pradzia ir pabaiga privalo tilpti tarp 00:00 ir 24:00";
            }

            if (end < start)
            {
                return "Pabaigos laikas negali buti ankstesnis uz pradzios laika";
            }
            return string.Empty;
        }

        public string ValidateTimeOnly(string time)
        {
            if (!TimeOnly.TryParse(time, out TimeOnly timeOnly))
            {
                return "Laiko formatas netinkamas";
            }
            return string.Empty;
        }

        public string ValidateLectureDay(string? lectureDay)
        {
            if (string.IsNullOrWhiteSpace(lectureDay))
            {
                return string.Empty;
            }

            string[] validDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday." };

            if (lectureDay != null && !validDays.Contains(lectureDay))
            {
                return "Savaites dienos privalo buti - Monday, Tuesday, Wednesday, Thursday, Friday.";
            }
            return string.Empty;
        }

        public string ValidateAddStudentDepartment(string departmentCode, int studentId)
        {
            var departmentExists = departmentRepository.GetDepartmentByCode(departmentCode);
            if (departmentExists == null)
            {
                return "Departamento kodas neegzistuoja.";
            }
            var studentDb = studentRepository.GetById(studentId);
            if (studentDb == null)
            {
                return "Studentas neegzistuoja.";
            }
            return string.Empty;
        }

        public string ValidateAddLectureToStudent(int studentId, int lectureId)
        {
            string error = string.Empty;
            var studentDb = studentRepository.GetById(studentId);
            if (studentDb == null)
            {
                return "Studentas neegzistuoja";
            }
            var lectureDb = lectureRepository.GetLecturesById(lectureId);
            if (lectureDb == null)
            {
                return "Paskaita neegzistuoja";
            }
            var departmentDb = departmentRepository.GetDepartmentByCode(studentDb.DepartmentCode).Lectures.SingleOrDefault(l => l.LectureId == lectureId);
            if (departmentDb == null)
            {
                return "Paskaita nera priskirta siam departmentui";
            }
            return string.Empty;
        }
    }
}
