using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MinisterioDeportes.ReferenceMinisterioDeportesWCF;


namespace MinisterioDeportes.Vistas
{
    public partial class MainWindow : Form
    {
        private PersonaDTO usuario;                            // Usuario Logueado

        // Metodo constructor
        public MainWindow(PersonaDTO pUsuario)
        {
            InitializeComponent();
            usuario = pUsuario;
            // Remueve los tabs de administracion para el usuario
  //          if (!usuario.esAdmi) { removerTabAdministracion(); }


            gridTablaDeportes.DataSource = new WebServiceMDClient().ObtenerDeportes("");
        }

        /// <summary>
        /// Remueve los paneles de Administracion, para que no sean
        /// accesados por un usuario sin privilegios
        /// </summary>
        private void removerTabAdministracion()
        {
            tbcDashboard.TabPages.Remove(tabDeportes);
            tbcDashboard.TabPages.Remove(tabParticipantes);
            tbcDashboard.TabPages.Remove(tabAsociarUserDep);
            tbcDashboard.TabPages.Remove(tabPlanDeRutina);
            tbcDashboard.TabPages.Remove(tabRutina);

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
                short codDeporte;
                if (!Int16.TryParse(codigoDeporteTxt, out codDeporte))
                {
                    MessageBox.Show("No se ha podido cargar el codigo del deporte a actualizar. Intentelos mas tarde");
                    return;
                }

                DeporteDTO deporteEditado = new DeporteDTO();
                deporteEditado.Id = codDeporte;
                deporteEditado.Descripcion = txtNombreDeporte.Text;

                using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                {
                    String resultadoActulizacion = clienteWebService.EditarDeporte(deporteEditado);
                    if (resultadoActulizacion != null)
                    {
                        MessageBox.Show(resultadoActulizacion);
                    }
                    else
                    {
                        // Actualiza la informacion del campo modificado
                        gridTablaDeportes.CurrentRow.Cells[1].Value = deporteEditado.Descripcion;
                        MessageBox.Show("Se acaba de modificar la fila " + gridTablaDeportes.CurrentRow);
                    }
                    limpiarCamposDeporte();
                }
            }
        }

