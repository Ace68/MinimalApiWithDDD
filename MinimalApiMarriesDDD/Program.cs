using Microsoft.OpenApi.Models;
using MinimalApiMarriesDDD.Modules;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Register Default Services
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", corsBuilder =>
        corsBuilder.AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader());
});

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs\\ApiLogs.txt")
    .CreateLogger();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo()
{
    Description = "Web API Service for DDD",
    Title = "DDD Api",
    Version = "v1",
    Contact = new OpenApiContact
    {
        Name = "MinimalApiMarriesDDD"
    }
}));

// Register Modules
builder.RegisterModules();

var app = builder.Build();

app.UseCors("CorsPolicy");

//app.UseAuthentication();
//app.UseAuthorization();

// Register endpoints
app.MapEndpoints();

// Configure the HTTP request pipeline.
app.UseSwagger(s =>
{
    s.RouteTemplate = "documentation/{documentName}/documentation.json";
    s.SerializeAsV2 = true;
});
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/documentation/v1/documentation.json", "DDD Web API v1");
    s.RoutePrefix = string.Empty;
});

app.Run();