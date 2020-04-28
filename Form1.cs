using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
using MaiteTp2;
using System.Security.Cryptography;
using System.Security.AccessControl;

namespace Negocio
{
    public partial class Form1 : Form
    {

        private List<Articulo> lista;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

                cargarGrilla();

        }


        private void cargarGrilla()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
           
            try
            {
                lista = negocio.Listar();
                grillaArticulos.DataSource = negocio.Listar();
                grillaArticulos.Columns[0].Visible = false;
                grillaArticulos.Columns[6].Visible = false;
                //agregando esto, saco que las columnas vacias esten visibles
                // Articulo__.Columns[2].Visible = false;*/
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void grillaArticulos_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //Agarra la imagen que esta seleccionada, luego la muestra
                Articulo arti= new Articulo();
                arti = (Articulo)grillaArticulos.CurrentRow.DataBoundItem;// de la grilla que estoy seleccionada dame el objeto en el que etsoy seleccionada
                ImagenArticulo.Load(arti.ImagenURL);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Alta__Articulo alta = new Alta__Articulo();
            alta.ShowDialog();// define la pantalla la que estas usando ahora
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo modificar;
            //modificar = (Articulo)grillaArticulos.CurrentRow.DataBoundItem; ////// mi grilla donde muestran los articulos
            modificar = (Articulo)grillaArticulos.CurrentRow.DataBoundItem; 
            Alta__Articulo formularioModificar = new Alta__Articulo(modificar);
            formularioModificar.ShowDialog();
            cargarGrilla();
        }

        private void grillaArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo eliminar = (Articulo)grillaArticulos.CurrentRow.DataBoundItem;
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.Eliminar(eliminar);
            cargarGrilla();
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> filtrarBusqueda;
                if (textBusqueda.Text == "")
                {
                    filtrarBusqueda = lista;
                   // grillaArticulos.DataSource = lista;
                }
                else
                {
                    filtrarBusqueda = lista.FindAll(b => b.Descripcion.ToLower().Contains(textBusqueda.Text.ToLower()) || b.Nombre.ToLower().Contains(textBusqueda.Text.ToLower()));
                    //grillaArticulos.DataSource = filtrarBusqueda;



                }
                grillaArticulos.DataSource = filtrarBusqueda;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

