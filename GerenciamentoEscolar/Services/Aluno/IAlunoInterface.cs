using GerenciamentoEscolar.Models;

namespace GerenciamentoEscolar.Services.Aluno
{
    public interface IAlunoInterface
    {
        List<AlunoModel> BuscarAlunosPorTurma(int idTurma);
    }
}
