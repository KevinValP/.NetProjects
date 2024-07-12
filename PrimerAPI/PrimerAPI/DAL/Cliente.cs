

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection.Metadata;

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTES where Estatus = 'A'", con);
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
                con.Close();
                
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt; 
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
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
            
        }

        public int Guardar(Models.Cliente cliente)
        {
            int id;
            try
            {
                
                using(SqlConnection con = new SqlConnection(conexionString))
                {
                    con.Open();
                    string query = @"insert Clientes (nombre, edad, correo) output INSERTED.ID values (@nombre, @edad, @correo, 'A')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("edad", cliente.Edad);
                    cmd.Parameters.AddWithValue("correo", cliente.Correo);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    id = (Int32)cmd.ExecuteScalar();
                }
                
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return id;

        }

        public DataTable ActualizarCliente(Models.Cliente cliente, int id)
        {
            DataTable dt = new DataTable();
            try
            {
                using(SqlConnection con = new SqlConnection(conexionString))
                {
                    con.Open();
                    string query = @"UPDATE CLIENTES SET NOMBRE = @NOMBRE, EDAD = @EDAD, CORREO = @CORREO WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("NOMBRE", cliente.Nombre);
                    cmd.Parameters.AddWithValue("EDAD", cliente.Edad);
                    cmd.Parameters.AddWithValue("CORREO", cliente.Correo);
                    cmd.Parameters.AddWithValue("ID", id);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    
                    adp.Fill(dt);
                    
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public bool EliminarCliente(int Id)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(conexionString))
                {
                    con.Open();
                    string query = @"UPDATE CLIENTES SET ESTATUS = 'B' WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("ID", Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }catch(Exception ex)
            {

                return false;
            }
        }
    }
}
