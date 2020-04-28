using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;


namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> listado = new List<Categoria>();
            /// CREAR UN PAR DE COSAS PARA USAR LA BASE DE DATOS objetos
            SqlConnection conexion = new SqlConnection(); /// a donde me conecto para realizar la consulta
            SqlCommand comando = new SqlCommand(); // Comando 
            SqlDataReader lector;/// lector de mapa sql
            try
            {
                // Le digo a donde conectarme  conexion sql(agregar una barra), cual es el catalogo NOMBRE DE LA BASE DE DATOS, CONEXION( esta x ser desde la conexion local, seguridad integrada)
                conexion.ConnectionString = "data source= Maite-R-Rodas\\SQLEXPRESS; initial catalog=CATALOGO_DB;integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Id,Descripcion from CATEGORIAS"; // si agrego el asterisco me trae todo
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IDCategoria = lector.GetInt32(0);
                    aux.DescripcionCategoria = lector.GetString(1);

                    listado.Add(aux);

                }

                return listado;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Categoria ObtenePorID(int ID)
        {
            Categoria categoria = new Categoria();
            SqlConnection conexion = new SqlConnection(); /// a donde me conecto para realizar la consulta
            SqlCommand comando = new SqlCommand(); // Comando 
            SqlDataReader lector;/// lector de mapa sql
            // Le digo a donde conectarme  conexion sql(agregar una barra), cual es el catalogo NOMBRE DE LA BASE DE DATOS, CONEXION( esta x ser desde la conexion local, seguridad integrada)
            try
            {
                conexion.ConnectionString = "data source= Maite-R-Rodas\\SQLEXPRESS; initial catalog=CATALOGO_DB;integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Id,Descripcion from CATEGORIAS where Id=" + ID.ToString();
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    
                    categoria.IDCategoria = lector.GetInt32(0);
                    categoria.DescripcionCategoria = lector.GetString(1);
                    
                }
                return categoria;

            }
            catch (Exception ex)
            {
                throw ex ;
            }

        }
    }
}
