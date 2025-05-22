using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController(GroupService groupService)
{

    [HttpPost]
    public async Task<Response<string>> AddGroupAsync(Group group)
    {
        return await groupService.AddGroupAsync(group);
    }

    [HttpGet]
    public async Task<Response<List<Group>>> WatcheGroupAsync()
    {
        return await groupService.WatcheGroupAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<int>> GetGroupByIdAsync(int id)
    {
        return await groupService.GetGroupByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<bool>> UpdateGroupAsync(Group group)
    {
        return await groupService.UpdateGroupAsync(group);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<bool>> DeleteGroupAsync(int id)
    {
        return await groupService.DeleteGroupAsync(id);
    }
}
