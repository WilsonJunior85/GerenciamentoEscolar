﻿using GerenciamentoEscolar.Data;
using GerenciamentoEscolar.Models;

namespace GerenciamentoEscolar.Services.Aluno
{
    public class AlunoService : IAlunoInterface
    {
        private readonly AppDbContext _context;

        public AlunoService(AppDbContext context)
        {
            _context = context;
        }



        public List<AlunoModel> BuscarAlunosPorTurma(int idTurma)
        {
            try
            {
                var alunos = _context.Alunos.Where(a => a.TurmaId == idTurma).ToList();
                return alunos;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
