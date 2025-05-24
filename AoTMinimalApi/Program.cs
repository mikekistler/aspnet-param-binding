using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseStatusCodePages();

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

[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(int?))]
[JsonSerializable(typeof(string))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
