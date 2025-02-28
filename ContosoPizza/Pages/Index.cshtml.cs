using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoPizza.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}

// https://learn.microsoft.com/en-us/training/modules/create-razor-pages-aspnet-core

// agregrar una nueva pagina razor:
// dotnet new page --name PizzaList --namespace ContosoPizza.Pages --output Pages

// dotnet watch y presione Ctrl+R para volver a cargar la aplicación 
// con el servicio registrado y el nuevo constructor para PizzaListModel
