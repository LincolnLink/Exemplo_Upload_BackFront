namespace ProjetoGpt.Interface
{
    public interface IProjetoDto
    {
        string NomeProjeto { get; set; }
        DateTime DataValidade { get; set; }
        IFormFile ArquivoExcel { get; set; }
        string NomeExcel { get; set; }
    }
}
