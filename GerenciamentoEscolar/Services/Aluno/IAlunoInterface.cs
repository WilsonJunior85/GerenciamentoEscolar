using GerenciamentoEscolar.Dto.Professor;
using GerenciamentoEscolar.Models;

namespace GerenciamentoEscolar.Services.Aluno
{
    public interface IAlunoInterface
    {
        List<AlunoModel> BuscarAlunosPorTurma(int idTurma);
        List<AlunoModel> BuscarAlunos();
        AlunoModel CadastrarAlunos(AlunoModel alunoModel);
    }
}
