using GerenciamentoEscolar.Services.Historico;
using GerenciamentoEscolar.Services.Materia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GerenciamentoEscolar.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly IHistoricoInterface _historicoInterface;
        private readonly IMateriaInterface _materiaInterface;

        public HistoricoController(IHistoricoInterface historicoInterface, IMateriaInterface materiaInterface)
        {
            _historicoInterface = historicoInterface;
            _materiaInterface = materiaInterface;
        }


        [HttpGet()]
        [Route("/Historico/GerarHistorico/{idAluno}")]
        public IActionResult GerarHistorico(int idAluno)
        {
            var historicos = _historicoInterface.GerarHistorico(idAluno);

            if (historicos.Count == 0)
            {
                TempData["MensagemErro"] = "Não existem notas lançadas para esse aluno!";
                return RedirectToAction("ListarAlunos", "Aluno");
            }


            if (historicos == null)
            {
                TempData["MensagemErro"] = "Ocorreu um erro na operação!";
                return RedirectToAction("ListarAlunos", "Aluno");
            }

            return View(historicos);
        }


        [HttpGet()]
        public IActionResult BuscarNotas()
        {
            var notas = _historicoInterface.BuscarNotas();
            BuscarMaterias();
            return View(notas);
        }

        [HttpPost()]
        [Route("/Historico/AtualizarNotas")]
        public IActionResult AtualizarNotas(int idHistorico, string campo, string valor)
        {
            var historico = _historicoInterface.AtualizarNotas(idHistorico, campo, valor);
            if (historico == null)
            {
                return Json(new { resultado = false});
            }
                return Json(new { resultado = true, media = historico.Media}); 
        }


        private void BuscarMaterias()
        {
            var materias = _materiaInterface.BuscarMaterias();
            var listaMateria = new SelectList(materias, "Id", "Descricao");
            ViewBag.Materias = listaMateria;
        }

    }
}
