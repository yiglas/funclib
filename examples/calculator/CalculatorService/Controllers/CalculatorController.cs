using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static funclib.Core;
using Microsoft.AspNetCore.Mvc;
using funclib.Components.Core;

namespace CalculatorService.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        [HttpGet("add/{a}/{b}")]
        public long Add(int a, int b) => (long)time(() => plus(a, b)); //(long)new Time(() => new Plus().Invoke(a, b)).Invoke();

        [HttpGet("add/{a}/{b}/{c}")]
        public long Add(int a, int b, int c) => (long)time(() => plus(a, b, c));  //(long)new Time(() => new Plus().Invoke(a, b, c)).Invoke();

        [HttpGet("subtract/{a}/{b}")]
        public long Subtract(int a, int b) => (long)new Time(() => new Minus().Invoke(a, b)).Invoke();

        [HttpGet("subtract/{a}/{b}/{c}")]
        public long Subtract(int a, int b, int c) => (long)new Time(() => new Minus().Invoke(a, b, c)).Invoke();

        [HttpGet("multiply/{a}/{b}")]
        public long Multiply(int a, int b) => (long)new Time(() => new Multiply().Invoke(a, b)).Invoke();

        [HttpGet("multiply/{a}/{b}/{c}")]
        public long Multiply(int a, int b, int c) => (long)new Time(() => new Multiply().Invoke(a, b, c)).Invoke();

        [HttpGet("divide/{a}/{b}")]
        public double Divide(double a, double b) => (double)new Time(() => new Divide().Invoke(a, b)).Invoke();

        [HttpGet("divide/{a}/{b}/{c}")]
        public double Divide(double a, double b, double c) => (double)new Time(() => new Divide().Invoke(a, b, c)).Invoke();

    }
}
