using aspnetDemo2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;

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

    public IActionResult OnPost()
    {
        if(!ModelState.IsValid){
            return Page();
        }

        repo.CrearEstudiante(new Estudiante(){
            NumeroControl = NuevoEstudiante.NumeroControl,
            Nombre = NuevoEstudiante.Nombre,
            Carrera = NuevoEstudiante.Carrera,
            Promedio = NuevoEstudiante.Promedio
        });

        return RedirectToPage("./Index");
    }

    public class CrearEstudianteModel{
        [Required, StringLength(8)]
        public string NumeroControl {get; set;}
        
        [Required, StringLength(50)]
        public string Nombre {get; set;}

        public string Carrera {get; set;}

        public float Promedio {get; set;}

    }
}