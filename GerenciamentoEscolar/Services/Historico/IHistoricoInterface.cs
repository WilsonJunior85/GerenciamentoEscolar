using GerenciamentoEscolar.Models;

namespace GerenciamentoEscolar.Services.Historico
{
    public interface IHistoricoInterface
    {

        List<HistoricoModel> GerarHistorico(int idAluno);
    
        List<HistoricoModel> BuscarNotas();

    }
}
