using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Security.Permissions;

namespace Negocio
{
    public class AccesoDatos
    {
        public SqlDataReader lector { get; set; }
    
        public SqlConnection conexion { get; set; }
        public SqlCommand comando { get; set; }

         public AccesoDatos()
        {
            /// este constructor me genera las instancias
            conexion = new SqlConnection("data source= Maite-R-Rodas\\SQLEXPRESS; initial catalog=CATALOGO_DB;integrated security=sspi;");
            comando = new SqlCommand();
            comando.Connection = conexion;

        }

        public void  SetearQuery( string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

         public void SetearSP( string sp)
        {

        }

         public void AgregarParametro( string nombre, String valor)
        {

        }

        public void EjecutarLector()
        {
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void CerrarConexion()
            {
            conexion.Close();

            }
    }


}