        /// <summary>
        /// Agrega un deporte a la Base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarDeporte_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtNombreDeporte.Text))
            {
                DeporteDTO newSport = new DeporteDTO();
                newSport.Descripcion = txtNombreDeporte.Text;

                using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                {
                    // Verifica si la insercion ha ocurrido exitosamente
                    String resultadoInsercion = clienteWebService.AgregarDeporte(newSport);
                    if (resultadoInsercion != null)
                    {
                        MessageBox.Show(resultadoInsercion);
                    }
                    else
                    {
                        MessageBox.Show("Debo crear una nueva fila con los datos del objeto insertado");
                    }
                    limpiarCamposDeporte();
                }
            }
            else
            {
                MessageBox.Show("El campo con el nombre del deporte no puede quedar vacío");
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
                short codDeporte;
                if (!Int16.TryParse(codigoDeporteTxt, out codDeporte))
                {
                    MessageBox.Show("No se ha podido eliminar el deporte. Intentelo más tarde.");
                    return;
                }

                DeporteDTO deporteEliminado = new DeporteDTO();
                deporteEliminado.Id = codDeporte;
                deporteEliminado.Descripcion = txtNombreDeporte.Text;
                using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                {
                    String resultadoEliminacion = clienteWebService.EliminarDeporte(deporteEliminado);
                    if (deporteEliminado != null)
                    {
                        MessageBox.Show(resultadoEliminacion);
                    }
                    else
                    {
                        gridTablaDeportes.Rows.RemoveAt(gridTablaDeportes.CurrentRow.Index);
                    }
                    limpiarCamposDeporte();
                }
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
            if (String.IsNullOrWhiteSpace(deporteBuscado))
            {
                MessageBox.Show("El nombre del deporte que desea buscar es requerido");
                return;
            }
            else
            {
                using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                {
                    List<DeporteDTO> deportes = clienteWebService.ObtenerDeportes(deporteBuscado.ToLower()).ToList();
                    gridTablaDeportes.DataSource = deportes;
                    limpiarCamposDeporte();
                }
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
            txtIdDeporte.Text = selectedRow.Cells[0].Value.ToString();
            txtNombreDeporte.Text = selectedRow.Cells[1].Value.ToString();
        }

        #endregion


        

        #region Modulo rutina
        private void limpiaCamposRutina()
        {
            txtRutina.Clear();
            txtIdRutina.Clear();
        }
        private void btnAgregarRutina_Click(object sender, EventArgs e)
        {
            //////if (!String.IsNullOrWhiteSpace(txtRutina.Text))
            //////{
            //////    rutina rutina = new rutina();
            //////    rutina.nombre = txtRutina.Text;
            //////    // Verifica si la insercion ha ocurrido exitosamente
            //////    String resultadoInsercion = clienteWebService.AgregarRutina(rutina);
            //////    if (resultadoInsercion != null)
            //////    {
            //////        MessageBox.Show(resultadoInsercion);
            //////    }
            //////    this.limpiaCamposRutina();
            //////}
        }
        private void btnActualizarRutina_Click(object sender, EventArgs e)
        {
            //////String codigoRutinaTxt = txtIdRutina.Text;
            //////if (String.IsNullOrWhiteSpace(codigoRutinaTxt))
            //////{
            //////    MessageBox.Show("Debe seleccionar la fila que desea editar");
            //////    return;
            //////}
            //////else
            //////{
            //////    int cod;
            //////    if (!Int32.TryParse(codigoRutinaTxt, out cod))
            //////    {
            //////        MessageBox.Show("Codigo de rutina incorrecto");
            //////        return;
            //////    }

            //////    rutina rutina = new rutina();
            //////    rutina.id = cod;
            //////    rutina.nombre = txtRutina.Text;

            //////    String resultadoActulizacion = clienteWebService.EditarRutina(rutina);
            //////    if (resultadoActulizacion != null)
            //////    {
            //////        MessageBox.Show(resultadoActulizacion);
            //////    }
            //////    limpiaCamposRutina();
            //////}
        }
        private void btnEliminarRutina_Click(object sender, EventArgs e)
        {
            //////String codigoRutinaTxt = txtIdRutina.Text;
            //////if (String.IsNullOrWhiteSpace(codigoRutinaTxt))
            //////{
            //////    MessageBox.Show("Debe seleccionar la fila que desea eliminar");
            //////    return;
            //////}
            //////else
            //////{
            //////    int cod;
            //////    if (!Int32.TryParse(codigoRutinaTxt, out cod))
            //////    {
            //////        MessageBox.Show("El codigo identificador de la rutina esta incorrecto");
            //////        return;
            //////    }

            //////    rutina rutina = new rutina();
            //////    rutina.id = cod;
            //////    rutina.nombre = txtRutina.Text;

            //////    String resultadoEliminacion = clienteWebService.EliminarRutina(rutina);
            //////    if (resultadoEliminacion != null)
            //////    {
            //////        MessageBox.Show(resultadoEliminacion);
            //////    }
            //////    limpiaCamposRutina();
            //////}
        }
        private void btnBuscarRutina_Click(object sender, EventArgs e)
        {
            //////String rutinaBuscada = txtRutina.Text;
            //////if (String.IsNullOrWhiteSpace(rutinaBuscada))
            //////{
            //////    MessageBox.Show("El nombre de la rutina que desea buscar es requerido");
            //////    return;
            //////}
            //////else
            //////{
            //////    rutina[] rutinas = clienteWebService.ObtenerRutina(rutinaBuscada.ToLower());
            //////    gridTablaDeportes.DataSource = rutinas;
            //////    limpiaCamposRutina();
            //////}
        }
        private void gridRutina_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //////DataGridViewRow selectedRow = gridTablaDeportes.SelectedRows[0];
            //////txtIdRutina.Text = selectedRow.Cells[0].ToString();
            //////txtRutina.Text = selectedRow.Cells[1].ToString();
        }
        #endregion

