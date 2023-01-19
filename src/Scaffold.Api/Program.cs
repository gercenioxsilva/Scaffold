using Microsoft.AspNetCore.Mvc.Versioning;
using Scaffold.CrossCutting.DependecyInjector;
using Scaffold.CrossCutting.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediator();
builder.Services.AddLogger();
builder.Services.AddRepository();
builder.Services.AddHealthCheckConfigurations();
builder.Services.AddSwaggerGen(options => 
{
    options.CustomSchemaIds(type => type.ToString());
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() 
    {
        Title = "Scaffold Api DotNet Core version 1.0",
        Version= "v1",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact() 
        {
            Email = "gercenio@gmail.com",
            Name = "Gercenio Xavier"
        }
    });
});
builder.Services.AddApiVersioning(opt => 
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("x-api-version"),
        new MediaTypeApiVersionReader("x-api-version"));
});
builder.Services.AddVersionedApiExplorer(setup => 
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
