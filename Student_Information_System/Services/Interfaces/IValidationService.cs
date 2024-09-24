using Student_Information_System.Data.Database.Entities;

namespace Student_Information_System.Services.Interfaces
{
    public interface IValidationService
    {
        //STUDENT
        //string ValidateStudent(Student student);
        string ValidateStudentName(string name);
        string ValidateStudentLastName(string name);
        string ValidateStudentNumber(string number);
        string ValidateAddStudentDepartment(string departmentCode, int studentNumber);

        //DEPARTMENT
        string ValidateDepartment(Department department);
        string ValidateDepartmentCode(string departmentCode);
        string ValidateDepartmentName(string departmentName);

        //LECTURE
        //string ValidateLecture(Lecture lecture);
        string ValidateLectureName(string lectureName);
        string ValidateLectureDay(string? lectureDay);
        string ValidateLectureFromToTime(string startTime, string endTime);

        //EMAIL
        string ValidateEmail(string email);

        // INPUT
        string ValidateOnlyNumbers(string input);
        string ValidateTimeOnly(string time);


        //
        string ValidateAddLectureToStudent(int studentNumber, int lectureId);
        string ValidateAddLectureToDepartment(string departmentCode, int lectureId);
        string ValidateStudentDepartmentCode(string departmentCode);
    }
}
