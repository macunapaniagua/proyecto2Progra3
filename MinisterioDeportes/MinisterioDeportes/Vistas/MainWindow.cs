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
using MovieWorld.Util;


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

            cargarTodosDeportes();
            cargarTodasRutinas();
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
            gridTablaDeportes.ClearSelection();
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
                if (!String.IsNullOrWhiteSpace(txtNombreDeporte.Text))
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
                        }
                        limpiarCamposDeporte();
                    }
                }
                else
                {
                    MessageBox.Show("El campo con el nombre del deporte es requerido para actualizar los datos");
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
                        cargarTodosDeportes();
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
                    if (resultadoEliminacion != null)
                    {
                        MessageBox.Show(resultadoEliminacion);
                    }
                    else
                    {
                        cargarTodosDeportes();
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
                cargarTodosDeportes();
                limpiarCamposDeporte();
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
        /// Carga todos los deportes a la tabla
        /// </summary>
        private void cargarTodosDeportes()
        {
            using (WebServiceMDClient cliente = new WebServiceMDClient())
            {
                gridTablaDeportes.DataSource = cliente.ObtenerDeportes("");
            }
        }

        /// <summary>
        /// Evento para cargar la informacion de la fila seleccionada en los campos de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridTablaDeportes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = gridTablaDeportes.SelectedRows[0];
            txtIdDeporte.Text = selectedRow.Cells[0].Value.ToString();
            txtNombreDeporte.Text = selectedRow.Cells[1].Value.ToString();
        }

        #endregion

        #region ModuloRutina

        /// <summary>
        /// Limpia todos los campos del modulo rutina
        /// </summary>
        private void limpiarCamposRutina()
        {
            txtRutina.Clear();
            txtIdRutina.Clear();
            txtDetalleRutina.Clear();
            gridRutina.ClearSelection();
        }

        /// <summary>
        /// Agrega una rutina a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarRutina_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtRutina.Text))
            {
                RutinaDTO nuevaRutina = new RutinaDTO();
                nuevaRutina.nombre = txtRutina.Text;
                nuevaRutina.detalles = txtDetalleRutina.Text;

                using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                {
                    // Verifica si la insercion ha ocurrido exitosamente
                    String resultadoInsercion = clienteWebService.AgregarRutina(nuevaRutina);
                    if (resultadoInsercion != null)
                    {
                        MessageBox.Show(resultadoInsercion);
                    }
                    else
                    {
                        cargarTodasRutinas();
                    }
                    limpiarCamposRutina();
                }
            }
            else
            {
                MessageBox.Show("El campo con el nombre de la nueva rutina es requerido");
            }
        }

        /// <summary>
        /// Actualiza una rutina en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizarRutina_Click(object sender, EventArgs e)
        {
            String codigoRutinaTxt = txtIdRutina.Text;
            if (String.IsNullOrWhiteSpace(codigoRutinaTxt))
            {
                MessageBox.Show("Debe seleccionar la fila que desea editar");
                return;
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(txtRutina.Text))
                {
                    short codRutina;
                    if (!Int16.TryParse(codigoRutinaTxt, out codRutina))
                    {
                        MessageBox.Show("No se ha podido cargar el codigo de la rutina a actualizar. Intentelos mas tarde");
                        return;
                    }

                    RutinaDTO rutinaEditado = new RutinaDTO();
                    rutinaEditado.id = codRutina;
                    rutinaEditado.nombre = txtRutina.Text;
                    rutinaEditado.detalles = txtDetalleRutina.Text;

                    using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                    {
                        String resultadoActulizacion = clienteWebService.ActualizarRutina(rutinaEditado);
                        if (resultadoActulizacion != null)
                        {
                            MessageBox.Show(resultadoActulizacion);
                        }
                        else
                        {
                            // Actualiza la informacion del campo modificado
                            gridRutina.CurrentRow.Cells[1].Value = rutinaEditado.nombre;
                            gridRutina.CurrentRow.Cells[2].Value = rutinaEditado.detalles;
                        }
                        limpiarCamposRutina();
                    }
                }
                else
                {
                    MessageBox.Show("El campo con el nombre de la rutina es requerido para actualizarla");
                }
            }
        }

        /// <summary>
        /// Obtiene todas las rutinas y las establece en la tabla
        /// </summary>
        private void cargarTodasRutinas()
        {
            using (WebServiceMDClient cliente = new WebServiceMDClient())
            {
                gridRutina.DataSource = cliente.ObtenerRutinas("");
            }
        }

        /// <summary>
        /// Elimina una rutina de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarRutina_Click(object sender, EventArgs e)
        {
            String codigoRutinaTxt = txtIdRutina.Text;
            if (String.IsNullOrWhiteSpace(codigoRutinaTxt))
            {
                MessageBox.Show("Debe seleccionar la fila que desea eliminar");
                return;
            }
            else
            {
                short codRutina;
                if (!Int16.TryParse(codigoRutinaTxt, out codRutina))
                {
                    MessageBox.Show("No se ha podido eliminar la rutina. Intentelo más tarde.");
                    return;
                }

                RutinaDTO rutinaEliminado = new RutinaDTO();
                rutinaEliminado.id = codRutina;
                rutinaEliminado.nombre = txtRutina.Text;
                rutinaEliminado.detalles = txtDetalleRutina.Text;
                using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                {
                    String resultadoEliminacion = clienteWebService.EliminarRutina(rutinaEliminado);
                    if (resultadoEliminacion != null)
                    {
                        MessageBox.Show(resultadoEliminacion);
                    }
                    else
                    {
                        cargarTodasRutinas();
                    }
                    limpiarCamposRutina();
                }
            }
        }

        /// <summary>
        /// Carga los datos de la rutina seleccionada en los campos de edicion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridRutina_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = gridRutina.SelectedRows[0];
            txtIdRutina.Text = selectedRow.Cells[0].Value.ToString();
            txtRutina.Text = selectedRow.Cells[1].Value.ToString();
            txtDetalleRutina.Text = selectedRow.Cells[2].Value.ToString();
        }
                
        /// <summary>
        /// Evento para cargar el filtro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarRutina_Click(object sender, EventArgs e)
        {
            String rutinaBuscada = txtRutina.Text;
            if (String.IsNullOrWhiteSpace(rutinaBuscada))
            {
                cargarTodasRutinas();
                limpiarCamposRutina();
            }
            else
            {
                using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                {
                    List<RutinaDTO> rutina = clienteWebService.ObtenerRutinas(rutinaBuscada.ToLower()).ToList();
                    gridRutina.DataSource = rutina;
                    limpiarCamposRutina();
                }
            }
        }
        
        #endregion
                
        #region Modulo Participante

        /// <summary>
        /// Limpia los campos de participante
        /// </summary>
        private void limpiarCamposParticipantes()
        {
            txtNombreParticipante.Clear();
            txtApellido1.Clear();
            txtApellido2.Clear();
            txtIdParticipante.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            chkEsAdmi.Checked = false;
            gridParticipantes.ClearSelection();
        }

        /// <summary>
        /// Verifica si hay un campo requerido sin informacion
        /// </summary>
        /// <returns></returns>
        private Boolean isFieldRequiredEmpty()
        {
            return (String.IsNullOrEmpty(txtIdParticipante.Text) || String.IsNullOrEmpty(txtNombreParticipante.Text) ||
                String.IsNullOrEmpty(txtApellido1.Text) || String.IsNullOrEmpty(txtApellido2.Text));
        }

        /// <summary>
        /// Genera una contraseña para el usuario que desea crear
        /// </summary>
        /// <returns></returns>
        public String crearPassword()
        {
            String newPassword = "";
            Random rand = new Random();
            // La longitud de la contraseña es de 6 caracteres
            for (int i = 0; i < 7; i++)
            {
                // Genera una letra si el random es 1... O un numero si es 0
                if (rand.Next(2) == 1)
                {
                    // Genera un random entre 97 y 122 que es el ascii para las letras minusculas
                    char letra = (char) (rand.Next(26) + 97);
                    newPassword += letra; 
                }
                else
                {
                    newPassword += rand.Next(10);
                }
            }
            return newPassword;
        }

        /// <summary>
        /// Valida que el formato del correo este bien
        /// </summary>
        /// <param name="pCorreo"></param>
        /// <returns></returns>
        private Boolean esCorreoValido(String pCorreo)
        {
            // Obtiene la posicion del @ del correo
            int posAt = pCorreo.IndexOf("@");
            if (posAt <= 0 || posAt == (pCorreo.Length - 1))
            {
                return false;
            }
            else
            {
                String dominio = pCorreo.Substring(posAt + 1);
                int posPunto = dominio.IndexOf(".");
                return posPunto != -1 && posPunto == dominio.LastIndexOf('.') && posPunto != 0 && posPunto != (dominio.Length - 1);
            }
        }
 
        /// <summary>
        /// Crea una persona con los datos existentes en los campos de texto
        /// </summary>
        /// <returns></returns>
        private PersonaDTO crearPersona()
        {
            PersonaDTO nuevaPersona = new PersonaDTO()
            {
                nombre = txtNombreParticipante.Text.Trim(),
                apellido1 = txtApellido1.Text.Trim(),
                apellido2 = txtApellido2.Text.Trim(),
                cedula = txtIdParticipante.Text.Trim(),
                password = crearPassword(),
                isAdmin = chkEsAdmi.Checked,
                email = txtEmail.Text.Trim()
            };
            return nuevaPersona;
        }

        /// <summary>
        /// Agrega un nuevo usuario al sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarParticipante_Click(object sender, EventArgs e)
        {
            if (!isFieldRequiredEmpty())
            {
                if(!String.IsNullOrEmpty(txtEmail.Text) && !esCorreoValido(txtEmail.Text.Trim())){
                    MessageBox.Show("El correo electrónico no tiene un formato válido");
                    return;
                }else{
                    PersonaDTO nuevoParticipante = crearPersona();
                    using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                    {
                        // Verifica si la insercion ha ocurrido exitosamente
                        String resultadoInsercion = clienteWebService.AgregarPersona(nuevoParticipante);
                        if (resultadoInsercion != null)
                        {
                            MessageBox.Show(resultadoInsercion);
                        }
                        else
                        {
                            String password = nuevoParticipante.password;
                            // Verifica si habia correo para mandar el email
                            if (!String.IsNullOrEmpty(txtEmail.Text))
                            {
                                // Crea la informacion del mensaje a enviar
                                String subject = "Credenciales Ministerio de Deporte";
                                String mensaje = nuevoParticipante.nombre + ", gracias por registrarse en el Ministerio "
                                    + "de Deportes. Los datos para ingresar son: Usuario = " + nuevoParticipante.cedula 
                                    + " y contraseña = " + password + ". Esperamos tenerle pronto por acá";
                                List<String> destinatarios = new List<string>{nuevoParticipante.email};

                                // Envia el correo
                                Email administradorCorreos = new Email(Properties.Resources.adminEmail, Properties.Resources.adminPassword);
                                administradorCorreos.EnviarMensaje(destinatarios, subject, mensaje);
                            }
                            MessageBox.Show("El usuario ha sido creado con éxito. El password es: " + password);
                            cargarTodosParticipantes();
                        }
                        limpiarCamposParticipantes();
                    } 
                }                             
            }
            else
            {
                MessageBox.Show("Hay campos requeridos en blanco. Asegurese de completar: nombre, apellidos y cédula");
            }
        }

        /// <summary>
        /// Obtiene todos los participantes del sistema
        /// </summary>
        private void cargarTodosParticipantes()
        {
            using (WebServiceMDClient cliente = new WebServiceMDClient())
            {
                gridParticipantes.DataSource = cliente.ObtenerParticipantes("");
            }
        }

        /// <summary>
        /// Actualiza la informacion de un participante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizarParticipante_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPassword.Text) && !isFieldRequiredEmpty())
            {
                if (!String.IsNullOrEmpty(txtEmail.Text) && !esCorreoValido(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("El correo electrónico no tiene un formato válido");
                    return;
                }
                else
                {
                    PersonaDTO nuevoParticipante = crearPersona();
                    nuevoParticipante.password = txtPassword.Text;
                    
                    using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                    {
                        // Verifica si la insercion ha ocurrido exitosamente
                        String resultadoInsercion = clienteWebService.ActualizarPersona(nuevoParticipante);
                        if (resultadoInsercion != null)
                        {
                            MessageBox.Show(resultadoInsercion);
                        }
                        else
                        {
                            String password = nuevoParticipante.password;

                            // Verifica si habia correo para mandar el email
                            if (!String.IsNullOrEmpty(txtEmail.Text))
                            {
                                // Crea la informacion del mensaje a enviar
                                String subject = "Actualización de Credenciales";
                                String mensaje = nuevoParticipante.nombre + ", sus datos han sido actualizado de manera exitosa.";
                                List<String> destinatarios = new List<string> { nuevoParticipante.email };

                                // Envia el correo
                                Email administradorCorreos = new Email(Properties.Resources.adminEmail, Properties.Resources.adminPassword);
                                administradorCorreos.EnviarMensaje(destinatarios, subject, mensaje);
                            }
                            MessageBox.Show("El usuario ha sido actualizado con éxito.");
                            cargarTodosParticipantes();
                        }
                        limpiarCamposParticipantes();
                    }
                }
            }
            else
            {
                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Primero debe seleccionar la fila que desea modificar");
                }
                else
                {
                    MessageBox.Show("Hay campos requeridos en blanco. Asegurese de completar: nombre, apellidos y cédula");
                }                
            }
        }

        /// <summary>
        /// Busca los usuarios en el sistema que cumplan con el nombre especificado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarParticipante_Click(object sender, EventArgs e)
        {
            String participanteBuscado = txtNombreParticipante.Text;
            if (String.IsNullOrWhiteSpace(participanteBuscado))
            {
                cargarTodosParticipantes();                
            }
            else
            {
                using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                {
                    List<PersonaDTO> personas = clienteWebService.ObtenerParticipantes(participanteBuscado.ToLower()).ToList();
                    gridParticipantes.DataSource = personas;
                }
            }
            limpiarCamposParticipantes();
        }
        
        /// <summary>
        /// Carga los datos de la fila seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridParticipantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = gridParticipantes.SelectedRows[0];
            txtIdParticipante.Text = selectedRow.Cells[0].Value.ToString();
            txtNombreParticipante.Text = selectedRow.Cells[1].Value.ToString();
            txtApellido1.Text = selectedRow.Cells[2].Value.ToString();
            txtApellido2.Text = selectedRow.Cells[3].Value.ToString();
            txtPassword.Text = selectedRow.Cells[4].Value.ToString();
            txtEmail.Text = selectedRow.Cells[5].Value != null ? selectedRow.Cells[5].Value.ToString() : "";
            chkEsAdmi.Checked = Convert.ToBoolean(selectedRow.Cells[6].Value);
        }

        /// <summary>
        /// Elimina un partcipante de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarParticipante_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Debe seleccionar la fila que desea eliminar");
                return;
            }
            else
            {
                String idEliminar = txtIdParticipante.Text;

                if(String.IsNullOrEmpty(idEliminar)){
                    MessageBox.Show("Debe existir el campo cedula del participante a borrar");
                    return;
                }

                PersonaDTO personaEliminada = new PersonaDTO() { cedula = idEliminar };
                using (WebServiceMDClient clienteWebService = new WebServiceMDClient())
                {
                    String resultadoEliminacion = clienteWebService.EliminarPersona(personaEliminada);
                    if (resultadoEliminacion != null)
                    {
                        MessageBox.Show(resultadoEliminacion);
                    }
                    else
                    {
                        cargarTodosParticipantes();
                    }
                    limpiarCamposParticipantes();
                }
            }
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
