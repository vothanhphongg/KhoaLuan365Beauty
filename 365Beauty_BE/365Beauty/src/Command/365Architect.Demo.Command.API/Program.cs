using _365Beauty.Command.API.DependencyInjection.Extensions;
using _365Beauty.Command.API.DependencyInjection.Options;
using _365Beauty.Command.API.Middleware;
using _365Beauty.Command.Application.DependencyInjection.Extension;
using _365Beauty.Command.Persistence.DependencyInjection.Extensions;
using _365Beauty.Command.Presentation.Abstractions;
using _365Architect.Demo.Command.Presentation.Common;
using Asp.Versioning;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
var serviceName = "test";
//register controllers
builder.Services.AddControllers().AddApplicationPart(Assembly.GetExecutingAssembly());
//register api configuration
builder.Services.AddSingleton(new ApiConfig { Name = serviceName });
//Configure swagger
builder.Services.ConfigureOptions<SwaggerConfigureOptions>();

//Configure api versioning
builder.Services.AddApiVersioning(
            options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("x-api-version"),
                    new QueryStringApiVersionReader());
            })
        .AddMvc()
        .AddApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policy =>
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseApiLayerSwagger();
}
app.UseCors("AllowLocalhost3000");
app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthorization();
app.MapPresentation();
app.Run();