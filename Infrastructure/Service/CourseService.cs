using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class CourseService(DataContext context) : ICourseService
{
    public async Task<Response<string>> AddCourseAsync(Course course)
    {
        using var connection = await context.GetConnection();
        var cmd = @"insert into courses (title, description, durationWeeks)
                    values (@title, @description, @durationWeeks )";
        var result = await connection.QuerySingleOrDefaultAsync(cmd, course);
        return result == null ? new Response<string>("Course not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "Course succesfully retrieved");
    }

    public async Task<Response<List<Course>>> WatcheCourseAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select * from courses";
        var result = await connection.QueryAsync<Course>(cmd);
        return result == null ? new Response<List<Course>>("Course not found", HttpStatusCode.NotFound)
        : new Response<List<Course>>(result.ToList(), "Course succesfully retrieved");
    }

    public async Task<Response<int>> GetCourseByIdAsync(int id)
    {
        using var connection = await context.GetConnection();
        var cmd = @"select * from courses
                    where id = @id";
        var result = await connection.ExecuteAsync(cmd, new { CourseId = id });
        return result == 0 ? new Response<int>("Course not found", HttpStatusCode.NotFound)
        : new Response<int>(result, "Course succesfully retrieved");
    }

     public async Task<Response<bool>> UpdateCourseAsync(Course course)
    {
        using var connection = await context.GetConnection();
        var cmd = @"update courses
                    set title = @title,
                    description = @description,
                    durationWeeks = @durationWeeks
                    where id = @id";
        var result = await connection.ExecuteAsync(cmd, course);
        return result == 0 ? new Response<bool>("Course not found", HttpStatusCode.NotFound)
        : new Response<bool>(true, "Course succesfully retrieved");
    }


    public async Task<Response<bool>> DeleteCourseAsync(int id)
    {
        using var connection = await context.GetConnection();
        var cmd = @"Delete from courses
                    where id = @id";
        var result = await connection.QueryAsync(cmd, new {courseid = id});
        return result == null ? new Response<bool>("Course not found", HttpStatusCode.NotFound)
        : new Response<bool>(true, "Course succesfully retrieved");
    }

}
