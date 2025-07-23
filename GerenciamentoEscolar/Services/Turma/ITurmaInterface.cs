using GerenciamentoEscolar.Models;

namespace GerenciamentoEscolar.Services.Turma
{
    public interface ITurmaInterface
    {

        List<TurmaModel> BuscarTurma();

        TurmaModel CadastrarTurmas(TurmaModel turmaModel);
    }
}
