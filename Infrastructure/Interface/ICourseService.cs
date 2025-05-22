using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interface;

public interface ICourseService
{
     Task<Response<string>> AddCourseAsync(Course course);
    Task<Response<List<Course>>> WatcheCourseAsync();
    Task<Response<int>> GetCourseByIdAsync(int id);
    Task<Response<bool>> UpdateCourseAsync(Course course);
    Task<Response<bool>> DeleteCourseAsync(int id);
}
