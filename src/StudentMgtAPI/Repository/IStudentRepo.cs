using System.Collections.Generic;
using StudentMgtAPI.Models;

namespace StudentMgtAPI.Repository
{
    public interface IStudentRepo
    {
        IEnumerable<StudentModel> GetAllStudent();
        StudentModel GetStudentById(int id);
        void CreateStudent(StudentModel studentModel);
        void DeleteStudent(StudentModel studentModel);
        void UpdateStudent(StudentModel studentModel);
        bool SaveChanges();
    }
}