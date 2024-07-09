using Microsoft.AspNetCore.Mvc;


namespace PrimerAPI.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        [Route("listar")]
        public dynamic ListarCliente()
        {
            List<Models.Cliente> clientes = new List<Models.Cliente>
            {
                new Models.Cliente
                {
                    Id = 1, Nombre = "Juan", Edad = "25", Correo = "kevinjair810@gmail.com"
                },
                new Models.Cliente
                {
                    Id = 2, Nombre = "Pedro", Edad = "30", Correo = "pedro@gmail.com" 
                }

            };
            
           
            //Todo el codigo que se desea
            return clientes;
        }

        [HttpGet]
        [Route("listarid")]
        public dynamic ListarClientePorId(int id)
        {
            List<Models.Cliente> clientes = new List<Models.Cliente>
            {
                new Models.Cliente
                {
                    Id = id, Nombre = "Juan", Edad = "25", Correo = "kevinjair810@gmail.com"
                }

            };


            //Todo el codigo que se desea
            return clientes;
        }


        [HttpPost]
        [Route("guardar")]
        public dynamic GuardarCliente(Models.Cliente cliente)
        {
            cliente.Id = 5;
            return new
            {
                success = true,
                message = "registrado exitosamente",
                result = cliente.ToString()
            };
        }
    }
}
