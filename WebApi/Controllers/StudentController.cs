using Domain.ApiResponse;
using Domain.DTOs;
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
    public async Task<Response<string>> GetStudentByIdAsync(int id)
    {
        return await studentService.GetStudentByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudentAsync(Student student)
    {
        return await studentService.UpdateStudentAsync(student);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        return await studentService.DeleteStudentAsync(id);
    }

    [HttpGet("Get Students With Groups")]
    public async Task<Response<List<StudentsWithGroups>>> GetStudentsWithGroupsAsync()
    {
        return await studentService.GetStudentsWithGroupsAsync();
    }




}
