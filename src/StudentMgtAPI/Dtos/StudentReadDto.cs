using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentMgtAPI.Dtos
{
    public class StudentReadDto
    {
        public int Id {get; set; }
        
        public string FullName {get; set; }
        
        public string Email {get; set; }
      
        public string Gender {get; set; }
    }
}