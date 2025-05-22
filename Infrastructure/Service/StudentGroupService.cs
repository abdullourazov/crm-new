using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class StudentGroupService(DataContext context) : IStudentGroupService
{
     public async Task<Response<string>> AddStudentGroupAsync(StudentGroup studentGroup)
    {
        using var connection = await context.GetConnection();
        var cmd = @"insert into studentGroups (status)
                    values (@status)";
        var result = await connection.QuerySingleOrDefaultAsync(cmd, studentGroup);
        return result == null ? new Response<string>("StudentGroup not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "StudentGroup succesfully retrieved");
    }
    public async Task<Response<List<StudentGroup>>> WatcheStudentGroupAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select * from studentGroups";
        var result = await connection.QueryAsync<StudentGroup>(cmd);
        return result == null ? new Response<List<StudentGroup>>("StudentGroup not found", HttpStatusCode.NotFound)
        : new Response<List<StudentGroup>>(result.ToList(), "StudentGroup succesfully retrieved");
    }

    public async Task<Response<int>> GetStudentGroupByIdAsync(int id)
    {
        using var connection = await context.GetConnection();
        var cmd = @"select * from studentGroups
                    where id = @id";
        var result = await connection.ExecuteAsync(cmd, new { MentorId = id });
        return result == 0 ? new Response<int>("StudentGroup not found", HttpStatusCode.NotFound)
        : new Response<int>(result, "StudentGroup succesfully retrieved");
    }

    public async Task<Response<bool>> UpdateStudentGroupAsync(StudentGroup studentGroup)
    {
        using var connection = await context.GetConnection();
        var cmd = @"update studentGroups
                    set status = @status,
                    studentid = @studentid,
                    groupid = @groupid,
                    where id = @id";
        var result = await connection.ExecuteAsync(cmd, studentGroup);
        return result == 0 ? new Response<bool>("StudentGroup not found", HttpStatusCode.NotFound)
        : new Response<bool>(true, "StudentGroup succesfully retrieved");
    }


    public async Task<Response<bool>> DeleteStudentGroupAsync(int id)
    {
        using var connection = await context.GetConnection();
        var cmd = @"Delete from studentGroups
                    where id = @id";
        var result = await connection.QueryAsync(cmd, new {studentgroupid = id});
        return result == null ? new Response<bool>("StudentGroup not found", HttpStatusCode.NotFound)
        : new Response<bool>(true, "StudentGroup succesfully retrieved");
    }
}
