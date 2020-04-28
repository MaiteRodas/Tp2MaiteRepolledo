using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using Dominio;
using System.Data.OleDb;
// Esta es la clase que va a consultar la informacion
namespace Negocio
{
	public class ArticuloNegocio
	{

		public List<Articulo> Listar()
		{
			List<Articulo> listado = new List<Articulo>();
			SqlConnection conexion = new SqlConnection(); /// para la conexion
			SqlCommand comando = new SqlCommand(); /// comando
			SqlDataReader lector; /// mapa sql

			try
			{
			/// donde te conectas El servidor, la base de datos donde me conecto, tipo de conexion" conexion integrada
				conexion.ConnectionString = "data source= Maite-R-Rodas\\SQLEXPRESS; initial catalog=CATALOGO_DB;integrated security=sspi;";
				comando.CommandType = System.Data.CommandType.Text; // le digo que tipo de texto es
				comando.CommandText = "select A.Id,Codigo,Nombre,A.Descripcion,ImagenURL,Precio, M.Id, M.Descripcion, C.Id, C.Descripcion from ARTICULOS as A, MARCAS as M, CATEGORIAS as C where A.IdMarca = M.Id and A.IdCategoria = C.Id";
				comando.Parameters.Clear();
				comando.Connection = conexion;
				conexion.Open();
				lector = comando.ExecuteReader();

				while (lector.Read())
				{

					Articulo aux = new Articulo();
					aux.IdArticulo = lector.GetInt32(0);
					aux.CodigoArticulo = (string)lector[1];
					//aux.Nombre = (string)lector["Nombre"]; de las dos maneras
					aux.Nombre = lector.GetString(2);
					aux.Descripcion = lector.GetString(3);
					aux.Precio = double.Parse(lector["precio"].ToString());
					aux.ImagenURL = lector.GetString(4);

					aux.Marca = new Marca(); /// como marca tien un tipo de dato tengoq ue setar el valor que trae
					aux.Marca.IDMarca = lector.GetInt32(6);
					aux.Marca.DescripcionMarca = lector.GetString(7);


					aux.Categoria = new Categoria();
					aux.Categoria.IDCategoria = lector.GetInt32(8);
					aux.Categoria.DescripcionCategoria = lector.GetString(9);

					listado.Add(aux);
				}


				return listado;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{

				conexion.Close();
			}
		}

		public void Agregar(Articulo nuevo)
		{
			SqlConnection conexion = new SqlConnection(); /// para la conexion
			SqlCommand comando = new SqlCommand(); /// comando

			try
			{
				// Le digo a donde conectarme  conexion sql(agregar una barra), cual es el catalogo NOMBRE DE LA BASE DE DATOS, CONEXION( esta x ser desde la conexion local, seguridad integrada)

				conexion.ConnectionString = "data source= Maite-R-Rodas\\SQLEXPRESS; initial catalog=CATALOGO_DB;integrated security=sspi;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "insert into ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenURL,Precio) Values (@CodigoArticulo,@Nombre,@Descripcion,@Marca,@Categoria,@ImagenURL,@Precio)";

				comando.Parameters.Clear(); 
				comando.Parameters.AddWithValue("@CodigoArticulo", nuevo.CodigoArticulo);
				comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
				comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
				comando.Parameters.AddWithValue("@ImagenURL", nuevo.ImagenURL);/// le paso el nombre de la variable para agregar imagen
				comando.Parameters.AddWithValue("@Marca", nuevo.Marca.IDMarca);
				comando.Parameters.AddWithValue("@Categoria", nuevo.Categoria.IDCategoria);
				comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
				comando.Connection = conexion;
				conexion.Open();
				comando.ExecuteNonQuery();


			}

			catch (Exception ex)
			{

				throw ex;
			}

			 finally
			{
				conexion.Close();
			}
		}

		public void Eliminar(Articulo eliminar)
		{
			SqlConnection conexion = new SqlConnection(); /// para la conexion
			SqlCommand comando = new SqlCommand(); /// comando

			try
			{
				// Le digo a donde conectarme  conexion sql(agregar una barra), cual es el catalogo NOMBRE DE LA BASE DE DATOS, CONEXION( esta x ser desde la conexion local, seguridad integrada)

				conexion.ConnectionString = "data source= Maite-R-Rodas\\SQLEXPRESS; initial catalog=CATALOGO_DB;integrated security=sspi;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "delete from articulos where id=" + eliminar.IdArticulo.ToString();

				comando.Connection = conexion;
				conexion.Open();
				comando.ExecuteNonQuery();
			}

			catch (Exception ex)
			{

				throw ex;
			}

			finally
			{
				conexion.Close();
			}
		}

		public void Modificar(Articulo nuevo)
		{
			SqlConnection conexion = new SqlConnection(); /// para la conexion
			SqlCommand comando = new SqlCommand(); /// comando

			try
			{
				// Le digo a donde conectarme  conexion sql(agregar una barra), cual es el catalogo NOMBRE DE LA BASE DE DATOS, CONEXION( esta x ser desde la conexion local, seguridad integrada)

				conexion.ConnectionString = "data source= Maite-R-Rodas\\SQLEXPRESS; initial catalog=CATALOGO_DB;integrated security=sspi;";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "update ARTICULOS set codigo=@CodigoArticulo, nombre=@Nombre, descripcion=@Descripcion, ImagenURL=@ImagenURL, IdMarca=@Marca, IdCategoria=@Categoria, Precio=@Precio where Id=" + nuevo.IdArticulo;

				comando.Parameters.Clear();
				comando.Parameters.AddWithValue("@CodigoArticulo", nuevo.CodigoArticulo);
				comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
				comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
				comando.Parameters.AddWithValue("@ImagenURL", nuevo.ImagenURL);
				comando.Parameters.AddWithValue("@Marca", nuevo.Marca.IDMarca);
				comando.Parameters.AddWithValue("@Categoria", nuevo.Categoria.IDCategoria);
				comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
				comando.Connection = conexion;
				conexion.Open();
				comando.ExecuteNonQuery();

			}

			catch (Exception ex)
			{

				throw ex;
			}

			finally
			{
				conexion.Close();
			}
		}

	}

}
