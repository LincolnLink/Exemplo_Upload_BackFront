using ProjetoGpt.model;

namespace ProjetoGpt.Interface
{
    public interface IProjetoRepository
    {
        void AdicionarProjeto(Projeto projeto);
        void AtualizarProjeto(Projeto projeto);
        void RemoverProjeto(Guid id);
        Projeto ObterProjetoPorId(Guid id);
        IEnumerable<Projeto> ObterTodosProjetos();
        // Adicione outras operações do repositório aqui
    }
}
