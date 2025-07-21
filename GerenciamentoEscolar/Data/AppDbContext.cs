using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEscolar.Data
{
    public class AppDbContext: DbContext
    {



        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

    }
}
