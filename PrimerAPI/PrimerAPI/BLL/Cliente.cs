

using System.Data;

namespace PrimerAPI.BLL
{
    public class Cliente
    {
        public List<Models.Cliente> listarClientes()
        {
            List<Models.Cliente> lstClientes = new List<Models.Cliente>();
            foreach(DataRow Row in new DAL.Cliente().ListarClientes().Rows)
            {
                Models.Cliente cliente = new Models.Cliente();
                cliente.Id = Convert.ToInt32(Row["Id"]);
                cliente.Nombre = Row["Nombre"].ToString();
                cliente.Edad = Row["Edad"].ToString();
                cliente.Correo = Row["Correo"].ToString();
                lstClientes.Add(cliente);
            }
            return lstClientes;
        }

        public int GuardarCliente(Models.Cliente cliente)
        {
            int cli = new DAL.Cliente().Guardar(cliente);
            return cli;
        }

        public Models.Cliente listarClientePorId(int id)
        {
            Models.Cliente cli = new Models.Cliente();
            DataRow row = new DAL.Cliente().ListarClientePorId(id).Rows[0];
            cli.Id = Convert.ToInt32(row["Id"]);
            cli.Nombre = row["Nombre"].ToString();
            cli.Edad = row["Edad"].ToString();
            cli.Correo = row["Correo"].ToString();
            return cli;
        }
    }

}