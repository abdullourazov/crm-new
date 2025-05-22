using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interface;

public interface IStudentGroupService
{
    Task<Response<string>> AddStudentGroupAsync(StudentGroup studentGroup);
    Task<Response<List<StudentGroup>>> WatcheStudentGroupAsync();
    Task<Response<int>> GetStudentGroupByIdAsync(int id);
    Task<Response<bool>> UpdateStudentGroupAsync(StudentGroup studentGroup);
    Task<Response<bool>> DeleteStudentGroupAsync(int id);
}
