using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Formulario_simple.DataAccess
{
    internal class Conexion
    {
        public bool IntentoConexion(string cadenaDeConexion)
        {
            try
            {
                // Al terminar el uso de la conxion la cerrara
                using (var conexion = new MySqlConnection(cadenaDeConexion))
                {
                    conexion.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable ObtenerDatos(string cadenaDeConexion)
        {
            DataTable dt = new DataTable();
            try
            {
                // Al terminar el uso de la conxion la cerrara
                using (var conexion = new MySqlConnection(cadenaDeConexion))
                {
                    conexion.Open();

                    string query = "SELECT * FROM CatPersonal";
                    using (var comando = new MySqlCommand(query, conexion))
                    using (var adapter = new MySqlDataAdapter(comando))
                    {
                        adapter.Fill(dt);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la informacion" + ex.Message);
            }

            return dt;
        }
    }
}
