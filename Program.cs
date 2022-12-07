using AdventOfCode.Controllers;
using AdventOfCode.Services;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdventOfCode", Version = "v1" });
    c.ParameterFilter<ParameterFilter>();
});

builder.Services.AddScoped<ISolutionService, SolutionService>();
builder.Services.AddScoped<IPuzzleHelperService, PuzzleHelperService>();
builder.Services.ConfigureDailyServices();

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