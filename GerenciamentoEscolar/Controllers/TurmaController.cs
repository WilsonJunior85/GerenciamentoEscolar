using GerenciamentoEscolar.Services.Turma;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEscolar.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaInterface _turmaInterface;

        public TurmaController(ITurmaInterface turmaInterface)
        {
            _turmaInterface = turmaInterface;
        }





        public IActionResult ListarTurmas()
        {
            var turmas = _turmaInterface.BuscarTurma();

            return View();
        }
    }
}
