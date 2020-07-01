using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentMgtAPI.Dtos
{
    public class StudentReadDto
    {
         [Key]
        public int Id {get; set; }
        [Required]
        [DisplayName("Full Name")]
        public string FullName {get; set; }
        [Required]
        public string Email {get; set; }
        [Required]
        public string Gender {get; set; }
    }
}