using AutoMapper;
using StudentMgtAPI.Dtos;
using StudentMgtAPI.Models;

namespace StudentMgtAPI.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentModel, StudentReadDto>();
            CreateMap<StudentCreateDto, StudentModel>();
            CreateMap<StudentUpdateDto, StudentModel>();
            CreateMap<StudentModel, StudentUpdateDto>();
        }
    }
}