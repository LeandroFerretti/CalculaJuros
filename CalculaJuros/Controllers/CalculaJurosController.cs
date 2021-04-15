using CalculaJuros.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalculaJuros.Controllers
{
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosAppService _service;

        public CalculaJurosController(ICalculaJurosAppService service)
        {
            _service = service;
        }

        [HttpGet("calculaJuros")]
        public IActionResult CalcularJuros(decimal valorInicial, int meses)
        {
            try
            {
                return Ok(_service.CalcularJuros(valorInicial, meses));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}