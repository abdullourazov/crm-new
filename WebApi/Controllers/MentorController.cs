using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MentorController(MentorService mentorService)
{
    [HttpPost]
    public async Task<Response<string>> AddMentorAsync(Mentor mentor)
    {
        return await mentorService.AddMentorAsync(mentor);
    }

    [HttpGet]
    public async Task<Response<List<Mentor>>> WatcheMentorAsync()
    {
        return await mentorService.WatcheMentorAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<int>> GetMentorByIdAsync(int id)
    {
        return await mentorService.GetMentorByIdAsync(id);
    }

    [HttpPut]
    public async Task<Response<bool>> UpdateMentorAsync(Mentor mentor)
    {
        return await mentorService.UpdateMentorAsync(mentor);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<bool>> DeleteMentorAsync(int id)
    {
        return await mentorService.DeleteMentorAsync(id);
    }
}
