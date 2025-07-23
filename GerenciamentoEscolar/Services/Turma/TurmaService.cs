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

        public TurmaModel CadastrarTurmas(TurmaModel turmaModel)
        {
            try
            {
                if (!VerificaNomeTurma(turmaModel))
                {
                    return null;
                }

                _context.Turmas.Add(turmaModel);
                _context.SaveChanges();
                return turmaModel;
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }


        private bool VerificaNomeTurma(TurmaModel turmaModel)
        {
            var turma = _context.Turmas.FirstOrDefault(turma => turma.Descricao == turmaModel.Descricao);

            if (turma == null)
            {
                return true;
            }
            
            
                return false;
            
        }

    }
}
