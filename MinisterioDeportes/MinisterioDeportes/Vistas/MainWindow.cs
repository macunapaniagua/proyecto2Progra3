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


namespace MinisterioDeportes.Vistas
{
    public partial class MainWindow : Form
    {
        public MainWindow(Boolean isAdmin)
        {
            InitializeComponent();
            // Remueve los tabs de administracion para el usuario
            if (!isAdmin) { removerTabAdministracion(); } 
        }

        /// <summary>
        /// Remueve los paneles de Administracion, para que no sean
        /// accesados por un usuario sin privilegios
        /// </summary>
        private void removerTabAdministracion()
        {
            tbcDashboard.TabPages.Remove(tabDeportes);
            tbcDashboard.TabPages.Remove(tabParticipantes);
            tbcDashboard.TabPages.Remove(tabPlanDeRutina);
        }


        /// <summary>
        /// Abre la ventana de login cuando se presiona en la "X"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }

        private void tabDeportes_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarDeporte_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarRutina_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarParticipante_Click(object sender, EventArgs e)
        {
            ReferenceMinisterioDeportesWCF.WebServiceMDClient objMinisterioWCF = new ReferenceMinisterioDeportesWCF.WebServiceMDClient();
            persona persona = new persona();
            persona.cedula = Convert.ToInt16(txtID.Text);
            persona.password = txtPassword.Text;
            persona.is_admin= chkEsAdmi.Checked;    
            persona.nombre = txtNombre.Text;
            persona.apellido = txtApellido1.Text;
            persona.apellido2 = txtApellido2.Text;
            persona.cedula = Convert.ToInt16(txtID.Text);
            objMinisterioWCF.AgregarUsuario(persona);  
            objMinisterioWCF.AgregarPersona(persona); 
           
        }

     

    }



}
