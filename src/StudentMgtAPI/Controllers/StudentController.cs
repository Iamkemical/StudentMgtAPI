using System.Collections;
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentMgtAPI.Models;
using StudentMgtAPI.Repository;
using StudentMgtAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace StudentMgtAPI.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        private IMapper _mapper;

        public StudentController(IStudentRepo studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        //GET api/student
        [HttpGet]
        
        public ActionResult <IEnumerable<StudentModel>> GetAllStudent()
        {
           var student = _studentRepo.GetAllStudent();

           return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(student));
        }

        //GET api/student/{id}
        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult <StudentModel> GetStudentById(int id)
        {
            var student = _studentRepo.GetStudentById(id);
            if(student != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(student));
            }
            return NotFound();
        }

        //POST api/student
        [HttpPost]
        public ActionResult<StudentReadDto> CreateStudentDetails(StudentCreateDto studentCreateDto)
        {
            var student = _mapper.Map<StudentModel>(studentCreateDto);
            
            _studentRepo.CreateStudent(student);

            _studentRepo.SaveChanges();

            var studentReadDto = _mapper.Map<StudentReadDto>(student);

            return CreatedAtRoute(nameof(GetStudentById), new {Id = studentReadDto.Id}, studentReadDto);
        }

        //PUT api/student/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateStudentDetails(int id, StudentUpdateDto studentUpdateDto)
        {
            var student = _studentRepo.GetStudentById(id);
            if(student is null)
            {
                return NotFound();
            }

            _mapper.Map(studentUpdateDto, student);

            _studentRepo.UpdateStudent(student);

            _studentRepo.SaveChanges();

            return NoContent();
        }

        //PATCH api/student/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateStudentDetails(int id, JsonPatchDocument<StudentUpdateDto> patchDoc)
        {
            var student = _studentRepo.GetStudentById(id);
            if(student == null)
            {
                return NotFound();
            }
            var studentPatchDto = _mapper.Map<StudentUpdateDto>(student);

            patchDoc.ApplyTo(studentPatchDto, ModelState);

            if(!TryValidateModel(studentPatchDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentPatchDto, student);

            _studentRepo.UpdateStudent(student);

            _studentRepo.SaveChanges();

            return NoContent();
        }
    }
}