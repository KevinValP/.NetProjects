using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic; 

namespace aspnetdemo2.Pages.estudiantes;

public class IndexModel : PageModel
{
    public List<EstudiantesEnListaModel> EstudiantesEnLista {get; set;}
    private readonly ILogger<IndexModel> _logger;
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
       EstudiantesEnLista = new List<EstudiantesEnListaModel>();
       EstudiantesEnLista.Add(new EstudiantesEnListaModel(){NumeroControl = "123456", Nombre = "Juan Perez", Carrera = "Sistemas"});
    }


    public class EstudiantesEnListaModel{
        public string NumeroControl {get; set;}

        public string Nombre {get; set;}

        public string Carrera {get; set;}

    }
}