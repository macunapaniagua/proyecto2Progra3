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
            int userCode = 0;
            String userName = txtUsuario.Text.Trim();
            String password = txtContrasena.Text.Trim();

            // Verifica que todos los campos tengan datos
            if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Han quedado campos sin información");
                return;
            }

            // Trata de convertir el texto ingresado a un entero
            if(!int.TryParse(userName, out userCode)){
                MessageBox.Show("El formato del nombre de usuario no coincide, únicamente debe contener números");
                return;
            }            
            
            usuario user = new usuario();
            user.usuario1 = userCode;
            user.contrasenia = password;

            /**
             *
             * AQUI SE DEBE HACER LA LLAMADA AL WCF PARA OBTENER SI LOS CREDENCIALES COINCIDEN Y SI ES ADMINISTRADOR
             * 
             */
            Boolean isAdmin = false;



            MainWindow dashboard = new MainWindow(isAdmin);
            dashboard.Show(this);
            this.Hide();
        }
    }
}
