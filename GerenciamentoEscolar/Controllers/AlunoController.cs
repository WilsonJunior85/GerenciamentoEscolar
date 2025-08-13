using GerenciamentoEscolar.Models;
using GerenciamentoEscolar.Services.Aluno;
using GerenciamentoEscolar.Services.Turma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GerenciamentoEscolar.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoInterface _alunoInterface;
        private readonly ITurmaInterface _turmaInterface;

        public AlunoController(IAlunoInterface alunoInterface, ITurmaInterface turmaInterface)
        {
            _alunoInterface = alunoInterface;
            _turmaInterface = turmaInterface;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ListarAlunos()
        {
            var alunos = _alunoInterface.BuscarAlunos();
            return View(alunos);
        }


        [HttpGet]
        public IActionResult CadastrarAlunos()
        {
            BuscarTurmas();
            return View();
        }


        [HttpGet]
        [Route("/Aluno/BuscarAlunoPorMatricula")]
        public IActionResult BuscarAlunoPorMatricula(int matricula)
        {
            var aluno = _alunoInterface.BuscarAlunoPorMaricula(matricula);
            return Json(new {dados = aluno});
        }


        [HttpGet]
        [Route("/Aluno/AlunosDaTurma/{idTurma}")]
        public IActionResult AlunosDaTurma(int idTurma)
        {
            var alunos = _alunoInterface.BuscarAlunosPorTurma(idTurma);
            return Json(new {dados = alunos});
        }

        [HttpPost]
        public IActionResult CadastrarAlunos(AlunoModel alunoModel)
        {
            if (ModelState.IsValid)
            {
                var aluno = _alunoInterface.CadastrarAlunos(alunoModel);

                if (aluno == null)
                {
                    TempData["MensagemErro"] = "Ocorreu um erro na operação!";
                    BuscarTurmas();
                    return View(alunoModel);
                }

                
                TempData["MensagemSucesso"] = "Aluno cadastrado com sucesso!";
                return RedirectToAction("ListarAlunos");

            }
            else
            {
                TempData["MensagemErro"] = "Campos obrigatórios não foram preenchidos!";
                BuscarTurmas();
                return View(alunoModel);
            }
        }



        private void BuscarTurmas()
        {
            var turmas = _turmaInterface.BuscarTurma();
            var listaTurma = new SelectList(turmas, "Id", "Descricao");

            ViewBag.Turmas = listaTurma;
        }
    }
}
