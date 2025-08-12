using GerenciamentoEscolar.Data;
using GerenciamentoEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEscolar.Services.Historico
{

    public class HistoricoService : IHistoricoInterface
    {
        private readonly AppDbContext _context;

        public HistoricoService(AppDbContext context)
        {
            _context = context;
        }




        public List<HistoricoModel> BuscarNotas()
        {
            try
            {
                var buscarNotas = _context.Historicos.Include(a => a.Aluno).Include(m => m.Materia).ToList();
                return buscarNotas;
            }
            catch
            {
                return null;
            }
        }



        public List<HistoricoModel> GerarHistorico(int idAluno)
        {
            try
            {
                var historios = _context.Historicos.Include(m => m.Materia).Include(a => a.Aluno).ThenInclude(t => t.Turma).Where(h => h.AlunoId == idAluno).ToList();
                return historios;
            }
            catch
            {
                return null;
            }
        }
    }
}
