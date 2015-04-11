namespace MinisterioDeportes.Vistas
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tbcDashboard = new System.Windows.Forms.TabControl();
            this.tabDeportes = new System.Windows.Forms.TabPage();
            this.btnBuscarDeporte = new System.Windows.Forms.Button();
            this.btnEliminarDeporte = new System.Windows.Forms.Button();
            this.btnActualizarDeporte = new System.Windows.Forms.Button();
            this.btnAgregarDeporte = new System.Windows.Forms.Button();
            this.txtNombreDeporte = new System.Windows.Forms.TextBox();
            this.txtIdDeporte = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gridTablaDeportes = new System.Windows.Forms.DataGridView();
            this.tabParticipantes = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBuscarParticipante = new System.Windows.Forms.Button();
            this.btnEliminarParticipante = new System.Windows.Forms.Button();
            this.btnActualizarParticipante = new System.Windows.Forms.Button();
            this.btnAgregarParticipante = new System.Windows.Forms.Button();
            this.gridParticipantes = new System.Windows.Forms.DataGridView();
            this.tabRutina = new System.Windows.Forms.TabPage();
            this.btnBuscarRutina = new System.Windows.Forms.Button();
            this.btnEliminarRutina = new System.Windows.Forms.Button();
            this.btnActualizarRutina = new System.Windows.Forms.Button();
            this.btnAgregarRutina = new System.Windows.Forms.Button();
            this.cmbDeporteRutina = new System.Windows.Forms.ComboBox();
            this.txtNombreRutina = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdRutina = new System.Windows.Forms.TextBox();
            this.txtDetalleRutina = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridRutina = new System.Windows.Forms.DataGridView();
            this.tabPlanDeRutina = new System.Windows.Forms.TabPage();
            this.txtNombrePlan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRoutina = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtIdPlan = new System.Windows.Forms.TextBox();
            this.txtDetallesPlan = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.gridPlanRutina = new System.Windows.Forms.DataGridView();
            this.btnBuscarPlan = new System.Windows.Forms.Button();
            this.btnEliminarPlan = new System.Windows.Forms.Button();
            this.btnActualizarPlan = new System.Windows.Forms.Button();
            this.btnAgregarPlan = new System.Windows.Forms.Button();
            this.tabEstadísticas = new System.Windows.Forms.TabPage();
            this.chtEstadisticas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbcDashboard.SuspendLayout();
            this.tabDeportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTablaDeportes)).BeginInit();
            this.tabParticipantes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridParticipantes)).BeginInit();
            this.tabRutina.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRutina)).BeginInit();
            this.tabPlanDeRutina.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanRutina)).BeginInit();
            this.tabEstadísticas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtEstadisticas)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcDashboard
            // 
            this.tbcDashboard.Controls.Add(this.tabDeportes);
            this.tbcDashboard.Controls.Add(this.tabParticipantes);
            this.tbcDashboard.Controls.Add(this.tabRutina);
            this.tbcDashboard.Controls.Add(this.tabPlanDeRutina);
            this.tbcDashboard.Controls.Add(this.tabEstadísticas);
            this.tbcDashboard.Location = new System.Drawing.Point(12, 12);
            this.tbcDashboard.Name = "tbcDashboard";
            this.tbcDashboard.SelectedIndex = 0;
            this.tbcDashboard.Size = new System.Drawing.Size(886, 493);
            this.tbcDashboard.TabIndex = 0;
            // 
            // tabDeportes
            // 
            this.tabDeportes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDeportes.Controls.Add(this.btnBuscarDeporte);
            this.tabDeportes.Controls.Add(this.btnEliminarDeporte);
            this.tabDeportes.Controls.Add(this.btnActualizarDeporte);
            this.tabDeportes.Controls.Add(this.btnAgregarDeporte);
            this.tabDeportes.Controls.Add(this.txtNombreDeporte);
            this.tabDeportes.Controls.Add(this.txtIdDeporte);
            this.tabDeportes.Controls.Add(this.label11);
            this.tabDeportes.Controls.Add(this.label12);
            this.tabDeportes.Controls.Add(this.gridTablaDeportes);
            this.tabDeportes.Location = new System.Drawing.Point(4, 22);
            this.tabDeportes.Name = "tabDeportes";
            this.tabDeportes.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeportes.Size = new System.Drawing.Size(878, 467);
            this.tabDeportes.TabIndex = 0;
            this.tabDeportes.Text = "Deportes";
            this.tabDeportes.UseVisualStyleBackColor = true;
            this.tabDeportes.Click += new System.EventHandler(this.tabDeportes_Click);
            // 
            // btnBuscarDeporte
            // 
            this.btnBuscarDeporte.BackgroundImage = global::MinisterioDeportes.Properties.Resources.find;
            this.btnBuscarDeporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarDeporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnBuscarDeporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDeporte.Location = new System.Drawing.Point(796, 45);
            this.btnBuscarDeporte.Name = "btnBuscarDeporte";
            this.btnBuscarDeporte.Size = new System.Drawing.Size(51, 46);
            this.btnBuscarDeporte.TabIndex = 51;
            this.btnBuscarDeporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarDeporte.UseVisualStyleBackColor = true;
            // 
            // btnEliminarDeporte
            // 
            this.btnEliminarDeporte.BackgroundImage = global::MinisterioDeportes.Properties.Resources.delete;
            this.btnEliminarDeporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminarDeporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnEliminarDeporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDeporte.Location = new System.Drawing.Point(737, 45);
            this.btnEliminarDeporte.Name = "btnEliminarDeporte";
            this.btnEliminarDeporte.Size = new System.Drawing.Size(53, 46);
            this.btnEliminarDeporte.TabIndex = 50;
            this.btnEliminarDeporte.UseVisualStyleBackColor = true;
            // 
            // btnActualizarDeporte
            // 
            this.btnActualizarDeporte.BackgroundImage = global::MinisterioDeportes.Properties.Resources.update;
            this.btnActualizarDeporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizarDeporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnActualizarDeporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarDeporte.Location = new System.Drawing.Point(680, 45);
            this.btnActualizarDeporte.Name = "btnActualizarDeporte";
            this.btnActualizarDeporte.Size = new System.Drawing.Size(51, 46);
            this.btnActualizarDeporte.TabIndex = 49;
            this.btnActualizarDeporte.UseVisualStyleBackColor = true;
            // 
            // btnAgregarDeporte
            // 
            this.btnAgregarDeporte.BackColor = System.Drawing.Color.White;
            this.btnAgregarDeporte.BackgroundImage = global::MinisterioDeportes.Properties.Resources.add;
            this.btnAgregarDeporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregarDeporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnAgregarDeporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDeporte.Location = new System.Drawing.Point(621, 45);
            this.btnAgregarDeporte.Name = "btnAgregarDeporte";
            this.btnAgregarDeporte.Size = new System.Drawing.Size(53, 46);
            this.btnAgregarDeporte.TabIndex = 48;
            this.btnAgregarDeporte.UseVisualStyleBackColor = false;
            this.btnAgregarDeporte.Click += new System.EventHandler(this.btnAgregarDeporte_Click);
            // 
            // txtNombreDeporte
            // 
            this.txtNombreDeporte.Location = new System.Drawing.Point(141, 71);
            this.txtNombreDeporte.Name = "txtNombreDeporte";
            this.txtNombreDeporte.Size = new System.Drawing.Size(164, 20);
            this.txtNombreDeporte.TabIndex = 47;
            // 
            // txtIdDeporte
            // 
            this.txtIdDeporte.Location = new System.Drawing.Point(141, 36);
            this.txtIdDeporte.Name = "txtIdDeporte";
            this.txtIdDeporte.ReadOnly = true;
            this.txtIdDeporte.Size = new System.Drawing.Size(164, 20);
            this.txtIdDeporte.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(51, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Nombre:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(51, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Id Deporte:";
            // 
            // gridTablaDeportes
            // 
            this.gridTablaDeportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTablaDeportes.Location = new System.Drawing.Point(6, 121);
            this.gridTablaDeportes.Name = "gridTablaDeportes";
            this.gridTablaDeportes.Size = new System.Drawing.Size(864, 338);
            this.gridTablaDeportes.TabIndex = 0;
            // 
            // tabParticipantes
            // 
            this.tabParticipantes.Controls.Add(this.button5);
            this.tabParticipantes.Controls.Add(this.button6);
            this.tabParticipantes.Controls.Add(this.button7);
            this.tabParticipantes.Controls.Add(this.button8);
            this.tabParticipantes.Controls.Add(this.txtEmail);
            this.tabParticipantes.Controls.Add(this.label13);
            this.tabParticipantes.Controls.Add(this.textBox2);
            this.tabParticipantes.Controls.Add(this.label6);
            this.tabParticipantes.Controls.Add(this.checkBox1);
            this.tabParticipantes.Controls.Add(this.textBox3);
            this.tabParticipantes.Controls.Add(this.textBox4);
            this.tabParticipantes.Controls.Add(this.label7);
            this.tabParticipantes.Controls.Add(this.label8);
            this.tabParticipantes.Controls.Add(this.textBox5);
            this.tabParticipantes.Controls.Add(this.textBox6);
            this.tabParticipantes.Controls.Add(this.label9);
            this.tabParticipantes.Controls.Add(this.label10);
            this.tabParticipantes.Controls.Add(this.btnBuscarParticipante);
            this.tabParticipantes.Controls.Add(this.btnEliminarParticipante);
            this.tabParticipantes.Controls.Add(this.btnActualizarParticipante);
            this.tabParticipantes.Controls.Add(this.btnAgregarParticipante);
            this.tabParticipantes.Controls.Add(this.gridParticipantes);
            this.tabParticipantes.Location = new System.Drawing.Point(4, 22);
            this.tabParticipantes.Name = "tabParticipantes";
            this.tabParticipantes.Padding = new System.Windows.Forms.Padding(3);
            this.tabParticipantes.Size = new System.Drawing.Size(878, 467);
            this.tabParticipantes.TabIndex = 2;
            this.tabParticipantes.Text = "Participantes";
            this.tabParticipantes.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::MinisterioDeportes.Properties.Resources.find;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(744, 180);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(51, 46);
            this.button5.TabIndex = 48;
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::MinisterioDeportes.Properties.Resources.delete;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(685, 180);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(53, 46);
            this.button6.TabIndex = 47;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::MinisterioDeportes.Properties.Resources.update;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(628, 180);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(51, 46);
            this.button7.TabIndex = 46;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.BackgroundImage = global::MinisterioDeportes.Properties.Resources.add;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(569, 180);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(53, 46);
            this.button8.TabIndex = 45;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(435, 84);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(145, 20);
            this.txtEmail.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(323, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "Email:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(435, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(145, 20);
            this.textBox2.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(323, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Contraseña:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(320, 117);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(128, 17);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = " :Es Administrador";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(156, 84);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(127, 20);
            this.textBox3.TabIndex = 39;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(156, 55);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(127, 20);
            this.textBox4.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Segundo Apellido:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(44, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Primer Apellido:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(156, 25);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(127, 20);
            this.textBox5.TabIndex = 35;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(435, 25);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(145, 20);
            this.textBox6.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(44, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Nombre:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(323, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Nº Identificación:";
            // 
            // btnBuscarParticipante
            // 
            this.btnBuscarParticipante.Location = new System.Drawing.Point(802, 42);
            this.btnBuscarParticipante.Name = "btnBuscarParticipante";
            this.btnBuscarParticipante.Size = new System.Drawing.Size(51, 46);
            this.btnBuscarParticipante.TabIndex = 9;
            this.btnBuscarParticipante.Text = "Buscar";
            this.btnBuscarParticipante.UseVisualStyleBackColor = true;
            // 
            // btnEliminarParticipante
            // 
            this.btnEliminarParticipante.Location = new System.Drawing.Point(744, 42);
            this.btnEliminarParticipante.Name = "btnEliminarParticipante";
            this.btnEliminarParticipante.Size = new System.Drawing.Size(52, 46);
            this.btnEliminarParticipante.TabIndex = 8;
            this.btnEliminarParticipante.Text = "Eliminar";
            this.btnEliminarParticipante.UseVisualStyleBackColor = true;
            // 
            // btnActualizarParticipante
            // 
            this.btnActualizarParticipante.Location = new System.Drawing.Point(687, 40);
            this.btnActualizarParticipante.Name = "btnActualizarParticipante";
            this.btnActualizarParticipante.Size = new System.Drawing.Size(51, 48);
            this.btnActualizarParticipante.TabIndex = 7;
            this.btnActualizarParticipante.Text = "Actualizar";
            this.btnActualizarParticipante.UseVisualStyleBackColor = true;
            // 
            // btnAgregarParticipante
            // 
            this.btnAgregarParticipante.Location = new System.Drawing.Point(629, 40);
            this.btnAgregarParticipante.Name = "btnAgregarParticipante";
            this.btnAgregarParticipante.Size = new System.Drawing.Size(52, 48);
            this.btnAgregarParticipante.TabIndex = 6;
            this.btnAgregarParticipante.Text = "Agregar";
            this.btnAgregarParticipante.UseVisualStyleBackColor = true;
            // 
            // gridParticipantes
            // 
            this.gridParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridParticipantes.Location = new System.Drawing.Point(7, 153);
            this.gridParticipantes.Name = "gridParticipantes";
            this.gridParticipantes.Size = new System.Drawing.Size(864, 298);
            this.gridParticipantes.TabIndex = 5;
            // 
            // tabRutina
            // 
            this.tabRutina.Controls.Add(this.btnBuscarRutina);
            this.tabRutina.Controls.Add(this.btnEliminarRutina);
            this.tabRutina.Controls.Add(this.btnActualizarRutina);
            this.tabRutina.Controls.Add(this.btnAgregarRutina);
            this.tabRutina.Controls.Add(this.cmbDeporteRutina);
            this.tabRutina.Controls.Add(this.txtNombreRutina);
            this.tabRutina.Controls.Add(this.label3);
            this.tabRutina.Controls.Add(this.label4);
            this.tabRutina.Controls.Add(this.txtIdRutina);
            this.tabRutina.Controls.Add(this.txtDetalleRutina);
            this.tabRutina.Controls.Add(this.label1);
            this.tabRutina.Controls.Add(this.label2);
            this.tabRutina.Controls.Add(this.gridRutina);
            this.tabRutina.Location = new System.Drawing.Point(4, 22);
            this.tabRutina.Name = "tabRutina";
            this.tabRutina.Padding = new System.Windows.Forms.Padding(3);
            this.tabRutina.Size = new System.Drawing.Size(878, 467);
            this.tabRutina.TabIndex = 3;
            this.tabRutina.Text = "Rutina";
            this.tabRutina.UseVisualStyleBackColor = true;
            // 
            // btnBuscarRutina
            // 
            this.btnBuscarRutina.BackgroundImage = global::MinisterioDeportes.Properties.Resources.find;
            this.btnBuscarRutina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarRutina.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnBuscarRutina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarRutina.Location = new System.Drawing.Point(804, 56);
            this.btnBuscarRutina.Name = "btnBuscarRutina";
            this.btnBuscarRutina.Size = new System.Drawing.Size(51, 46);
            this.btnBuscarRutina.TabIndex = 40;
            this.btnBuscarRutina.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarRutina.UseVisualStyleBackColor = true;
            // 
            // btnEliminarRutina
            // 
            this.btnEliminarRutina.BackgroundImage = global::MinisterioDeportes.Properties.Resources.delete;
            this.btnEliminarRutina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminarRutina.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnEliminarRutina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarRutina.Location = new System.Drawing.Point(745, 56);
            this.btnEliminarRutina.Name = "btnEliminarRutina";
            this.btnEliminarRutina.Size = new System.Drawing.Size(53, 46);
            this.btnEliminarRutina.TabIndex = 39;
            this.btnEliminarRutina.UseVisualStyleBackColor = true;
            // 
            // btnActualizarRutina
            // 
            this.btnActualizarRutina.BackgroundImage = global::MinisterioDeportes.Properties.Resources.update;
            this.btnActualizarRutina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizarRutina.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnActualizarRutina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarRutina.Location = new System.Drawing.Point(688, 56);
            this.btnActualizarRutina.Name = "btnActualizarRutina";
            this.btnActualizarRutina.Size = new System.Drawing.Size(51, 46);
            this.btnActualizarRutina.TabIndex = 38;
            this.btnActualizarRutina.UseVisualStyleBackColor = true;
            // 
            // btnAgregarRutina
            // 
            this.btnAgregarRutina.BackColor = System.Drawing.Color.White;
            this.btnAgregarRutina.BackgroundImage = global::MinisterioDeportes.Properties.Resources.add;
            this.btnAgregarRutina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregarRutina.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnAgregarRutina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRutina.Location = new System.Drawing.Point(629, 56);
            this.btnAgregarRutina.Name = "btnAgregarRutina";
            this.btnAgregarRutina.Size = new System.Drawing.Size(53, 46);
            this.btnAgregarRutina.TabIndex = 37;
            this.btnAgregarRutina.UseVisualStyleBackColor = false;
            this.btnAgregarRutina.Click += new System.EventHandler(this.btnAgregarRutina_Click);
            // 
            // cmbDeporteRutina
            // 
            this.cmbDeporteRutina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeporteRutina.FormattingEnabled = true;
            this.cmbDeporteRutina.Location = new System.Drawing.Point(153, 56);
            this.cmbDeporteRutina.Name = "cmbDeporteRutina";
            this.cmbDeporteRutina.Size = new System.Drawing.Size(164, 21);
            this.cmbDeporteRutina.TabIndex = 32;
            // 
            // txtNombreRutina
            // 
            this.txtNombreRutina.Location = new System.Drawing.Point(153, 86);
            this.txtNombreRutina.Name = "txtNombreRutina";
            this.txtNombreRutina.Size = new System.Drawing.Size(164, 20);
            this.txtNombreRutina.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Nombre Rutina:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Deporte:";
            // 
            // txtIdRutina
            // 
            this.txtIdRutina.Location = new System.Drawing.Point(153, 27);
            this.txtIdRutina.Name = "txtIdRutina";
            this.txtIdRutina.ReadOnly = true;
            this.txtIdRutina.Size = new System.Drawing.Size(164, 20);
            this.txtIdRutina.TabIndex = 24;
            // 
            // txtDetalleRutina
            // 
            this.txtDetalleRutina.Location = new System.Drawing.Point(427, 27);
            this.txtDetalleRutina.Multiline = true;
            this.txtDetalleRutina.Name = "txtDetalleRutina";
            this.txtDetalleRutina.Size = new System.Drawing.Size(164, 79);
            this.txtDetalleRutina.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Id Rutina:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(364, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Detalles:";
            // 
            // gridRutina
            // 
            this.gridRutina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRutina.Location = new System.Drawing.Point(7, 140);
            this.gridRutina.Name = "gridRutina";
            this.gridRutina.Size = new System.Drawing.Size(864, 311);
            this.gridRutina.TabIndex = 5;
            // 
            // tabPlanDeRutina
            // 
            this.tabPlanDeRutina.Controls.Add(this.txtNombrePlan);
            this.tabPlanDeRutina.Controls.Add(this.label5);
            this.tabPlanDeRutina.Controls.Add(this.cmbRoutina);
            this.tabPlanDeRutina.Controls.Add(this.label14);
            this.tabPlanDeRutina.Controls.Add(this.txtIdPlan);
            this.tabPlanDeRutina.Controls.Add(this.txtDetallesPlan);
            this.tabPlanDeRutina.Controls.Add(this.label15);
            this.tabPlanDeRutina.Controls.Add(this.label16);
            this.tabPlanDeRutina.Controls.Add(this.gridPlanRutina);
            this.tabPlanDeRutina.Controls.Add(this.btnBuscarPlan);
            this.tabPlanDeRutina.Controls.Add(this.btnEliminarPlan);
            this.tabPlanDeRutina.Controls.Add(this.btnActualizarPlan);
            this.tabPlanDeRutina.Controls.Add(this.btnAgregarPlan);
            this.tabPlanDeRutina.Location = new System.Drawing.Point(4, 22);
            this.tabPlanDeRutina.Name = "tabPlanDeRutina";
            this.tabPlanDeRutina.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlanDeRutina.Size = new System.Drawing.Size(878, 467);
            this.tabPlanDeRutina.TabIndex = 4;
            this.tabPlanDeRutina.Text = "Plan de Rutina";
            this.tabPlanDeRutina.UseVisualStyleBackColor = true;
            // 
            // txtNombrePlan
            // 
            this.txtNombrePlan.Location = new System.Drawing.Point(143, 61);
            this.txtNombrePlan.Name = "txtNombrePlan";
            this.txtNombrePlan.Size = new System.Drawing.Size(164, 20);
            this.txtNombrePlan.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Nombre Plan:";
            // 
            // cmbRoutina
            // 
            this.cmbRoutina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoutina.FormattingEnabled = true;
            this.cmbRoutina.Location = new System.Drawing.Point(143, 93);
            this.cmbRoutina.Name = "cmbRoutina";
            this.cmbRoutina.Size = new System.Drawing.Size(164, 21);
            this.cmbRoutina.TabIndex = 44;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(31, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Rutina:";
            // 
            // txtIdPlan
            // 
            this.txtIdPlan.Location = new System.Drawing.Point(143, 31);
            this.txtIdPlan.Name = "txtIdPlan";
            this.txtIdPlan.ReadOnly = true;
            this.txtIdPlan.Size = new System.Drawing.Size(164, 20);
            this.txtIdPlan.TabIndex = 40;
            // 
            // txtDetallesPlan
            // 
            this.txtDetallesPlan.Location = new System.Drawing.Point(417, 31);
            this.txtDetallesPlan.Multiline = true;
            this.txtDetallesPlan.Name = "txtDetallesPlan";
            this.txtDetallesPlan.Size = new System.Drawing.Size(164, 83);
            this.txtDetallesPlan.TabIndex = 39;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(31, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Id Plan:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(354, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "Detalles:";
            // 
            // gridPlanRutina
            // 
            this.gridPlanRutina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPlanRutina.Location = new System.Drawing.Point(7, 145);
            this.gridPlanRutina.Name = "gridPlanRutina";
            this.gridPlanRutina.Size = new System.Drawing.Size(864, 306);
            this.gridPlanRutina.TabIndex = 5;
            // 
            // btnBuscarPlan
            // 
            this.btnBuscarPlan.BackgroundImage = global::MinisterioDeportes.Properties.Resources.find;
            this.btnBuscarPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarPlan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnBuscarPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPlan.Location = new System.Drawing.Point(806, 68);
            this.btnBuscarPlan.Name = "btnBuscarPlan";
            this.btnBuscarPlan.Size = new System.Drawing.Size(51, 46);
            this.btnBuscarPlan.TabIndex = 36;
            this.btnBuscarPlan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarPlan.UseVisualStyleBackColor = true;
            // 
            // btnEliminarPlan
            // 
            this.btnEliminarPlan.BackgroundImage = global::MinisterioDeportes.Properties.Resources.delete;
            this.btnEliminarPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminarPlan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnEliminarPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPlan.Location = new System.Drawing.Point(747, 68);
            this.btnEliminarPlan.Name = "btnEliminarPlan";
            this.btnEliminarPlan.Size = new System.Drawing.Size(53, 46);
            this.btnEliminarPlan.TabIndex = 35;
            this.btnEliminarPlan.UseVisualStyleBackColor = true;
            // 
            // btnActualizarPlan
            // 
            this.btnActualizarPlan.BackgroundImage = global::MinisterioDeportes.Properties.Resources.update;
            this.btnActualizarPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizarPlan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnActualizarPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarPlan.Location = new System.Drawing.Point(690, 68);
            this.btnActualizarPlan.Name = "btnActualizarPlan";
            this.btnActualizarPlan.Size = new System.Drawing.Size(51, 46);
            this.btnActualizarPlan.TabIndex = 34;
            this.btnActualizarPlan.UseVisualStyleBackColor = true;
            // 
            // btnAgregarPlan
            // 
            this.btnAgregarPlan.BackColor = System.Drawing.Color.White;
            this.btnAgregarPlan.BackgroundImage = global::MinisterioDeportes.Properties.Resources.add;
            this.btnAgregarPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregarPlan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(126)))), ((int)(((byte)(251)))));
            this.btnAgregarPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPlan.Location = new System.Drawing.Point(631, 68);
            this.btnAgregarPlan.Name = "btnAgregarPlan";
            this.btnAgregarPlan.Size = new System.Drawing.Size(53, 46);
            this.btnAgregarPlan.TabIndex = 33;
            this.btnAgregarPlan.UseVisualStyleBackColor = false;
            // 
            // tabEstadísticas
            // 
            this.tabEstadísticas.Controls.Add(this.chtEstadisticas);
            this.tabEstadísticas.Location = new System.Drawing.Point(4, 22);
            this.tabEstadísticas.Name = "tabEstadísticas";
            this.tabEstadísticas.Padding = new System.Windows.Forms.Padding(3);
            this.tabEstadísticas.Size = new System.Drawing.Size(878, 467);
            this.tabEstadísticas.TabIndex = 1;
            this.tabEstadísticas.Text = "Estadísticas";
            this.tabEstadísticas.UseVisualStyleBackColor = true;
            // 
            // chtEstadisticas
            // 
            chartArea1.Name = "ChartArea1";
            this.chtEstadisticas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtEstadisticas.Legends.Add(legend1);
            this.chtEstadisticas.Location = new System.Drawing.Point(170, 44);
            this.chtEstadisticas.Name = "chtEstadisticas";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtEstadisticas.Series.Add(series1);
            this.chtEstadisticas.Size = new System.Drawing.Size(614, 396);
            this.chtEstadisticas.TabIndex = 0;
            this.chtEstadisticas.Text = "chart1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 517);
            this.Controls.Add(this.tbcDashboard);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.tbcDashboard.ResumeLayout(false);
            this.tabDeportes.ResumeLayout(false);
            this.tabDeportes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTablaDeportes)).EndInit();
            this.tabParticipantes.ResumeLayout(false);
            this.tabParticipantes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridParticipantes)).EndInit();
            this.tabRutina.ResumeLayout(false);
            this.tabRutina.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRutina)).EndInit();
            this.tabPlanDeRutina.ResumeLayout(false);
            this.tabPlanDeRutina.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanRutina)).EndInit();
            this.tabEstadísticas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtEstadisticas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcDashboard;
        private System.Windows.Forms.TabPage tabDeportes;
        private System.Windows.Forms.DataGridView gridTablaDeportes;
        private System.Windows.Forms.TabPage tabEstadísticas;
        private System.Windows.Forms.TabPage tabParticipantes;
        private System.Windows.Forms.TabPage tabRutina;
        private System.Windows.Forms.TabPage tabPlanDeRutina;
        private System.Windows.Forms.Button btnBuscarParticipante;
        private System.Windows.Forms.Button btnEliminarParticipante;
        private System.Windows.Forms.Button btnActualizarParticipante;
        private System.Windows.Forms.Button btnAgregarParticipante;
        private System.Windows.Forms.DataGridView gridParticipantes;
        private System.Windows.Forms.DataGridView gridRutina;
        private System.Windows.Forms.DataGridView gridPlanRutina;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNombreRutina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdRutina;
        private System.Windows.Forms.TextBox txtDetalleRutina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreDeporte;
        private System.Windows.Forms.TextBox txtIdDeporte;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbDeporteRutina;
        private System.Windows.Forms.ComboBox cmbRoutina;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtIdPlan;
        private System.Windows.Forms.TextBox txtDetallesPlan;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnBuscarPlan;
        private System.Windows.Forms.Button btnEliminarPlan;
        private System.Windows.Forms.Button btnActualizarPlan;
        private System.Windows.Forms.Button btnAgregarPlan;
        private System.Windows.Forms.TextBox txtNombrePlan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtEstadisticas;
        private System.Windows.Forms.Button btnBuscarDeporte;
        private System.Windows.Forms.Button btnEliminarDeporte;
        private System.Windows.Forms.Button btnActualizarDeporte;
        private System.Windows.Forms.Button btnAgregarDeporte;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnBuscarRutina;
        private System.Windows.Forms.Button btnEliminarRutina;
        private System.Windows.Forms.Button btnActualizarRutina;
        private System.Windows.Forms.Button btnAgregarRutina;
    }
}