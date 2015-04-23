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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            String userName = txtUsuario.Text.Trim();
            String password = txtContrasena.Text.Trim();

            // Verifica que todos los campos tengan datos
            if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Han quedado campos sin información");
                return;
            }

            // Genera un usuario con los datos brindados en el login
            PersonaDTO user = new PersonaDTO()
            {
                cedula = userName,
                password = password
            };

            // Obtiene todos los datos del usuario ingresado (null si no existe)
            using (WebServiceMDClient cliente = new WebServiceMDClient())
            {
                user = cliente.ValidarLogin(user);
                if (user != null)
                {
                    // Limpia los campos de text y carga el dashboard
                    cleanFields();
                    MainWindow dashboard = new MainWindow(user);
                    dashboard.Show(this);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("El nombre de usuario y contraseña no coinciden o el usuario no existe en el sistema");
                }
            }            
        }

        /// <summary>
        /// Limpia los campos de texto
        /// </summary> 
        private void cleanFields()
        {
            txtContrasena.Clear();
            txtUsuario.Clear();
        }

        
    }
}
