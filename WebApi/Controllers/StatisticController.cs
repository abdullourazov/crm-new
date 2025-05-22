using Domain.ApiResponse;
using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticController(StatisticsService statisticsService)
{

    [HttpGet("total-students-count")]
    public async Task<Response<int>> GetTotalStudentsCountAsync()
    {
        return await statisticsService.GetTotalStudentsCountAsync();
    }

    [HttpGet("total-groups-count")]
    public async Task<Response<int>> GetTotalGroupsCountAsync()
    {
        return await statisticsService.GetTotalGroupsCountAsync();
    }

    [HttpGet("total-courses-count")]
    public async Task<Response<int>> GetTotalCoursesCountAsync()
    {
        return await statisticsService.GetTotalCoursesCountAsync();
    }

    [HttpGet("total-mentors-count")]
    public async Task<Response<int>> GetTotalMentorsCountAsync()
    {
        return await statisticsService.GetTotalMentorsCountAsync();
    }

    [HttpGet("start-dates")]
    public async Task<Response<List<DateTime>>> GetAllStartDatesAsync()
    {
        return await statisticsService.GetAllStartDatesAsync();
    }
}
