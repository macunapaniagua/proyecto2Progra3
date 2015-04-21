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
    public partial class CustomComboDialog : Form
    {
        Label Result;

        public CustomComboDialog(List<String> pOpciones, Label pSeleccion)
        {
            InitializeComponent();
            // Establece la lista de opciones al combobox
            cmbOpciones.DataSource = pOpciones;
            Result = pSeleccion;
        }

        /// <summary>
        /// Cancel button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Add button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Result.Text = cmbOpciones.SelectedIndex.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();            
        }          
    }
}
