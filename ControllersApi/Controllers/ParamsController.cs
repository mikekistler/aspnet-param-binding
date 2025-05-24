using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ControllersApi.Controllers;

[ApiController]
public class ParamsController : ControllerBase
{
    private readonly ILogger<ParamsController> _logger;

    public ParamsController(ILogger<ParamsController> logger)
    {
        _logger = logger;
    }

   [HttpGet("value")]
    public string ValueParam(int param)
    {
        return $"param is {param}";
    }

    [HttpGet("value-required")]
    public string ValueRequiredParam([Required] int param)
    {
        return $"param is {param}";
    }

    [HttpGet("value-nullable")]
    public string ValueNullableParam(int? param)
    {
        return $"param is {(param is null ? "null" : param)}";
    }

    [HttpGet("value-nullable-required")]
    public string ValueNullableRequiredParam([Required] int? param)
    {
        return $"param is {(param is null ? "null" : param)}";
    }

    [HttpGet("ref")]
    public string RefParam(string param)
    {
        return $"param is {param}";
    }

    [HttpGet("ref-required")]
    public string RefRequiredParam([Required] string param)
    {
        return $"param is {param}";
    }

    [HttpGet("ref-nullable")]
    public string RefNullableParam(string? param)
    {
        return $"param is {(param is null ? "null" : param)}";
    }

    [HttpGet("ref-nullable-required")]
    public string RefNullableRequiredParam([Required] string? param)
    {
        return $"param is {(param is null ? "null" : param)}";
    }
}
