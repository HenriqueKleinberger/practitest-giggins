using Microsoft.EntityFrameworkCore;
using GigginsPractitestApi.BLL;
using GigginsPractitestApi.BLL.Interfaces;
using GigginsPractitestApi.DAL;
using GigginsPractitestApi.DAL.Interfaces;
using GigginsPractitestApi.Models;
using FluentValidation;
using GigginsPractitestApi.Validators;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMvc();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy
                          .WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});

builder.Services.AddLogging(builder =>
{
    builder.AddConsole(); // Log to the console
    builder.AddDebug();   // Log to the debug output window
                          // Add other logging providers as needed
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GigginsPractitestApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IGigginDAL, GigginDAL>();
builder.Services.AddScoped<IGigginBLL, GigginBLL>();
builder.Services.AddValidatorsFromAssemblyContaining<GigginDTOValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);
app.Run();
public partial class Program { }
