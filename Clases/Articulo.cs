using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_Tecnico.Clases
{
    internal class Articulo : Ifunciones
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_examenT"].ConnectionString);

        public string sku { get; set; }
        public string articulo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string familia { get; set; }
        public DateTime fechaAlta { get; set; }
        public int stock { get; set; }
        public int cantidad { get; set; }
        public bool descontinuado { get; set; }
        public DateTime fechaBaja { get; set; }

        public Articulo()
        { 
        
        }

        //Constructor para Alta y Actualizar
        public Articulo(string sku, string articulo, string marca, string modelo, string familia, int stock, int cantidad,bool descontinuado)
        {
            this.sku = sku;
            this.articulo = articulo;
            this.marca = marca;
            this.modelo = modelo;
            this.familia = familia;
            this.fechaAlta = fechaAlta;
            this.stock = stock;
            this.cantidad = cantidad;
            this.fechaBaja = fechaBaja;
            this.descontinuado = descontinuado;
        }

        //Constructor para Baja
        public Articulo(string sku)
        {
            this.sku = sku;

        }



        public bool Alta()
        {

            bool result = false;

            try 
            {
                var cmd = new SqlCommand("SP_Alta_Articulo", cn);
                cmd.Parameters.AddWithValue("@Sku", this.sku);
                cmd.Parameters.AddWithValue("@Articulo", this.articulo);
                cmd.Parameters.AddWithValue("@Marca", this.marca);
                cmd.Parameters.AddWithValue("@Modelo", this.modelo);
                cmd.Parameters.AddWithValue("@Familia", this.familia);
                cmd.Parameters.AddWithValue("@Stock", this.stock);
                cmd.Parameters.AddWithValue("@Cantidad", this.cantidad);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                
                result= true;

                cn.Close();
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

                return result;          

            }

            return result;

        }

        public bool Baja()
        {
            bool result = false;

            try
            {
                var cmd = new SqlCommand("SP_Baja_Articulo", cn);
                cmd.Parameters.AddWithValue("@Sku", this.sku);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();

                result = true;

                cn.Close();
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

                return result;

            }

            return result;
        }

        public bool Actualizar()
        {
            bool result = false;

            if (this.descontinuado) 
            { 
                this.fechaBaja = DateTime.Now;
            }
            else
            {
                this.fechaBaja = DateTime.Parse("01/01/1990");
            }

            try
            {
                var cmd = new SqlCommand("SP_Actualizar_Articulo", cn);
                cmd.Parameters.AddWithValue("@Sku", this.sku);
                cmd.Parameters.AddWithValue("@Articulo", this.articulo);
                cmd.Parameters.AddWithValue("@Marca", this.marca);
                cmd.Parameters.AddWithValue("@Modelo", this.modelo);
                cmd.Parameters.AddWithValue("@Familia", this.familia);
                cmd.Parameters.AddWithValue("@Stock", this.stock);
                cmd.Parameters.AddWithValue("@Cantidad", this.cantidad);
                cmd.Parameters.AddWithValue("@Descontinuado", this.descontinuado);
                cmd.Parameters.AddWithValue("@FechaBaja", this.fechaBaja);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();

                result = true;

                cn.Close();
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

                return result;

            }

            return result;
        }

        public DataTable ConsultaDCF()
        {
            var tabla = new DataTable();

            try
            {
                var cmd = new SqlCommand("SP_Consulta_DCF", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                tabla.Load(reader);
                cn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return tabla;
            }

            return tabla;
        }

        public DataTable ConsultaPorSku(string id)
        {
            var tabla = new DataTable();

            try
            {
                var cmd = new SqlCommand("SP_Consulta_Sku", cn);
                cmd.Parameters.AddWithValue("@SKU", id);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                tabla.Load(reader);
                cn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return tabla;
            }

            return tabla;
        }
    }
}
