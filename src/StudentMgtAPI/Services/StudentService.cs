using System;
using System.Collections.Generic;
using System.Linq;
using StudentMgtAPI.DatabaseContext;
using StudentMgtAPI.Models;
using StudentMgtAPI.Repository;

namespace StudentMgtAPI.Services
{
    public class StudentService : IStudentRepo
    {
        private readonly StudentDbContext _studentDb;

        public StudentService(StudentDbContext studentDb)
        {
            _studentDb = studentDb;
        }
        public void CreateStudent(StudentModel studentModel)
        {
            if(studentModel is null)
            {
                throw new ArgumentNullException(message: "Couldnt create student entity", null);
            }
            _studentDb.Student.Add(studentModel);
            _studentDb.SaveChanges();
        }

        public void DeleteStudent(StudentModel studentModel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<StudentModel> GetAllStudent()
        {
            return _studentDb.Student.ToList();
        }

        public StudentModel GetStudentById(int id)
        {
            var student = _studentDb.Student.FirstOrDefault(options => options.Id == id);
            if(student is null)
            {
                throw new ArgumentNullException(message: "No such student exists in the database", null);
            }
           return student;
        }

        public bool SaveChanges()
        {
            return (_studentDb.SaveChanges() >=0);
        }

        public void UpdateStudent(StudentModel studentModel)
        {
            //DoNothing
        }
    }
}