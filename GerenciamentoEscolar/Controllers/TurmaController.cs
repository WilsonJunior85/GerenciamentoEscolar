using GerenciamentoEscolar.Models;
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




        [HttpGet]
        public IActionResult ListarTurmas()
        {
            var turmas = _turmaInterface.BuscarTurma();

            return View(turmas);
        }

        [HttpGet]
        public IActionResult CadastrarTurma()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CadastrarTurma(TurmaModel turmaModel)
        {

            if (ModelState.IsValid)
            {
                var turma = _turmaInterface.CadastrarTurmas(turmaModel);
                if (turma == null)
                {
                    TempData["MensagemErro"] = "Nome de turma repetido ou problema no servidor";
                    return View(turmaModel);
                }

                TempData["MensagemSucesso"] = "Cadastro de turma realizado com sucesso!";
                return RedirectToAction("ListarTurmas");
            }
            else
            {
                TempData["MensagemErro"] = "Campos obrigatórios não foram preenchidos!";
                return View(turmaModel);
            }

                
        }
    }
}
