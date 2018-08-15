using Microsoft.AspNetCore.Mvc;
using static funclib.Core;

namespace CalculatorService.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        [HttpGet("add/{a}/{b}")]
        public long Add(int a, int b) => (long)Time(() => Plus(a, b));

        [HttpGet("add/{a}/{b}/{c}")]
        public long Add(int a, int b, int c) => (long)Time(() => Plus(a, b, c));

        [HttpGet("subtract/{a}/{b}")]
        public long Subtract(int a, int b) => (long)Time(() => Minus(a, b));

        [HttpGet("subtract/{a}/{b}/{c}")]
        public long Subtract(int a, int b, int c) => (long)Time(() => Minus(a, b, c));

        [HttpGet("multiply/{a}/{b}")]
        public long Multiply(int a, int b) => (long)Time(() => Multiply(a, b));

        [HttpGet("multiply/{a}/{b}/{c}")]
        public long Multiply(int a, int b, int c) => (long)Time(() => Multiply(a, b, c));

        [HttpGet("divide/{a}/{b}")]
        public double Divide(double a, double b) => (double)Time(() => Divide(a, b));

        [HttpGet("divide/{a}/{b}/{c}")]
        public double Divide(double a, double b, double c) => (double)Time(() => Divide(a, b, c));

    }
}
