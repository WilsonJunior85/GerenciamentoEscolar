using GerenciamentoEscolar.Data;
using GerenciamentoEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEscolar.Services.Professor
{
    public class ProfessorService : IProfessorInterface
    {
        private readonly AppDbContext _context;

        public ProfessorService(AppDbContext context)
        {
            _context = context;
        }




        public List<ProfessorModel> BurcarProfessores()
        {
            try
            {
                var professores = _context.Professores.Include(m => m.Materia).Include(t => t.Turmas).ToList();

                return professores;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public ProfessorModel ObterProfessorComTurmaseAlunos(int id)
        {
            try
            {
                var professorTurmaAluno = _context.Professores
                                                  .Where(p => p.Id == id)
                                                  .Include(t => t.Turmas)
                                                  .ThenInclude(a => a.Alunos)
                                                  .FirstOrDefault();

                return professorTurmaAluno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
