using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_Juguetes
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Boton Agregar 
            try
            {
                double cantidad = Convert.ToDouble(txtCantidad.Text);
                string descripcion = txtDescription.Text;
                double precio = Convert.ToDouble(txtPrecio.Text);
                double total = cantidad * precio;
                dgvVentas.Rows.Add(descripcion, cantidad, precio, total);

            }

            catch
            {
                MessageBox.Show("Error en los datos colocados");
            }

            finally
            {
                txtCantidad.Clear();
                txtDescription.Clear();
                txtPrecio.Clear();
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            //boton Nueva
            dgvVentas.Rows.Clear();
            btnFinalizar.Enabled = true;
            btnQuitar.Enabled = true;
            btnAgregar.Enabled = true;
            txtCantidad.Clear();
            txtDescription.Clear();
            txtPrecio.Clear();
            txtDescription.Focus();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            //boton Quitar
            if (dgvVentas.CurrentRow != null)
            {
                int posicion = dgvVentas.CurrentRow.Index;
                dgvVentas.Rows.RemoveAt(posicion);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //boton Finalizar
            int x;
            double sub = 0;
            int cuantosrenglones = dgvVentas.Rows.Count;
            if(cuantosrenglones == 0)
            {
                MessageBox.Show("No hay articulos para totalizar");
                return;
            }
            
            for(x=0; x<= cuantosrenglones -1; x++)
            {
                sub = sub + Convert.ToDouble(dgvVentas[3, x].Value);
            }

            double iva = sub * 0.19;
            double total = sub + iva;
            dgvVentas.Rows.Add("", "", "ToTal:", sub);
            dgvVentas.Rows.Add("", "", "IVA:", total);
            btnFinalizar.Enabled = false;
            btnQuitar.Enabled = false;
            btnAgregar.Enabled = false;

        }
    }
}
