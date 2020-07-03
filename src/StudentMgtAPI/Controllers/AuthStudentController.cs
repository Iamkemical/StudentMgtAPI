using Microsoft.AspNetCore.Mvc;
using StudentMgtAPI.Models;
using StudentMgtAPI.Repository;

namespace StudentMgtAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthStudentController : ControllerBase
    {
        private readonly IAuthStudentRepo _authStudentRepo;

        public AuthStudentController(IAuthStudentRepo authStudentRepo)
        {
            _authStudentRepo = authStudentRepo;
        }

        [HttpPost]
        public IActionResult GetStudentCredentials([FromBody] AuthStudentModel studentModel)
        {
            var student = _authStudentRepo.AuthenticateStudent(studentModel.UserName, studentModel.Password);

            if(student is null) return BadRequest(new {message = "Username or Password is Incorrect!"});
            
            return Ok(student);
        }
    }
}