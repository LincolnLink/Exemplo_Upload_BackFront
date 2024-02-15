using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoGpt.Dto;
using ProjetoGpt.Extensions;
using ProjetoGpt.Interface;
using ProjetoGpt.model;
using ProjetoGpt.ViewModels;

namespace ProjetoGpt.Controllers
{
    [Route("api/projeto")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        //private readonly IProjetoService _projetoService;

        public ProjetoController(
            //IProjetoService projetoService
            )
        {
           // _projetoService = projetoService;
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<ProjetoViewModel>> Adicionar(
            //[FromForm] ProjetoDto projetoDto)
            [ModelBinder(BinderType = typeof(ProjetoModelBinder))]
            ProjetoViewModel projetoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(projetoViewModel.ArquivoExcel, imgPrefixo))
            {
                return BadRequest(new
                {
                    success = false,
                    errors = "Não passou na validação"
                }); ;
            }

            projetoViewModel.NomeExcel = imgPrefixo + projetoViewModel.NomeExcel;
            //await _produtoService.Adicionar(_mapper.Map<Produto>(projetoViewModel));

            //_projetoService.ProcessarProjeto(projetoDto);
            return Ok(new
            {
                success = true,
                data = projetoViewModel
            });
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                //NotificarErro("Forneça uma imagem para este produto!");
                return false;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Arquivos", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                //NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}
