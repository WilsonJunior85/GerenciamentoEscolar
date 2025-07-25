using GerenciamentoEscolar.Services.Professor;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEscolar.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorInterface _professorInterface;

        public ProfessorController(IProfessorInterface professorInterface)
        {
            _professorInterface = professorInterface;
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
   
            return View();
        }
    }
}
