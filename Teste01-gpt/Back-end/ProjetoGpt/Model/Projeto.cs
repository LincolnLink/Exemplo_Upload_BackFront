namespace ProjetoGpt.model
{
    public class Projeto
    {
        public Guid Id { get; set; } // ID único do projeto
        public string NomeProjeto { get; set; } // Nome do projeto
        public DateTime DataValidade { get; set; } // Data de validade do projeto
                                                   // Outros campos relacionados ao projeto
        public string NomeArquivoExcel { get; set; } // Nome do arquivo Excel
        public byte[] ArquivoExcel { get; set; } // Conteúdo do arquivo Excel em bytes


        // Construtor padrão
        public Projeto()
        {
            Id = Guid.NewGuid(); // Gere um novo ID único ao criar um projeto
        }
    }
}
