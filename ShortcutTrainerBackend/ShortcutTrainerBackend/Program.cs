using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Database;
using ShortcutTrainerBackend.Services;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Data;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

// ToDo: This configuration initializes and sets up the ASP.NET Core application. The DI container is populated with
// various services and mock databases for questions and courses to make them available for different areas within the
// application. Required services need to be registered, before the DI container can inject them in the required classes

var builder = WebApplication.CreateBuilder(args);

// ToDo: Improve database handling
DatabaseHelper.CreateDatabaseConnection();
// ToDo: uncomment if you want to delete all data from mock db and demonstrate data creation via DevExpress.Xpo
// DatabaseHelper.ShowDemo();

// ToDo: registration of required mock databases; can now be used for DI in services
builder.Services.AddSingleton<IMockDatabase<Joke>, MockJokeDatabase>();

// Add services to the container.
builder.Services.AddScoped<IJokeService, JokeService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();