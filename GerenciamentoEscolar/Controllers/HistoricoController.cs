using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEscolar.Controllers
{
    public class HistoricoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
