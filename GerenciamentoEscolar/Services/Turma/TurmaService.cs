using GerenciamentoEscolar.Data;
using GerenciamentoEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEscolar.Services.Turma
{
    public class TurmaService : ITurmaInterface
    {
        private readonly AppDbContext _context;

        public TurmaService(AppDbContext context)
        {
            _context = context;
        }




        public List<TurmaModel> BuscarTurma()
        {

            try
            {
                var turmas = _context.Turmas.Include(a => a.Alunos).Include(p => p.Professores).ToList();
                return turmas;
            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        }
    }
}
