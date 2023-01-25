using Scaffold.CrossCutting.DependecyInjector;
using Scaffold.CrossCutting.HealthChecks;
using Scaffold.CrossCutting.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediator();
builder.Services.AddLogger();
builder.Services.AddRepository();
builder.Services.AddHealthCheckConfigurations();
builder.Services.AddSwaggerDocVersion();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
