using aspnetDemo2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic; 

namespace aspnetdemo2.Pages.estudiantes;


public class CrearModel : PageModel
{
    [BindProperty]
    public CrearEstudianteModel NuevoEstudiante {get;set;}
    private readonly ILogger<CrearModel> _logger;
    private EstudiantesRepository repo;
    public CrearModel(ILogger<CrearModel> logger)
    {
        _logger = logger;
        repo = new EstudiantesRepository();
        

    }

    public void OnGet()
    {
        //Todo
    }

    public void OnPost()
    {
        //todo
    }

    public class CrearEstudianteModel{
        public string NumeroControl {get; set;}

        public string Nombre {get; set;}

        public string Carrera {get; set;}

        public float Promedio {get; set;}

    }
}