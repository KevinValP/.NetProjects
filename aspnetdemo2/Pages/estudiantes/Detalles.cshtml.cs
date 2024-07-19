using aspnetDemo2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;

namespace aspnetdemo2.Pages.estudiantes;


public class DetallesModel : PageModel
{
    [BindProperty]
    public Estudiante Detalle {get;set;}
    private readonly ILogger<CrearModel> _logger;
    private EstudiantesRepository repo;
    public DetallesModel(ILogger<CrearModel> logger)
    {
        _logger = logger;
        repo = new EstudiantesRepository();
        

    }

    public IActionResult OnGet(string nc)
    {
        var estudiante = repo.LeerPorNC(nc);
        if(estudiante == null){
            return NotFound();
        }
        Detalle = estudiante;
        return Page();
    }

   


}