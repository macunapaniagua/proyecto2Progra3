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
        private persona usuario;                            // Usuario Logueado
        private WebServiceMDClient clienteWebService;
         
        // Metodo constructor
        public MainWindow(persona pUsuario)
        {
            InitializeComponent();
            usuario = pUsuario;
            clienteWebService = new WebServiceMDClient();            
            // Remueve los tabs de administracion para el usuario
            if (!usuario.is_admin) { removerTabAdministracion(); }
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

        private void btnAgregarRutina_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarParticipante_Click(object sender, EventArgs e)
        {
            persona persona = new persona();
            persona.cedula = Convert.ToInt16(txtID.Text);
            persona.password = txtPassword.Text;
            persona.is_admin = chkEsAdmi.Checked;
            persona.nombre = txtNombre.Text;
            persona.apellido = txtApellido1.Text;
            persona.apellido2 = txtApellido2.Text;
            persona.cedula = Convert.ToInt16(txtID.Text);
            clienteWebService.AgregarPersona(persona);
        }

        private void btnAsociarUserDeporte_Click(object sender, EventArgs e)
        {

            List<String> asd = new List<String>() { "1", "2", "3", "4", "5", "1", "2", "3", "4", "5", "1", "2", "3", "4", "5" };

            Label seleccion = new Label();
            CustomComboDialog comboSeleccion = new CustomComboDialog(asd, seleccion);



            if (comboSeleccion.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Selecciona = " + seleccion.Text);
            }



        }



        #region Modulo Deporte

        /// <summary>
        /// Limpia los campos de texto de deporte
        /// </summary>
        private void limpiarCamposDeporte()
        {
            txtIdDeporte.Clear();
            txtNombreDeporte.Clear();
        }

        /// <summary>
        /// Evento para modificar la fila seleccionada de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizarDeporte_Click(object sender, EventArgs e)
        {
            String codigoDeporteTxt = txtIdDeporte.Text;
            if (String.IsNullOrWhiteSpace(codigoDeporteTxt))
            {
                MessageBox.Show("Debe seleccionar la fila que desea editar");
                return;
            }
            else
            {
                int codDeporte;
                if (!Int32.TryParse(codigoDeporteTxt, out codDeporte))
                {
                    MessageBox.Show("No se ha podido actualizar el deporte. Intentelo más tarde.");
                    return;
                }

                deporte deporteEditado = new deporte();
                deporteEditado.ID = codDeporte;
                deporteEditado.descripcion = txtNombreDeporte.Text;

                String resultadoActulizacion = clienteWebService.EditarDeporte(deporteEditado);
                if (deporteEditado != null)
                {
                    MessageBox.Show(resultadoActulizacion);
                }
                limpiarCamposDeporte();
            }
        }

        /// <summary>
        /// Agrega un deporte a la Base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarDeporte_Click(object sender, EventArgs e)
        {
            String nombreDeporte = txtNombreDeporte.Text;
            if (!String.IsNullOrWhiteSpace(nombreDeporte))
            {
                deporte newSport = new deporte();
                newSport.descripcion = nombreDeporte;
                // Verifica si la insercion ha ocurrido exitosamente
                String resultadoInsercion = clienteWebService.AgregarDeporte(newSport);
                if (resultadoInsercion != null)
                {
                    MessageBox.Show(resultadoInsercion);
                }
                limpiarCamposDeporte();
            }
        }

        /// <summary>
        /// Evento para eliminar un deporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarDeporte_Click(object sender, EventArgs e)
        {
            String codigoDeporteTxt = txtIdDeporte.Text;
            if (String.IsNullOrWhiteSpace(codigoDeporteTxt))
            {
                MessageBox.Show("Debe seleccionar la fila que desea eliminar");
                return;
            }
            else
            {
                int codDeporte;
                if (!Int32.TryParse(codigoDeporteTxt, out codDeporte))
                {
                    MessageBox.Show("No se ha podido eliminar el deporte. Intentelo más tarde.");
                    return;
                }

                deporte deporteEliminado = new deporte();
                deporteEliminado.ID = codDeporte;
                deporteEliminado.descripcion = txtNombreDeporte.Text;

                String resultadoEliminacion = clienteWebService.EliminarDeporte(deporteEliminado);
                if (deporteEliminado != null)
                {
                    MessageBox.Show(resultadoEliminacion);
                }
                limpiarCamposDeporte();
            }
        }

        /// <summary>
        /// Evento para cargar el filtro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarDeporte_Click(object sender, EventArgs e)
        {
            String deporteBuscado = txtNombreDeporte.Text;
            if(String.IsNullOrWhiteSpace(deporteBuscado)){
                MessageBox.Show("El nombre del deporte que desea buscar es requerido");
                return;
            }else{
                deporte[] deportes = clienteWebService.ObtenerDeporte(deporteBuscado.ToLower());
                gridTablaDeportes.DataSource = deportes;
                limpiarCamposDeporte();
            }
        }

        /// <summary>
        /// Evento para cargar la informacion de la fila seleccionada en los campos de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridTablaDeportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
            DataGridViewRow selectedRow = gridTablaDeportes.SelectedRows[0];
            txtIdDeporte.Text = selectedRow.Cells[0].ToString();
            txtNombreDeporte.Text = selectedRow.Cells[0].ToString();
        }

        #endregion

        


        

        



    }

}
