using Microsoft.EntityFrameworkCore;
using MinApiTestsSample;
using MinApiTestsSample.Data;
using MinApiTestsSample.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddDbContext<TodoGroupDbContext>(options =>
{
    var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); 
    options.UseSqlite($"Data Source={Path.Join(path, "WebMinRouteGroup.db")}");
});


var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<TodoGroupDbContext>();
db?.Database.MigrateAsync();

// todoV1 endpoints
app.MapGroup("/todos/v1")
    .MapTodosApiV1()
    .WithTags("Todo Endpoints");

// todoV2 endpoints
app.MapGroup("/todos/v2")
    .MapTodosApiV2()
    .WithTags("Todo Endpoints");


app.MapGet("/", () => "Hello World!");

app.Run();

public partial class Program { }
