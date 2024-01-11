using DevExpress.Xpo;
using ShortcutTrainerBackend.Database;
using ShortcutTrainerBackend.Services;
using ShortcutTrainerBackend.Services.Interfaces;

// ToDo: This configuration initializes and sets up the ASP.NET Core application. The DI container is populated with
// various services and mock databases for questions and courses to make them available for different areas within the
// application. Required services need to be registered, before the DI container can inject them in the required classes

var builder = WebApplication.CreateBuilder(args);

if (!DatabaseHelper.TryCreateDatabaseConnection())
    Environment.Exit(1);

// ToDo: uncomment if you want to delete all data from mock db and demonstrate data creation via DevExpress.Xpo
//DatabaseHelper.ShowDemo();
// ToDo: eigene Service-Registrierung implementieren
// Add required parameters for service DI
builder.Services.AddSingleton<Session>();

// Add services to the container.
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ICourseService, CourseService>();

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