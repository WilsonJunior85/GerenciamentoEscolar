using GerenciamentoEscolar.Dto.Professor;
using GerenciamentoEscolar.Services.Materia;
using GerenciamentoEscolar.Services.Professor;
using GerenciamentoEscolar.Services.Turma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GerenciamentoEscolar.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorInterface _professorInterface;
        private readonly ITurmaInterface _turmaInterface;
        private readonly IMateriaInterface _materiaInterface;

        public ProfessorController(IProfessorInterface professorInterface, ITurmaInterface turmaInterface, IMateriaInterface materiaInterface)
        {
            _professorInterface = professorInterface;
            _turmaInterface = turmaInterface;
            _materiaInterface = materiaInterface;
        }


        [HttpGet]
        public IActionResult ListarProfessor()
        {
            var professores = _professorInterface.BurcarProfessores();
            return View(professores);
        }


        [HttpGet("{id}")]
        public IActionResult DetalhesProfessor(int id)
        {
            var professores = _professorInterface.ObterProfessorComTurmaseAlunos(id);
            return View(professores);
        }


        [HttpGet]
        public IActionResult CadastrarProfessor()
        {
            BuscarMaterias();
            BuscarTurmas();
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarProfessor(ProfessorCriacaoDto professorCriacaoDto)
        {

            if (ModelState.IsValid)
            {
                var professorModel = _professorInterface.CadastrarProfessorModel(professorCriacaoDto);
                if (professorModel == null)
                {
                    TempData["MensagemErro"] = "Ocorreu um erro na operação!";
                    BuscarMaterias();
                    BuscarTurmas();
                    return View(professorCriacaoDto);
                }

                TempData["MensagemSucesso"] = "Professor cadastrado com sucesso!";
                return RedirectToAction("ListarProfessor");
            }
            else
            {
                TempData["MensagemErro"] = "Campos obrigatórios não preenchidos!";
                BuscarMaterias();
                BuscarTurmas();
                return View(professorCriacaoDto);
            }

                return View();
        }


        private void BuscarTurmas()
        {
            var turmas = _turmaInterface.BuscarTurma();

            var listaTurma = new SelectList(turmas, "Id", "Descricao");

            ViewBag.Turmas = listaTurma;
        }


        private void BuscarMaterias()
        {
            var materias  = _materiaInterface.BuscarMaterias();

            var listaMaterias = new SelectList(materias, "Id", "Descricao");

            ViewBag.Materias = listaMaterias;
        }



    }
}
