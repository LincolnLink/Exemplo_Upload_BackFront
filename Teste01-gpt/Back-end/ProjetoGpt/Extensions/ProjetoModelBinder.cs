using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProjetoGpt.ViewModels;
using System.Text.Json;

namespace ProjetoGpt.Extensions
{
    public class ProjetoModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true
            };

            var produtoImagemViewModel = JsonSerializer.Deserialize<ProjetoViewModel>(bindingContext.ValueProvider.GetValue("projeto").FirstOrDefault(), serializeOptions);
            produtoImagemViewModel.ArquivoExcel = bindingContext.ActionContext.HttpContext.Request.Form.Files.FirstOrDefault();

            bindingContext.Result = ModelBindingResult.Success(produtoImagemViewModel);
            return Task.CompletedTask;
        }
    }
}
