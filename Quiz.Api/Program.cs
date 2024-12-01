using Quiz.Domain.DTO;
using Quiz.Domain.Repository;
using Quiz.Infra.Context;
using Quiz.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddConfiguration<Configuration>(builder.Configuration, "Settings");
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddEnvironmentVariables();

//repository
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<DataContext>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

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
