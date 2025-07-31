using GerenciamentoEscolar.Dto.Professor;
using GerenciamentoEscolar.Models;

namespace GerenciamentoEscolar.Services.Professor
{
    public interface IProfessorInterface
    {

        List<ProfessorModel> BurcarProfessores();

        ProfessorModel ObterProfessorComTurmaseAlunos(int id);

        ProfessorModel CadastrarProfessorModel(ProfessorCriacaoDto professorCriacaoDto);

        List<ProfessorModel> BurcarProfessoresPorTurma(int idTurma);
    }
}
