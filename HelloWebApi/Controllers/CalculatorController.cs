using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //private readonly ILogger<CalculatorController> _logger;

        //public CalculatorController(ILogger<CalculatorController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet("")]

        public IActionResult Calculate(double a, double b, string operation)
        {
            double result;

            switch (operation)
            {
                case "sum":
                    result = a + b;
                    break;
                case "difference":
                    result = a - b;
                    break;
                case "product":
                    result = a * b;
                    break;
                case "quotient":
                    if (b == 0) return BadRequest("Cannot divide by zero");
                    result = a / b;
                    break;
                default:
                    return BadRequest("Invalid operation. Pls use the above calculation");
            }
            return Ok(new {a, b, operation, result});
        }
    }
}
