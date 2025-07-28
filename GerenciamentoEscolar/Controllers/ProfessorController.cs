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
