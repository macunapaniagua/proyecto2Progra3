using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinisterioDeportes.Vistas
{
    public partial class Dashboard : Form
    {
        public enum formulario
        {
            persona, deporte, planRutina, rutina, estadistica
        };

        public Dashboard()
        {
            InitializeComponent();
        }

        //Carga el formulario escogido por el ususario
        public void mostrarFormulario(formulario formulario)
        {
            if (splPrincipal.Panel2.Controls.Count > 0)
            {
                foreach (Control item in splPrincipal.Panel1.Controls)
                {
                    splPrincipal.Panel1.Controls.Remove(item);
                }
            }


            switch (formulario)
            {
                case formulario.persona:

                    frmPersona ofrmRepuesto = new frmPersona();
                    ofrmRepuesto.TopLevel = false;
                    ofrmRepuesto.FormBorderStyle = FormBorderStyle.None;
                    ofrmRepuesto.Dock = DockStyle.Fill;
                    this.splPrincipal.Panel1.Controls.Add(ofrmRepuesto);
                    this.splPrincipal.Panel1.Tag = ofrmRepuesto;
                    ofrmRepuesto.Show();
                    /*dtgInformacion.DataSource= */

                    break;

                case formulario.deporte:

                    frmDeporte ofrmDeporte = new frmDeporte();
                    ofrmDeporte.TopLevel = false;
                    ofrmDeporte.FormBorderStyle = FormBorderStyle.None;
                    ofrmDeporte.Dock = DockStyle.Fill;
                    this.splPrincipal.Panel1.Controls.Add(ofrmDeporte);
                    this.splPrincipal.Panel1.Tag = ofrmDeporte;
                    ofrmDeporte.Show();
                    /*dtgInformacion.DataSource= */

                    break;

                case formulario.planRutina:

                    frmPlanRutina ofrmPlanRutina = new frmPlanRutina();
                    ofrmPlanRutina.TopLevel = false;
                    ofrmPlanRutina.FormBorderStyle = FormBorderStyle.None;
                    ofrmPlanRutina.Dock = DockStyle.Fill;
                    this.splPrincipal.Panel1.Controls.Add(ofrmPlanRutina);
                    this.splPrincipal.Panel1.Tag = ofrmPlanRutina;
                    ofrmPlanRutina.Show();
                    /*dtgInformacion.DataSource= */

                    break;

                case formulario.rutina:

                    frmRutina ofrmRutina = new frmRutina();
                    ofrmRutina.TopLevel = false;
                    ofrmRutina.FormBorderStyle = FormBorderStyle.None;
                    ofrmRutina.Dock = DockStyle.Fill;
                    this.splPrincipal.Panel1.Controls.Add(ofrmRutina);
                    this.splPrincipal.Panel1.Tag = ofrmRutina;
                    ofrmRutina.Show();
                    /*dtgInformacion.DataSource= */

                    break;

                case formulario.estadistica:
                    frmEstadistica ofrmEstadistica = new frmEstadistica();
                    ofrmEstadistica.TopLevel = false;
                    ofrmEstadistica.FormBorderStyle = FormBorderStyle.None;
                    ofrmEstadistica.Dock = DockStyle.Fill;
                    this.splPrincipal.Panel1.Controls.Add(ofrmEstadistica);
                    this.splPrincipal.Panel1.Tag = ofrmEstadistica;
                    ofrmEstadistica.Show();
                    /*dtgInformacion.DataSource= */
                    break;

                default:
                    break;
            }
        }

 


    }
}
