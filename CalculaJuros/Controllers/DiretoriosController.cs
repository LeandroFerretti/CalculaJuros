using Microsoft.AspNetCore.Mvc;

namespace CalculaJuros.Controllers
{
    [ApiController]
    public class DiretoriosController : ControllerBase
    {
        public DiretoriosController()
        {
        }

        [HttpGet("busca-caminho-projeto-git")]
        public ActionResult<string[]> BuscarCaminhoDoProjetoNoGit()
        {
            string[] urls = {
                "Url do git projeto TaxaJuros: https://github.com/LeandroFerretti/TaxaJuros",
                "Url do git projeto CalculaJuros: https://github.com/LeandroFerretti/CalculaJuros"
            };
            return urls;
        }
    }
}