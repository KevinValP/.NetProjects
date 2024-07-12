

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
                cliente.Estatus = Convert.ToChar(Row["Estatus"]);
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
            if(new DAL.Cliente().ListarClientePorId(id).Rows.Count == 0)
            {
                return null;
            }
            DataRow row = new DAL.Cliente().ListarClientePorId(id).Rows[0];
            cli.Id = Convert.ToInt32(row["Id"]);
            cli.Nombre = row["Nombre"].ToString();
            cli.Edad = row["Edad"].ToString();
            cli.Correo = row["Correo"].ToString();
            cli.Estatus = Convert.ToChar(row["Estatus"]);
            return cli;
        }

        public Models.Cliente ActualizarCliente(Models.Cliente cliente, int id)
        {
            DataTable dtCliente = new DAL.Cliente().ActualizarCliente(cliente, id);
            if(dtCliente.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = dtCliente.Rows[0];
            Models.Cliente cli = new Models.Cliente();
            cli.Id = Convert.ToInt32(row["Id"]);
            cli.Nombre = row["Nombre"].ToString();
            cli.Edad = row["Edad"].ToString();
            cli.Correo = row["Correo"].ToString();
            return cli;
        }

        public string EliminarCliente(int id)
        {
            if (new DAL.Cliente().EliminarCliente(id))
            {
                return "Cliente eliminado";
            }
            else
            {
                return "Cliente no eliminado";
            }
        }

    }

    

}