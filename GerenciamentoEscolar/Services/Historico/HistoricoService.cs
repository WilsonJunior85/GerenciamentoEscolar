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




        public HistoricoModel AtualizarNotas(int idHistorico, string campo, string valor)
        {
            try
            {
                var historico = _context.Historicos.Include(m => m.Materia).Include(a => a.Aluno).Where(h => h.Id == idHistorico).FirstOrDefault();

                if (historico == null)
                {
                    return null;
                }

                switch (campo)
                {
                    case "Nota1": historico.Nota1 = double.Parse(valor);
                        break;
                    case "Nota2":
                        historico.Nota2 = double.Parse(valor);
                        break;
                    case "Nota3":
                        historico.Nota3 = double.Parse(valor);
                        break;
                    case "Nota4":
                        historico.Nota4 = double.Parse(valor);
                        break;
                }

                historico.Media = (historico.Nota1 + historico.Nota2 + historico.Nota3 + historico.Nota4) / 4;

                _context.SaveChanges();

                return historico;
            }
            catch
            {
                return null;
            }
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

        public HistoricoModel RemoverNota(int idHistorico)
        {
            try
            {
                var historico = _context.Historicos.Find(idHistorico); // O Find também faz uma busca no banco de dados pela chave primária da entidade.
                _context.Remove(historico);
                _context.SaveChanges();
                return historico;
            }
            catch
            {
                return null;
            }
        }
    }
}
