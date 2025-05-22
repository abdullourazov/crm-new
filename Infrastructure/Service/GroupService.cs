using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class GroupService(DataContext context) : IGroupService
{
     public async Task<Response<string>> AddGroupAsync(Group group)
    {
        using var connection = await context.GetConnection();
        var cmd = @"insert into groups (groupName, startDate, endDate)
                    values (@groupName, @startDate, @endDate)";
        var result = await connection.QuerySingleOrDefaultAsync(cmd, group);
        return result == null ? new Response<string>("Group not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "Group succesfully retrieved");

    }
    public async Task<Response<List<Group>>> WatcheGroupAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select * from groups";
        var result = await connection.QueryAsync<Group>(cmd);
        return result == null ? new Response<List<Group>>("Group not found", HttpStatusCode.NotFound)
        : new Response<List<Group>>(result.ToList(), "Group succesfully retrieved");
    }

    public async Task<Response<int>> GetGroupByIdAsync(int id)
    {
        using var connection = await context.GetConnection();
        var cmd = @"select * from groups
                    where id = @id";
        var result = await connection.ExecuteAsync(cmd, new { GroupId = id });
        return result == 0 ? new Response<int>("Group not found", HttpStatusCode.NotFound)
        : new Response<int>(result, "Group succesfully retrieved");
    }

    public async Task<Response<bool>> UpdateGroupAsync(Group group)
    {
        using var connection = await context.GetConnection();
        var cmd = @"update groups
                    set groupName = @groupName,
                    startDate = @startDate,
                    endDate = @endDate
                    where id = @id";
        var result = await connection.ExecuteAsync(cmd, group);
        return result == 0 ? new Response<bool>("Group not found", HttpStatusCode.NotFound)
        : new Response<bool>(true, "Group succesfully retrieved");
    }


    public async Task<Response<bool>> DeleteGroupAsync(int id)
    {
        using var connection = await context.GetConnection();
        var cmd = @"Delete from groups
                    where id = @id";
        var result = await connection.QueryAsync(cmd, new {groupid = id});
        return result == null ? new Response<bool>("Group not found", HttpStatusCode.NotFound)
        : new Response<bool>(true, "Group succesfully retrieved");
    }
}
