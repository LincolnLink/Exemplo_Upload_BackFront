using Microsoft.Extensions.Hosting;
using ProjetoGpt.Interface;

namespace ProjetoGpt.Services
{
    public class ProjetoService : IProjetoService
    {
        //private readonly IProjetoRepository _projetoRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProjetoService(
            //IProjetoRepository projetoRepository,
            IWebHostEnvironment hostEnvironment
            )
        {
            //_projetoRepository = projetoRepository;
            _hostEnvironment = hostEnvironment;
        }

        public void ProcessarProjeto(IProjetoDto projetoDto)
        {
            // Implemente a lógica de processamento aqui, incluindo a validação do arquivo Excel
            // Salve os dados no banco de dados Oracle usando o repositório

            // Salvar o arquivo no servidor
            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + projetoDto.ArquivoExcel.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                projetoDto.ArquivoExcel.CopyTo(stream);
            }
        }

    }
}
