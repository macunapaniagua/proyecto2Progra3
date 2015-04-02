
using MinisterioDeportes.ReferenceMinisterioDeportesWCF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinisterioDeportes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReferenceMinisterioDeportesWCF.WebServiceMDClient objMinisterioDeportesWCF = new ReferenceMinisterioDeportesWCF.WebServiceMDClient();
                deporte deporte = new deporte();
                deporte.descripcion = "NADAR";
                deporte.ID = 1;
                objMinisterioDeportesWCF.EditarDeporte(deporte);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                
            }
        }
    }
}
