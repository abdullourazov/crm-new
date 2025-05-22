using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class MentorService(DataContext context) : IMentorService
{
     public async Task<Response<string>> AddMentorAsync(Mentor mentor)
    {
        using var connection = await context.GetConnection();
        var cmd = @"insert into mentors (fullname, email, phone, specialization)
                    values (@fullname, @email, @phone, @specialization)";
        var result = await connection.QuerySingleOrDefaultAsync(cmd, mentor);
        return result == null ? new Response<string>("Mentor not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "Mentor succesfully retrieved");
    }
    public async Task<Response<List<Mentor>>> WatcheMentorAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select * from mentor";
        var result = await connection.QueryAsync<Mentor>(cmd);
        return result == null ? new Response<List<Mentor>>("Mentor not found", HttpStatusCode.NotFound)
        : new Response<List<Mentor>>(result.ToList(), "Mentor succesfully retrieved");
    }

    public async Task<Response<int>> GetMentorByIdAsync(int id)
    {
        using var connection = await context.GetConnection();
        var cmd = @"select * from mentors
                    where id = @id";
        var result = await connection.ExecuteAsync(cmd, new { MentorId = id });
        return result == 0 ? new Response<int>("Mentor not found", HttpStatusCode.NotFound)
        : new Response<int>(result, "Mentor succesfully retrieved");
    }

    public async Task<Response<bool>> UpdateMentorAsync(Mentor mentor)
    {
        using var connection = await context.GetConnection();
        var cmd = @"update mentors
                    set fullName = @fullName,
                    email = @email,
                    phone = @phone,
                    specialization = @specialization
                    where id = @id";
        var result = await connection.ExecuteAsync(cmd, mentor);
        return result == 0 ? new Response<bool>("Mentor not found", HttpStatusCode.NotFound)
        : new Response<bool>(true, "Mentor succesfully retrieved");
    }


    public async Task<Response<bool>> DeleteMentorAsync(int id)
    {
        using var connection = await context.GetConnection();
        var cmd = @"Delete from mentors
                    where id = @id";
        var result = await connection.QueryAsync(cmd, new {mentorid = id});
        return result == null ? new Response<bool>("Mentor not found", HttpStatusCode.NotFound)
        : new Response<bool>(true, "Mentor succesfully retrieved");
    }
}
