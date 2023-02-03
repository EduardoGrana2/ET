using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_Tecnico
{
    public partial class ConsultaDCF : Form
    {
        public static ConsultaDCF instance = null;

        public static ConsultaDCF OnlyOne() 
        {
            if(instance==null)
            {
                instance = new ConsultaDCF();
                return instance;
            }
            return instance;
        }
        public ConsultaDCF()
        {
            InitializeComponent();
        }

        private void ConsultaDCF_Load(object sender, EventArgs e)
        {
            var ConDCF = new Clases.Articulo();
            var tabla = ConDCF.ConsultaDCF();

            if (tabla.Rows.Count > 0)
            {
                dgvDCF.DataSource = tabla;
            }
        }

        private void ConsultaDCF_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance= null;
        }
    }
}
