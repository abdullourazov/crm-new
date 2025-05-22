using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/{Controller}")]


public class StudentController(StudentService studentService)
{
    [HttpPost]
    public async Task<Response<string>> AddStudentAsync(Student student)
    {
        return await studentService.AddStudentAsync(student);
    }

    [HttpGet]
    public async Task<Response<List<Student>>> WatcheStudentAsync()
    {
        return await studentService.WatcheStudentAsync();
    }

    [HttpGet("id:int")]
    public async Task<Response<int>> GetStudentByIdAsync(int id)
    {
        return await studentService.GetStudentByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<bool>> UpdateStudentAsync(Student student)
    {
        return await studentService.UpdateStudentAsync(student);
    }

    [HttpDelete]
    public async Task<Response<bool>> DeleteStudentAsync(int id)
    {
        return await studentService.DeleteStudentAsync(id);
    }

    [HttpGet("Get Students With Groups")]
    public async Task<Response<string>> GetStudentsWithGroupsAsync()
    {
        return await studentService.GetStudentsWithGroupsAsync();
    }




}