        #region Modulo Participante

        private void limpiarCamposParticipantes()
        {
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtNombre.Text = "";
            txtID.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            chkEsAdmi.Checked = false;
        }
        private Boolean isEmpty()
        {
            if (string.IsNullOrEmpty(txtID.Text) ||
                string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtApellido1.Text) ||
                string.IsNullOrEmpty(txtApellido2.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtID.Text))
            {
                return false;
            }
            return true;
        }
        private persona crearPersona()
        {
            persona persona = new persona();
            persona.cedula = Convert.ToInt16(txtID.Text);
            persona.password = creaPassword();
            persona.is_admin = chkEsAdmi.Checked;
            persona.nombre = txtNombre.Text;
            persona.apellido = txtApellido1.Text;
            persona.apellido2 = txtApellido2.Text;
            persona.email = txtEmail.Text;
            return persona;
        }
        public String creaPassword()
        {
            Random numAleatorio = new Random();
            int password = numAleatorio.Next(100000);
            MessageBox.Show("El password es: " + password + ", Asegurese de escribirlo antes de cerrar este mensaje");
            return password.ToString();
        }
        private void btnAgregarParticipante_Click(object sender, EventArgs e)
        {
            //////if (!isEmpty())
            //////{
            //////    MessageBox.Show("Debe llenar todos campos que se le solicitan");
            //////    return;
            //////}
            //////String resultadoInsercion = clienteWebService.AgregarPersona(this.crearPersona());
            //////if (resultadoInsercion != null)
            //////{
            //////    MessageBox.Show(resultadoInsercion);
            //////}
            //////this.limpiarCamposParticipantes();
        }
        private void btnActualizarParticipante_Click(object sender, EventArgs e)
        {
            //////int codPersona;
            //////if (!isEmpty())
            //////{
            //////    MessageBox.Show("Debe seleccionar una fila");
            //////    return;
            //////}
            //////else if (!Int32.TryParse(txtID.Text, out codPersona))
            //////{
            //////    MessageBox.Show("Numero de cedula incorrecto");
            //////    return;
            //////}
            //////String resultadoActulizacion = clienteWebService.EditarPersona(this.crearPersona());//problema con metodo crea persona: password y cedula
            //////if (resultadoActulizacion != null)
            //////{
            //////    MessageBox.Show(resultadoActulizacion);
            //////}

            //////this.limpiarCamposParticipantes();

        }
        private void btnBuscarParticipante_Click(object sender, EventArgs e)
        {
            //////String personaBuscada = txtID.Text;
            //////int cedPersona;
            //////if (String.IsNullOrWhiteSpace(personaBuscada))
            //////{
            //////    MessageBox.Show("La cedula de la persona que desea buscar es requerida");
            //////    return;
            //////}

            //////else if (!Int32.TryParse(personaBuscada, out cedPersona))
            //////{
            //////    persona[] personas = clienteWebService.ObtenerPersona(personaBuscada);
            //////    gridParticipantes.DataSource = personas;
            //////    this.limpiarCamposParticipantes();
            //////}
            //////else
            //////{
            //////    MessageBox.Show("La cedula esta compuesta solo de numeros");
            //////}
        }
        private void gridParticipantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = gridTablaDeportes.SelectedRows[0];
            txtID.Text = selectedRow.Cells[0].ToString();
            txtNombre.Text = selectedRow.Cells[1].ToString();
            txtApellido1.Text = selectedRow.Cells[2].ToString();
            txtApellido2.Text = selectedRow.Cells[3].ToString();
            txtEmail.Text = selectedRow.Cells[4].ToString();
            chkEsAdmi.Checked = (bool)selectedRow.Cells[4].Value;//verificar que funcione
        }

        #endregion
        
        #region Modulo Plan
        private void limpiarCamposPlan()
        {
            txtIdPlan.Clear();
            txtNombrePlan.Clear();
        }

        private void btnAgregarPlan_Click(object sender, EventArgs e)
        {
            //////if (!String.IsNullOrWhiteSpace(txtNombrePlan.Text))
            //////{
            //////    plan plan = new plan();
            //////    plan.descripcion = txtNombrePlan.Text;
            //////    // Verifica si la insercion ha ocurrido exitosamente
            //////    String resultadoInsercion = clienteWebService.AgregarPlanRutina(plan);
            //////    if (resultadoInsercion != null)
            //////    {
            //////        MessageBox.Show(resultadoInsercion);
            //////    }
            //////    limpiarCamposPlan();
            //////}
        }

        private void btnActualizarPlan_Click(object sender, EventArgs e)
        {
            //////String codigoPlan = txtIdPlan.Text;
            //////if (String.IsNullOrWhiteSpace(codigoPlan))
            //////{
            //////    MessageBox.Show("Debe seleccionar la fila que desea editar");
            //////    return;
            //////}
            //////else
            //////{
            //////    int cod;
            //////    if (!Int32.TryParse(codigoPlan, out cod))
            //////    {
            //////        MessageBox.Show("Codigo del plan incorrecto");
            //////        return;
            //////    }

            //////    plan plan = new plan();
            //////    plan.ID = cod;
            //////    plan.descripcion = txtNombrePlan.Text;

            //////    String resultadoActulizacion = clienteWebService.EditarPlanRutina(plan);
            //////    if (resultadoActulizacion != null)
            //////    {
            //////        MessageBox.Show(resultadoActulizacion);
            //////    }
            //////    limpiarCamposPlan();
            //////}
        }

        private void btnEliminarPlan_Click(object sender, EventArgs e)
        {
            //////String codigoPlanTxt = txtIdPlan.Text;
            //////if (String.IsNullOrWhiteSpace(codigoPlanTxt))
            //////{
            //////    MessageBox.Show("Debe seleccionar la fila que desea eliminar");
            //////    return;
            //////}
            //////else
            //////{
            //////    int cod;
            //////    if (!Int32.TryParse(codigoPlanTxt, out cod))
            //////    {
            //////        MessageBox.Show("El codigo identificador del plan es incorrecto");
            //////        return;
            //////    }

            //////    plan plan = new plan();
            //////    plan.ID = cod;
            //////    plan.descripcion = txtNombrePlan.Text;

            //////    String resultadoEliminacion = clienteWebService.EliminarPlanRutina(plan);
            //////    if (resultadoEliminacion != null)
            //////    {
            //////        MessageBox.Show(resultadoEliminacion);
            //////    }
            //////    limpiarCamposPlan();
            //////}
        }

        private void btnBuscarPlan_Click(object sender, EventArgs e)
        {
            //////String planBuscado = txtNombrePlan.Text;
            //////if (String.IsNullOrWhiteSpace(planBuscado))
            //////{
            //////    MessageBox.Show("El nombre del plan que desea buscar es requerido");
            //////    return;
            //////}
            //////else
            //////{
            //////    plan[] planes = clienteWebService.ObtenerPlanRutina(planBuscado.ToLower());
            //////    gridTablaDeportes.DataSource = planes;
            //////    limpiarCamposPlan();
            //////}
        }

        private void gridPlanRutina_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = gridTablaDeportes.SelectedRows[0];
            txtIdPlan.Text = selectedRow.Cells[0].ToString();
            txtNombrePlan.Text = selectedRow.Cells[1].ToString();
        }

        #endregion

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




        





    }

}
