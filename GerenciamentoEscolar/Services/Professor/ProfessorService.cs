using GerenciamentoEscolar.Data;
using GerenciamentoEscolar.Dto.Professor;
using GerenciamentoEscolar.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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



        public List<ProfessorModel> BurcarProfessoresPorTurma(int idTurma)
        {
            try
            {
                var professoresDaTurma = _context.Turmas  // Entrei no banco de dados e depois entrei na tabela de turmas
                                        .Where(t => t.Id == idTurma) // Peguei todas as turms
                                        .SelectMany(t => t.Professores) //Depois selecionei todos os professores de dentro da turma(idTurma)
                                        .Include(m => m.Materia)   //Depois disso eu fiz o inclunde da materia
                                        .ToList();       // Depois transformei tudo em uma lista

                return professoresDaTurma;
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public ProfessorModel CadastrarProfessorModel(ProfessorCriacaoDto professorCriacaoDto)
        {
            try
            {
                var turmasSelecionadas = _context.Turmas.Where(t => professorCriacaoDto.TurmasId.Contains(t.Id)).ToList();

                var professorModel = new ProfessorModel
                {
                    Nome = professorCriacaoDto.Nome,
                    Email = professorCriacaoDto.Email,
                    DataContratacao = professorCriacaoDto.DataContratacao,
                    MateriaId = professorCriacaoDto.MateriaId,
                    Turmas = turmasSelecionadas,



                };

                _context.Professores.Add(professorModel);
                _context.SaveChanges();

                return professorModel;
                
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
