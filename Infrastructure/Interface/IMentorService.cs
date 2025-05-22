using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interface;

public interface IMentorService
{
    
    Task<Response<string>> AddMentorAsync(Mentor mentor);
    Task<Response<List<Mentor>>> WatcheMentorAsync();
    Task<Response<int>> GetMentorByIdAsync(int id);
    Task<Response<bool>> UpdateMentorAsync(Mentor mentor);
    Task<Response<bool>> DeleteMentorAsync(int id);
}
