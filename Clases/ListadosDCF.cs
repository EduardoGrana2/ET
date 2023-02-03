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
    internal class ListadosDCF
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_examenT"].ConnectionString);

        public DataTable ListaDepartamentos()
        {
            var tabla = new DataTable();

            try 
            {
                var cmd = new SqlCommand("SP_Consulta_D",cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                tabla.Load(reader);
                cn.Close();

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
                return tabla;
            }

            return tabla;
        }

        public DataTable ListaClasesPorDepartamento(string departamentoId)
        {
            var tabla = new DataTable();

            try
            {
                var cmd = new SqlCommand("SP_Consulta_C", cn);
                cmd.Parameters.AddWithValue("@ID_DEPARTAMENTO", departamentoId);
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

        public DataTable ListaFamiliaPorClase(string claseId)
        {
            var tabla = new DataTable();

            try
            {
                var cmd = new SqlCommand("SP_Consulta_F", cn);
                cmd.Parameters.AddWithValue("@ID_CLASE", claseId);
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
