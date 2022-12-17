using AdventOfCode.Controllers;
using AdventOfCode.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdventOfCode", Version = "v1" });
    c.ParameterFilter<ParameterFilter>();
});

builder.Services.AddScoped<ISolutionService, SolutionService>();
builder.Services.AddScoped<IPuzzleHelperService, PuzzleHelperService>();

// This is a collapsable region so that I can hide my shameful, unintuitive, lazy, "clever", and unreadable code :'(
#region Here be dragons!
// Here be dragons! ( Especially lazy dragons ;) )
// Get a list of assembly types for the whole app
Type[] assemblyTypes = Assembly.GetAssembly(typeof(Program)).GetTypes();

// Get only the types for the classes that inherit from the ISolutionDayService
IEnumerable<Type> solutionDayServiceTypes = assemblyTypes.Where(x => !x.IsInterface && x.GetInterface(nameof(ISolutionDayService)) != null);

// Register each Solution Day Service class
foreach (Type solutionDayServiceType in solutionDayServiceTypes)
{
    builder.Services.AddScoped(solutionDayServiceType.GetInterface(nameof(ISolutionDayService)), solutionDayServiceType);
}
#endregion

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();