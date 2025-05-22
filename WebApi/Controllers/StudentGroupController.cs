using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class StudentGroupController(StudentGroupService studentGroupService)
{
    [HttpPost]
    public async Task<Response<string>> AddStudentGroupAsync(StudentGroup studentGroup)
    {
        return await studentGroupService.AddStudentGroupAsync(studentGroup);
    }

    [HttpGet]
    public async Task<Response<List<StudentGroup>>> WatcheStudentGroupAsync()
    {
        return await studentGroupService.WatcheStudentGroupAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<int>> GetStudentGroupByIdAsync(int id)
    {
        return await studentGroupService.GetStudentGroupByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<bool>> UpdateStudentGroupAsync(StudentGroup studentGroup)
    {
        return await studentGroupService.UpdateStudentGroupAsync(studentGroup);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<bool>> DeleteStudentGroupAsync(int id)
    {
        return await studentGroupService.DeleteStudentGroupAsync(id);
    }
}
