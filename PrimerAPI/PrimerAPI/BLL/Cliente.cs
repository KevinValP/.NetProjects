

namespace PrimerAPI.BLL
{
    public class Cliente
    {
        public List<Models.Cliente> listarClientes()
        {

            List<Models.Cliente> clientes = new List<Models.Cliente>
            {
                new Models.Cliente
                {
                    Id = 1, Nombre = "Juan", Edad = "25", Correo = "kevinjair810@gmail.com"
                }
            };

            return clientes;


        }

        public Models.Cliente GuardarCliente(Models.Cliente cliente)
        {
            Models.Cliente cli = new Models.Cliente { Id = cliente.Id };
            return cli;
        }

        public Models.Cliente listarClientePorId(int id)
        {
            Models.Cliente cliente = new Models.Cliente { Id = id, Nombre = "Juan", Edad = "23", Correo = "je@gmail.com" };
            return cliente;
        }
    }

}