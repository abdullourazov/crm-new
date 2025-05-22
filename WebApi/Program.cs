using Infrastructure;
using Infrastructure.Interface;
using Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddScoped<StudentService, StudentService>();
builder.Services.AddScoped<StudentGroupService, StudentGroupService>();
builder.Services.AddScoped<CourseService, CourseService>();
builder.Services.AddScoped<MentorService, MentorService>();
builder.Services.AddScoped<StatisticsService, StatisticsService>();
builder.Services.AddScoped<GroupService, GroupService>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My App"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();


