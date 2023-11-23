using BigBangProject.Core;
using BigBangProject.Core.GameLogic;
using BigBangProject.Core.Interfaces;
using BigBangProject.Core.Services;
using BigBangProject.Externals.HttpClients;
using BigBangProject.Externals.Interfaces;
using BigBangProject.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IWinConditionChecker, WinConditionChecker>();
builder.Services.AddScoped<IChoiceSelector, ChoiceSelector>();
builder.Services.AddScoped<IRandomChoiceSelector, RandomChoiceSelector>();
builder.Services.AddScoped<IRandomNumberClient, RandomNumberClient>();

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
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
