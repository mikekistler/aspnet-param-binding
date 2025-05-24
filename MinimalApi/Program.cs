using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseStatusCodePages();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/value", (
    int param
) =>
{
    return TypedResults.Ok($"param is {param}");
});

app.MapGet("/value-required", (
    [Required] int param
) =>
{
    return TypedResults.Ok($"param is {param}");
});

app.MapGet("/value-nullable", (
    int? param
) =>
{
    return TypedResults.Ok($"param is {(param is null ? "null" : param)}");
});

app.MapGet("/value-nullable-required", (
    [Required] int? param
) =>
{
    return TypedResults.Ok($"param is {(param is null ? "null" : param)}");
});

app.MapGet("/ref", (
    string param
) =>
{
    return TypedResults.Ok($"param is {(param is null ? "null" : param)}");
});

app.MapGet("/ref-required", (
    [Required] string param
) =>
{
    return TypedResults.Ok($"param is {(param is null ? "null" : param)}");
});

app.MapGet("/ref-nullable", (
    string? param
) =>
{
    return TypedResults.Ok($"param is {(param is null ? "null" : param)}");
});

app.MapGet("/ref-nullable-required", (
    [Required] string? param
) =>
{
    return TypedResults.Ok($"param is {(param is null ? "null" : param)}");
});

app.Run();
