using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentMgtAPI.Models;
using StudentMgtAPI.Repository;

namespace StudentMgtAPI.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;

        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        //GET api/student
        [HttpGet]
        public ActionResult <IEnumerable<StudentModel>> GetAllStudent()
        {
           var student = _studentRepo.GetAllStudent();
           return Ok(student);
        }

        //GET api/student/{id}
        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult <StudentModel> GetStudentById(int id)
        {
            var student = _studentRepo.GetStudentById(id);
            if(student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        //POST api/student
        [HttpPost]
        public ActionResult CreateStudentDetails(StudentModel studentModel)
        {
            _studentRepo.CreateStudent(studentModel);
            
            _studentRepo.SaveChanges();

            return CreatedAtRoute(nameof(GetStudentById), new {Id = studentModel.Id}, studentModel);
        }
    }
}