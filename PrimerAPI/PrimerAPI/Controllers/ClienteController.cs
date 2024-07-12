using Microsoft.AspNetCore.Mvc;
using PrimerAPI.Models;


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
            List<Cliente> lstClientes = new BLL.Cliente().listarClientes();
            
           
            //Todo el codigo que se desea
            return lstClientes;
        }

        [HttpGet]
        [Route("listarid")]
        public dynamic ListarClientePorId(int id)
        {
            Cliente cliente = new BLL.Cliente().listarClientePorId(id);
 

            //Todo el codigo que se desea
            return cliente;
        }


        [HttpPost]
        [Route("guardar")]
        public dynamic GuardarCliente(Cliente cliente)
        {
            int cli = new BLL.Cliente().GuardarCliente(cliente);
            return cli;
        }

        [HttpPut]
        [Route("actualizar")]
        public dynamic ActualizarCliente(Cliente cliente, int id)
        {
            Models.Cliente cliente1 = new BLL.Cliente().ActualizarCliente(cliente, id);
            return cliente1;
        }

        [HttpPut]
        [Route("eliminar")]
        public dynamic EliminarCliente(int id)
        {

           string cli = new BLL.Cliente().EliminarCliente(id);
           return cli;
        }
    }
}
