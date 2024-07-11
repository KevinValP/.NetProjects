

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace PrimerAPI.DAL
{
    public class Cliente
    {
        string conexionString = "Data Source=Practicante-Des;Initial Catalog=BDClientes;user=sa;password=Kevvun127";

        public DataTable ListarClientes()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(conexionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTES", con);
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
                con.Close();
                return dt;
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListarClientePorId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTES WHERE ID = @ID", con);
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                    }
                    con.Close();
                }
                return dt;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public Models.Cliente Guardar(Models.Cliente cliente)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(conexionString))
                {
                    con.Open();
                    string query = @"insert Clientes values (@id, @nombre, @edad, @correo)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("id", cliente.Id);
                    cmd.Parameters.AddWithValue("nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("edad", cliente.Edad);
                    cmd.Parameters.AddWithValue("correo", cliente.Correo);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                
                return cliente;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
