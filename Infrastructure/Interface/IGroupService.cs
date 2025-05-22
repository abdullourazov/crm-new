using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interface;

public interface IGroupService
{
    
    Task<Response<string>> AddGroupAsync(Group group);
    Task<Response<List<Group>>> WatcheGroupAsync();
    Task<Response<int>> GetGroupByIdAsync(int id);
    Task<Response<bool>> UpdateGroupAsync(Group group);
    Task<Response<bool>> DeleteGroupAsync(int id);
}
