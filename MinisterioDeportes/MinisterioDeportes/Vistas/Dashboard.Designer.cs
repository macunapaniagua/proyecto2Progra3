namespace MinisterioDeportes.Vistas
{
    partial class Dashboard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rutinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planRutinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.participatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splPrincipal = new System.Windows.Forms.SplitContainer();
            this.dtgInformacion = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splPrincipal)).BeginInit();
            this.splPrincipal.Panel2.SuspendLayout();
            this.splPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInformacion)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rutinasToolStripMenuItem,
            this.planRutinaToolStripMenuItem,
            this.participatesToolStripMenuItem,
            this.deportesToolStripMenuItem,
            this.estadisticasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(765, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "mstrPrincipal";
            // 
            // rutinasToolStripMenuItem
            // 
            this.rutinasToolStripMenuItem.Name = "rutinasToolStripMenuItem";
            this.rutinasToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.rutinasToolStripMenuItem.Text = "Rutinas";
            // 
            // planRutinaToolStripMenuItem
            // 
            this.planRutinaToolStripMenuItem.Name = "planRutinaToolStripMenuItem";
            this.planRutinaToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.planRutinaToolStripMenuItem.Text = "Plan Rutina";
            // 
            // participatesToolStripMenuItem
            // 
            this.participatesToolStripMenuItem.Name = "participatesToolStripMenuItem";
            this.participatesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.participatesToolStripMenuItem.Text = "Participates";
            // 
            // deportesToolStripMenuItem
            // 
            this.deportesToolStripMenuItem.Name = "deportesToolStripMenuItem";
            this.deportesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.deportesToolStripMenuItem.Text = "Deportes";
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            // 
            // splPrincipal
            // 
            this.splPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splPrincipal.Location = new System.Drawing.Point(0, 24);
            this.splPrincipal.Name = "splPrincipal";
            // 
            // splPrincipal.Panel2
            // 
            this.splPrincipal.Panel2.Controls.Add(this.dtgInformacion);
            this.splPrincipal.Size = new System.Drawing.Size(765, 493);
            this.splPrincipal.SplitterDistance = 255;
            this.splPrincipal.TabIndex = 1;
            // 
            // dtgInformacion
            // 
            this.dtgInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInformacion.Location = new System.Drawing.Point(1, 51);
            this.dtgInformacion.Name = "dtgInformacion";
            this.dtgInformacion.Size = new System.Drawing.Size(503, 269);
            this.dtgInformacion.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 517);
            this.Controls.Add(this.splPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.Text = "Ministerio de Deportes";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splPrincipal)).EndInit();
            this.splPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInformacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rutinasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planRutinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem participatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splPrincipal;
        private System.Windows.Forms.DataGridView dtgInformacion;
    }
}