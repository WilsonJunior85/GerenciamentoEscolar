using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GerenciamentoEscolar.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }

        public int Matricula { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        public string? Email { get; set; }
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        public DateTime? DataNascimento { get; set; }


        //Relacionamento entre tabelas
        [Required(ErrorMessage = "A turma é obrigatória")]
        public int TurmaId { get; set; }
        [JsonIgnore]
        public TurmaModel? Turma { get; set; }
    }
}
