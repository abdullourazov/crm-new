using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController(CourseService courseService)
{

    [HttpPost]
    public async Task<Response<string>> AddCourseAsync(Course course)
    {
        return await courseService.AddCourseAsync(course);
    }

    [HttpGet]
    public async Task<Response<List<Course>>> WatcheCourseAsync()
    {
        return await courseService.WatcheCourseAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<int>> GetCourseByIdAsync(int id)
    {
        return await courseService.GetCourseByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<bool>> UpdateCourseAsync(Course course)
    {
        return await courseService.UpdateCourseAsync(course);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<bool>> DeleteCourseAsync(int id)
    {
        return await courseService.DeleteCourseAsync(id);
    }
}
