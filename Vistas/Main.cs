using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_Tecnico
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
            Articulo.Text = string.Empty;
            Marca.Text = string.Empty;
            Modelo.Text = string.Empty;
            cbo_Departamento.SelectedIndex = -1;
            cbo_Clase.SelectedIndex = -1;
            cbo_Familia.SelectedIndex = -1;
            Stock.Text = string.Empty;
            Cantidad.Text = string.Empty;
            Fecha_Alta.Value = DateTime.Now;
            Fecha_Baja.Value = DateTime.Now;
        }

        private void Sku_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Alta_Click(object sender, EventArgs e)
        {

            if (Articulo.Text == "" || Marca.Text == "" || Modelo.Text == "" || cbo_Familia.SelectedIndex < 0
                || Stock.Text == "" || Cantidad.Text == "")
            {
                MessageBox.Show("Por favor llenar todos los campos antes de dar de Alta");
            }
            else 
            {

                var sku = Sku.Text;
                var articuloname = Articulo.Text;
                var marca = Marca.Text;
                var modelo = Modelo.Text;
                var familia = cbo_Familia.SelectedValue.ToString();
                var stock = Int32.Parse(Stock.Text);
                var cantidad = Int32.Parse(Cantidad.Text);
                var descontinuado = cb_descontinuado.Checked;

                if (cantidad > stock)
                {

                    MessageBox.Show("La cantidad no puede ser mayor al stock.");

                }
                else
                {
                    var articulo = new Clases.Articulo(sku, articuloname, marca, modelo, familia, stock, cantidad, descontinuado);

                    bool result = articulo.Alta();

                    if (result)
                    {
                        MessageBox.Show("Articulo dado de Alta con exito");

                        ResetForm();
                        Sku.Text = string.Empty;
                    }
                }
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            var departamento = new Clases.ListadosDCF();
            var tabla = departamento.ListaDepartamentos();

            if(tabla.Rows.Count > 0) 
            {

                cbo_Departamento.DataSource = tabla;
                cbo_Departamento.ValueMember = "Id_departamento";
                cbo_Departamento.DisplayMember = "Nombre_departamento";


            }

            cbo_Departamento.SelectedIndex = -1;         
        }

        private void cbo_Departamento_SelectedValueChanged(object sender, EventArgs e)
        {

            if ( cbo_Departamento.SelectedIndex >= 0)
            {
                cbo_Clase.Enabled = true;

                var clase = new Clases.ListadosDCF();
                var departamentoId = cbo_Departamento.SelectedValue.ToString();
                var tabla = clase.ListaClasesPorDepartamento(departamentoId);

                if (tabla.Rows.Count > 0)
                {

                    cbo_Clase.DataSource = tabla;
                    cbo_Clase.ValueMember = "Id_clase";
                    cbo_Clase.DisplayMember = "Nombre_clase";


                }
            }
            else
            {
                cbo_Clase.Enabled = false;
            }

            cbo_Clase.SelectedIndex = -1;

        }

        private void cbo_Clase_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo_Clase.SelectedIndex >= 0)
            {
                cbo_Familia.Enabled = true;

                var familia = new Clases.ListadosDCF();
                var claseId = cbo_Clase.SelectedValue.ToString();
                var tabla = familia.ListaFamiliaPorClase(claseId);

                if (tabla.Rows.Count > 0)
                {

                    cbo_Familia.DataSource = tabla;
                    cbo_Familia.ValueMember = "Id_familia";
                    cbo_Familia.DisplayMember = "Nombre_familia";

                }
            }
            else 
            {
                cbo_Familia.Enabled = false;
            }

            cbo_Familia.SelectedIndex = -1;
        }

        private void Sku_TextChanged(object sender, EventArgs e)
        {
            if (Sku.Text.Length == 6)
            {
                var sku = new Clases.Articulo();
                string skuvalue = Sku.Text;
                var tabla = sku.ConsultaPorSku(skuvalue);

                if (tabla.Rows.Count > 0)
                {
                    Actualizar.Enabled = true;
                    Baja.Enabled = true;
                    Articulo.Text = tabla.Rows[0]["Articulo"].ToString();
                    Marca.Text = tabla.Rows[0]["Marca"].ToString();
                    Modelo.Text = tabla.Rows[0]["Modelo"].ToString();
                    cbo_Departamento.SelectedValue = tabla.Rows[0]["Departamento"].ToString();
                    cbo_Clase.SelectedValue = tabla.Rows[0]["Clase"].ToString();
                    cbo_Familia.SelectedValue = tabla.Rows[0]["Familia"].ToString();
                    Stock.Text = tabla.Rows[0]["Stock"].ToString();
                    Cantidad.Text = tabla.Rows[0]["Cantidad"].ToString();
                    Fecha_Alta.Value = DateTime.Parse(tabla.Rows[0]["Fecha_alta"].ToString());
                    Fecha_Baja.Value = DateTime.Parse(tabla.Rows[0]["Fecha_baja"].ToString());
                    cb_descontinuado.Checked = Boolean.Parse(tabla.Rows[0]["Descontinuado"].ToString());

                    Articulo.Enabled = true;
                    Marca.Enabled = true;
                    Modelo.Enabled = true;
                    cbo_Departamento.Enabled = true;
                    Stock.Enabled = true;
                    Cantidad.Enabled = true;
                    cb_descontinuado.Enabled = true;
                }
                else
                {
                    ResetForm();

                    Alta.Enabled = true;
                    Articulo.Enabled = true;
                    Marca.Enabled = true;
                    Modelo.Enabled = true;
                    cbo_Departamento.Enabled = true;
                    Stock.Enabled = true;
                    Cantidad.Enabled = true;

                }
            }
            else 
            {
                Actualizar.Enabled = false;
                Baja.Enabled = false;
                Alta.Enabled = false;
                Articulo.Enabled = false;
                Marca.Enabled = false;
                Modelo.Enabled = false;
                cbo_Departamento.Enabled = false;
                cbo_Clase.Enabled = false;
                cbo_Familia.Enabled = false;
                Stock.Enabled = false;
                Cantidad.Enabled = false;
                cb_descontinuado.Checked = false;
                cb_descontinuado.Enabled= false;

            }
        }

        private void Baja_Click(object sender, EventArgs e)
        {
            var sku = Sku.Text;
            DialogResult Dlresult = MessageBox.Show("Estas seguro que quieres eliminar este articulo?", "Confirmacion", MessageBoxButtons.YesNo);

            if (Dlresult == DialogResult.Yes)
            {
                var articulo = new Clases.Articulo(sku);
                bool result = articulo.Baja();

                if (result) 
                {

                    MessageBox.Show("Articulo eliminado con exito");

                    ResetForm();
                    Sku.Text = string.Empty;

                }
            }
            
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            var sku = Sku.Text;
            var articuloname = Articulo.Text;
            var marca = Marca.Text;
            var modelo = Modelo.Text;
            var familia = cbo_Familia.SelectedValue.ToString();
            var stock = Int32.Parse(Stock.Text);
            var cantidad = Int32.Parse(Cantidad.Text);
            var descontinuado = cb_descontinuado.Checked;

            if (cantidad > stock)
            {

                MessageBox.Show("La cantidad no puede ser mayor al stock.");

            }
            else
            {
                var articulo = new Clases.Articulo(sku, articuloname, marca, modelo, familia, stock, cantidad, descontinuado);

                bool result = articulo.Actualizar();

                if (result)
                {
                    MessageBox.Show("Articulo Actualizado con exito");

                    ResetForm();
                    Sku.Text = string.Empty;
                    cb_descontinuado.Checked= false;
                }
            }
        }

        private void Consulta_DCF_Click(object sender, EventArgs e)
        {
            ConsultaDCF DCF = ConsultaDCF.OnlyOne();
            DCF.Show();
        }
    }
}
