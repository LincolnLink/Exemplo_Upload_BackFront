using ProjetoGpt.Interface;
using ProjetoGpt.model;

namespace ProjetoGpt.Data
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly MeuDbContext _context;

        public ProjetoRepository(MeuDbContext context)
        {
            _context = context;
        }

        public void AdicionarProjeto(Projeto projeto)
        {
            throw new NotImplementedException();
        }

        public void AtualizarProjeto(Projeto projeto)
        {
            throw new NotImplementedException();
        }

        public Projeto ObterProjetoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Projeto> ObterTodosProjetos()
        {
            throw new NotImplementedException();
        }

        public void RemoverProjeto(Guid id)
        {
            throw new NotImplementedException();
        }

        // Implemente os métodos do CRUD aqui
    }

    public class MeuDbContext
    {
        // Implemente o contexto do banco de dados Oracle aqui
    }
}
