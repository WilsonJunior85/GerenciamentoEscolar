using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEscolar.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatoria")]
        public string Descricao { get; set; }

        public string Modalidade { get; set; }


        public string Turno { get; set; }




        //Relacionamento entre tabelas
        public List<ProfessorModel>? Professores { get; set; }
        public List<AlunoModel>? Alunos { get; set; }

    }
}
