using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using StudentMgtAPI.Models;
using StudentMgtAPI.Repository;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System;

namespace StudentMgtAPI.Services
{
    public class AuthStudentService : IAuthStudentRepo
    {
        private readonly AppSettings _appsetting;

        public AuthStudentService(IOptions<AppSettings> appsetting)
        {
            _appsetting = appsetting.Value;
        }

         private List<AuthStudentModel> authStudentModel = new List<AuthStudentModel>
            {
                new AuthStudentModel {
                    StudentId = 1,
                    FirstName = "Gabriel",
                    LastName = "Isaac",
                    UserName = "Iamkemical",
                    Password = "Stron9pa55word"
                }
            };
        public AuthStudentModel AuthenticateStudent(string userName, string password)
        {
           var student = authStudentModel.SingleOrDefault(x => x.UserName == userName && x.Password == password);
           
            //return null if user is not found
            if (student is null) return null;

            //if user is found
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsetting.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, student.StudentId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V1.0"),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            student.Token = tokenHandler.WriteToken(token);

            student.Password = null;

            return student;
        }
    }
}