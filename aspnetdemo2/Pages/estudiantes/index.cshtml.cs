using aspnetDemo2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic; 

namespace aspnetdemo2.Pages.estudiantes;


public class IndexModel : PageModel
{
    public List<EstudiantesEnListaModel> EstudiantesEnLista {get; set;}
    private readonly ILogger<IndexModel> _logger;
    private EstudiantesRepository repo;
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        repo = new EstudiantesRepository();
        

    }

    public void OnGet()
    {
        var modelo = repo.GetEstudiantes();
        EstudiantesEnLista = modelo.Select(e => 
        new EstudiantesEnListaModel()
        {
            NumeroControl = e.NumeroControl,
            Nombre = e.Nombre,
            Carrera = e.Carrera
        }
       
        ).ToList();
    //    EstudiantesEnLista = new List<EstudiantesEnListaModel>();
    //    EstudiantesEnLista.Add(new EstudiantesEnListaModel(){NumeroControl = "123456", Nombre = "Juan Perez", Carrera = "Sistemas"});
    //    EstudiantesEnLista.Add(new EstudiantesEnListaModel(){NumeroControl = "123457", Nombre = "Maria Lopez", Carrera = "Sistemas"});
    
    }


    public class EstudiantesEnListaModel{
        public string NumeroControl {get; set;}

        public string Nombre {get; set;}

        public string Carrera {get; set;}

    }
}