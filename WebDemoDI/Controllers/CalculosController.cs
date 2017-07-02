using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebDemoDI.Controllers
{
    [Route("api/[controller]")]
    public class CalculosController : Controller
    {
        private ICalculo calculo;
        private IServiceProvider serviceProvider;

        public CalculosController(ICalculo calculo, IServiceProvider serviceProvider)
        {
            this.calculo = calculo;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet("{a}/{b}")]
        public double Get(double a, double b) => calculo.Calcular(a, b);

        [HttpGet]
        public double Get()
        {
            ICalculo soma = serviceProvider.GetService<ICalculo>();
            return soma.Calcular(100, 200);
        }
    }
}
