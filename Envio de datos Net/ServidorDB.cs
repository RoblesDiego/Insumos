using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SaveToMySQL
{
     public class ServidorDB
    {

         public static string CADENACONEXION = "server=127.0.0.1; user id=root; password=holamundo23; database=insumosbolivia; pooling=false; port=3306; convert zero datetime=True;";
        MySqlConnection conexion;

        public bool conectarDB()
        {
            try
            {
                conexion = new MySqlConnection();
                conexion.ConnectionString = ServidorDB.CADENACONEXION;
                conexion.Open();
                conectado = true;
                return true;
            }
            catch (Exception e)
            {
                conectado = false;
                return false;
            }
        }

        public bool cerrarDB()
        {
            conexion.Close();
            conectado = false;
            return true;
        }

        public static bool insertar(string comandoSQL)
        {
            using (var con = new MySqlConnection())
            {
                con.ConnectionString = ServidorDB.CADENACONEXION;
                con.Open();
                using (MySqlCommand com = con.CreateCommand())
                {
                    com.CommandText = comandoSQL;
                    int retorno = com.ExecuteNonQuery();
                    if (retorno >= 0)
                    {
                        con.Close();
                        return true;
                    }
                }
                con.Close();
            }
            return false;
        }

        public static int obtenerId(string comandoSQL, string columna)
        {
            using (var con = new MySqlConnection())
            {
                con.ConnectionString = ServidorDB.CADENACONEXION;
                con.Open();
                using (MySqlCommand com = con.CreateCommand())
                {
                    com.CommandText = comandoSQL;
                    using (MySqlDataReader lector = com.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            int total = Int32.Parse(lector[columna].ToString());
                            return total;
                        }
                    }
                }
                con.Close();
            }
            return -1;
        }

        internal static DataTable listar(string comandoSQL)
        {
            DataTable tabla = new DataTable();
            using (var con = new MySqlConnection())
            {
                con.ConnectionString = ServidorDB.CADENACONEXION;
                con.Open();
                using (MySqlCommand com = con.CreateCommand())
                {
                    com.CommandText = comandoSQL;
                    using (MySqlDataAdapter datos = new MySqlDataAdapter(com))
                    {
                        datos.Fill(tabla);
                    }
                }
                con.Close();
            }
            return tabla;
        }

        public bool conectado { get; set; }
    }

}
