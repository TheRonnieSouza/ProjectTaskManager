using Infrastructure.Persistence;
using Application;
using Microsoft.EntityFrameworkCore;
using ProjectTaskManager.API.ExpectionHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
        .AddApplication();

builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

var stringConnection = builder.Configuration.GetConnectionString("ProjectTaskManager");
//new ProjectTaskManagerDesingFactory(stringConnection);
builder.Services.AddDbContext<ProjectTaskManagerDbContext>(o => o.UseSqlServer(stringConnection));//o => o.UseSqlServer(stringConnection)
//builder.Services.AddDbContext<ProjectTaskManagerDbContext>(u => u.UseInMemoryDatabase("TodoListDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
