using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentMgtAPI.Dtos
{
    public class StudentUpdateDto
    {
        [Required]
        [DisplayName("Full Name")]
        public string FullName {get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth {get; set; }
        [Required]
        public string Email {get; set; }
        [Required]
        public string Gender {get; set; }
    }
}