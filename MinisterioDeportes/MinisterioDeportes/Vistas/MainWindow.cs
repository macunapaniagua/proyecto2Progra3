﻿using System;
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

        /// <summary>
        /// Evento para el boton asociar participante con deporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
