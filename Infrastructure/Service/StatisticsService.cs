using System.Net;
using Dapper;
using Domain.ApiResponse;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class StatisticsService(DataContext context) : IStatisticsService
{
     public async Task<Response<int>> GetTotalStudentsCountAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select count(id)
                    from students ";
        var result = await connection.ExecuteAsync(cmd);
        return result == 0 ? new Response<int>("Students not found", HttpStatusCode.NotFound)
        : new Response<int>(result, "Student succesfully retrieved");
    }

    public async Task<Response<int>> GetTotalGroupsCountAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select distinct count(*)
                    from groups";
        var result = await connection.ExecuteAsync(cmd);
        return result == 0 ? new Response<int>("Students not found", HttpStatusCode.NotFound)
        : new Response<int>(result, "Student succesfully retrieved");
    }

    public async Task<Response<int>> GetTotalCoursesCountAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select distinct(title), count(c.*)   as chislorazlichnix
                    from courses c
                    group by title
                    order by chislorazlichnix desc;";
        var result = await connection.ExecuteAsync(cmd);
        return result == 0 ? new Response<int>("Students not found", HttpStatusCode.NotFound)
        : new Response<int>(result, "Student succesfully retrieved");
    }

    public async Task<Response<int>> GetTotalMentorsCountAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select count(*)
                    from mentors";
        var result = await connection.ExecuteAsync(cmd);
        return result == 0 ? new Response<int>("Students not found", HttpStatusCode.NotFound)
        : new Response<int>(result, "Student succesfully retrieved");
    }

    public async Task<Response<List<DateTime>>> GetAllStartDatesAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select distinct(startdate)
                    from groups";
        var result = await connection.QueryAsync<DateTime>(cmd);
        return result == null ? new Response<List<DateTime>>("Students not found", HttpStatusCode.NotFound)
        : new Response<List<DateTime>>(result.ToList(), "Student succesfully retrieved");
    }
}
