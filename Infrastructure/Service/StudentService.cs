using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class StudentService(DataContext context) : IStudentService
{
    public async Task<Response<string>> AddStudentAsync(Student student)
    {
        using var connection = await context.GetConnection();
        var cmd = @"insert into students (fullname, email, phone, enrollmentDate)
                    values (@fullname, @email, @phone, @enrollmentDate)";
        var result = await connection.QuerySingleOrDefaultAsync(cmd, student);
        return result == null ? new Response<string>("Student not found", HttpStatusCode.NotFound)
        : new Response<string>(null, "Student succesfully retrieved");

    }
    public async Task<Response<List<Student>>> WatcheStudentAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select * from students";
        var result = await connection.QueryAsync<Student>(cmd);
        return result == null ? new Response<List<Student>>("Students not found", HttpStatusCode.NotFound)
        : new Response<List<Student>>(result.ToList(), "Student succesfully retrieved");
    }

    public async Task<Response<string>> GetStudentByIdAsync(int id)
    {
        using var connection = await context.GetConnection();
        var cmd = @"select * from students
                    where id = @id";
        var result = await connection.ExecuteAsync(cmd, new { StudentId = id });
        return result == 0 ? new Response<string>("Student not found", HttpStatusCode.NotFound)
        : new Response<string>(null, "Student succesfully retrieved");
    }

    public async Task<Response<string>> UpdateStudentAsync(Student student)
    {
        using var connection = await context.GetConnection();
        var cmd = @"update students
                    set fullname = @fullname,
                    email = @email,
                    phone = @phone,
                    enrollmentDate = @enrollmentDate
                    where id = @id";
        var result = await connection.ExecuteAsync(cmd, student);
        return result == 0 ?
         new Response<string>("Student not found", HttpStatusCode.NotFound)
        : new Response<string>(null, "Student succesfully retrieved");
    }


    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        using var connection = await context.GetConnection();
        var cmd = @"Delete from students
                    where id = @id";
        var result = await connection.QueryAsync(cmd, new { studentid = id });
        return result == null
        ? new Response<string>("Student not found", HttpStatusCode.NotFound)
        : new Response<string>(null, "Student succesfully retrieved");
    }

    public async Task<Response<List<Student>>> GetStudentsWithoutGroupsAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select s.* from students s
                    left join studentgroups sg on s.id = sg.studentid
                    where sg.studentid is null";
        var result = await connection.QueryAsync<Student>(cmd);
        return result == null
        ? new Response<List<Student>>("Student not found", HttpStatusCode.NotFound)
        : new Response<List<Student>>(result.ToList(), "Student succesfully retrieved");
    }

    public async Task<Response<List<Student>>> GetDroppedOutStudents()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select * from students s
                    join studentgroups sg on s.id = sg.studentid
                    where sg.status = 3";
        var result = await connection.QueryAsync<Student>(cmd);
        return result == null
        ? new Response<List<Student>>("Student not found", HttpStatusCode.NotFound)
        : new Response<List<Student>>(result.ToList(), "Student succesfully retrieved");
    }

    public async Task<Response<List<StudentsWithGroups>>> GetStudentsWithGroupsAsync()
    {
        using var connection = await context.GetConnection();
        var cmd = @"select s.fullname, gr.groupname from students s
                    join studentgroups g on  s.id = g.studentid
                    join groups gr on gr.id = g.groupid";
        var result = await connection.QueryAsync<StudentsWithGroups>(cmd);
        return result == null
        ? new Response<List<StudentsWithGroups>>("Student not found", HttpStatusCode.NotFound)
        : new Response<List<StudentsWithGroups>>(result.ToList(), "Student succesfully retrieved");
    }

}
