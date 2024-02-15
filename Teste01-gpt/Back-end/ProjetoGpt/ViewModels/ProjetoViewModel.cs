using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoGpt.ViewModels
{
    public class ProjetoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string NomeProjeto { get; set; }

        // Evita o erro de conversão de string vazia para IFormFile
        [JsonIgnore]
        public IFormFile ArquivoExcel { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataValidade { get; set; }

        public string NomeExcel { get; set; }
    }
}
