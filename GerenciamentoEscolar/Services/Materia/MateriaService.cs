using GerenciamentoEscolar.Data;
using GerenciamentoEscolar.Models;

namespace GerenciamentoEscolar.Services.Materia
{
    public class MateriaService : IMateriaInterface
    {
        private readonly AppDbContext _context;

        public MateriaService(AppDbContext context)
        {
            _context = context;
        }


        public List<MateriaModel> BuscarMaterias()
        {
            try
            {
                var materias = _context.Materias.ToList();
                return materias;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
