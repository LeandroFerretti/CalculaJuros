using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CalculaJuros.Controllers
{
    [ApiController]
    public class DiretoriosController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DiretoriosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("busca-caminho-projeto-git")]
        public ActionResult<string[]> BuscarCaminhoDoProjetoNoGit()
        {
            return _configuration.GetSection("UrlsGihHub").Get<string[]>();
        }
    }
}