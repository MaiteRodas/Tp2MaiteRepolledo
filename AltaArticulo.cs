
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;


namespace MaiteTp2
{
    public partial class Alta__Articulo : Form
    {
        private Articulo articulo;
        public Alta__Articulo()
        {
            InitializeComponent();
        }
        public Alta__Articulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if(articulo == null)
                   articulo = new Articulo();

                articulo.CodigoArticulo = textCodigo.Text;
                articulo.Nombre = textNombre.Text;
                articulo.Descripcion = textDescripcion.Text;
                articulo.Marca = (Marca)comboxMarca.SelectedItem;
                articulo.Categoria = (Categoria)comboBoxCategoria.SelectedItem;
                articulo.ImagenURL = textImagen.Text;
                articulo.Precio = double.Parse(textPrecio.Text);

                if (articulo.IdArticulo == null)
                {
                    negocio.Agregar(articulo);
                }
                else
                {
                    negocio.Modificar(articulo);
                }

                Dispose();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Alta__Articulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marca = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();
            try
            {
                comboxMarca.DataSource = marca.Listar();
                comboxMarca.ValueMember = "IdMarca"; // valor  //la referencia del valor
                comboxMarca.DisplayMember = "DescripcionMarca";  //clave //lo que se ve en el combo box
                comboBoxCategoria.DataSource = categoria.Listar();
                comboBoxCategoria.ValueMember = "IdCategoria";
                comboBoxCategoria.DisplayMember = "DescripcionCategoria";

                if(articulo != null)
                {
                    Text = "Modificar";
                    textNombre.Text = articulo.Nombre;
                    textCodigo.Text = articulo.CodigoArticulo;
                    textDescripcion.Text = articulo.Descripcion;
                    textImagen.Text = articulo.ImagenURL;
                    textPrecio.Text = articulo.Precio.ToString();
                    comboxMarca.SelectedValue = articulo.Marca.IDMarca;
                    comboBoxCategoria.SelectedValue = articulo.Categoria.IDCategoria;
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void comboxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
