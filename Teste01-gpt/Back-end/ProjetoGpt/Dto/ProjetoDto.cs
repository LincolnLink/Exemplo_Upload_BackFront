using ProjetoGpt.Interface;

namespace ProjetoGpt.Dto
{
    public class ProjetoDto : IProjetoDto
    {
        public string NomeProjeto { get; set; }
        public DateTime DataValidade { get; set; }
        public IFormFile ArquivoExcel { get; set; }
        public string NomeExcel { get; set; }
    }
}
