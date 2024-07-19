

namespace aspnetDemo2
{
    public class EstudiantesRepository{
    private static List<Estudiante> _estudiantes = new List<Estudiante>();
        static EstudiantesRepository(){
            _estudiantes.Add(new Estudiante(){NumeroControl = "123456", Nombre = "Juan Perez", Carrera = "Sistemas"});
            _estudiantes.Add(new Estudiante(){NumeroControl = "123457", Nombre = "Maria Lopez", Carrera = "Sistemas"});
        }
       
        public List<Estudiante> GetEstudiantes(){
            
            return _estudiantes.Select(e=>e).ToList();
        }

        internal void CrearEstudiante(Estudiante estudiante)
        {
            _estudiantes.Add(estudiante);
        }

        internal Estudiante LeerPorNC(string nc)
        {
            return _estudiantes.FirstOrDefault(e => e.NumeroControl == nc);
        }
    } 

    public class Estudiante{
        public string NumeroControl {get; set;}

        public string Nombre {get; set;}

        public string Carrera {get; set;}

        public float Promedio {get; set;}
    }
}