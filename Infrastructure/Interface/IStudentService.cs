using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Interface;

public interface IStudentService
{
    Task<Response<string>> AddStudentAsync(Student student);
    Task<Response<List<Student>>> WatcheStudentAsync();
    Task<Response<string>> GetStudentByIdAsync(int id);
    Task<Response<string>> UpdateStudentAsync(Student student);
    Task<Response<string>> DeleteStudentAsync(int id);
    Task<Response<List<StudentsWithGroups>>> GetStudentsWithGroupsAsync();
    Task<Response<List<Student>>> GetStudentsWithoutGroupsAsync();
    Task<Response<List<Student>>> GetDroppedOutStudents();
}
