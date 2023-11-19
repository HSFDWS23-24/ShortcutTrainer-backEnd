using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Data;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

// ToDo: This configuration initializes and sets up the ASP.NET Core application. The DI container is populated with
// various services and mock databases for questions and courses to make them available for different areas within the
// application. Required services need to be registered, before the DI container can inject them in the required classes

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMockDatabase<Joke>, MockJokeDatabase>();
builder.Services.AddSingleton<IMockDatabase<Question>, MockQuestionDatabase>();
builder.Services.AddSingleton<IMockDatabase<Course>, MockCourseDatabase>();



// ToDo: registration of required mock databases; can now be used for DI in services
builder.Services.AddScoped<IJokeService, JokeService>();
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

/*
 if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name V1");
    });
}*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();