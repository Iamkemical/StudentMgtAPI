using StudentMgtAPI.Models;

namespace StudentMgtAPI.Repository
{
    public interface IAuthStudentRepo
    {
        AuthStudentModel AuthenticateStudent(string userName, string password);
    }
}