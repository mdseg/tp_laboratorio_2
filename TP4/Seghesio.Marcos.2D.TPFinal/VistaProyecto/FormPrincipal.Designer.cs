
namespace VistaProyecto
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.panelLateralIzquierdo = new System.Windows.Forms.Panel();
            this.iBLogger = new FontAwesome.Sharp.IconButton();
            this.iBGenerarReporte = new FontAwesome.Sharp.IconButton();
            this.iBGuardarDatos = new FontAwesome.Sharp.IconButton();
            this.iBCargar = new FontAwesome.Sharp.IconButton();
            this.iBSalir = new FontAwesome.Sharp.IconButton();
            this.iBProductosTerminados = new FontAwesome.Sharp.IconButton();
            this.iBFabrica = new FontAwesome.Sharp.IconButton();
            this.iBInsumos = new FontAwesome.Sharp.IconButton();
            this.panelTopIzq = new System.Windows.Forms.Panel();
            this.pBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelLateralIzquierdo.SuspendLayout();
            this.panelTopIzq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogo)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLateralIzquierdo
            // 
            this.panelLateralIzquierdo.BackColor = System.Drawing.Color.DarkCyan;
            this.panelLateralIzquierdo.Controls.Add(this.iBLogger);
            this.panelLateralIzquierdo.Controls.Add(this.iBGenerarReporte);
            this.panelLateralIzquierdo.Controls.Add(this.iBGuardarDatos);
            this.panelLateralIzquierdo.Controls.Add(this.iBCargar);
            this.panelLateralIzquierdo.Controls.Add(this.iBSalir);
            this.panelLateralIzquierdo.Controls.Add(this.iBProductosTerminados);
            this.panelLateralIzquierdo.Controls.Add(this.iBFabrica);
            this.panelLateralIzquierdo.Controls.Add(this.iBInsumos);
            this.panelLateralIzquierdo.Controls.Add(this.panelTopIzq);
            this.panelLateralIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateralIzquierdo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.panelLateralIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.panelLateralIzquierdo.Name = "panelLateralIzquierdo";
            this.panelLateralIzquierdo.Size = new System.Drawing.Size(180, 761);
            this.panelLateralIzquierdo.TabIndex = 2;
            // 
            // iBLogger
            // 
            this.iBLogger.Dock = System.Windows.Forms.DockStyle.Top;
            this.iBLogger.FlatAppearance.BorderSize = 0;
            this.iBLogger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBLogger.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBLogger.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            this.iBLogger.IconColor = System.Drawing.Color.Snow;
            this.iBLogger.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBLogger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBLogger.Location = new System.Drawing.Point(0, 556);
            this.iBLogger.Name = "iBLogger";
            this.iBLogger.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBLogger.Size = new System.Drawing.Size(180, 70);
            this.iBLogger.TabIndex = 8;
            this.iBLogger.Text = "Bitácora";
            this.iBLogger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBLogger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBLogger.UseVisualStyleBackColor = true;
            this.iBLogger.Click += new System.EventHandler(this.iBLogger_Click);
            // 
            // iBGenerarReporte
            // 
            this.iBGenerarReporte.Dock = System.Windows.Forms.DockStyle.Top;
            this.iBGenerarReporte.FlatAppearance.BorderSize = 0;
            this.iBGenerarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBGenerarReporte.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBGenerarReporte.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.iBGenerarReporte.IconColor = System.Drawing.Color.Snow;
            this.iBGenerarReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBGenerarReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBGenerarReporte.Location = new System.Drawing.Point(0, 486);
            this.iBGenerarReporte.Name = "iBGenerarReporte";
            this.iBGenerarReporte.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBGenerarReporte.Size = new System.Drawing.Size(180, 70);
            this.iBGenerarReporte.TabIndex = 7;
            this.iBGenerarReporte.Text = "Generar Reporte";
            this.iBGenerarReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBGenerarReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBGenerarReporte.UseVisualStyleBackColor = true;
            this.iBGenerarReporte.Click += new System.EventHandler(this.iBGenerarReporte_Click);
            // 
            // iBGuardarDatos
            // 
            this.iBGuardarDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.iBGuardarDatos.FlatAppearance.BorderSize = 0;
            this.iBGuardarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBGuardarDatos.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBGuardarDatos.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.iBGuardarDatos.IconColor = System.Drawing.Color.Snow;
            this.iBGuardarDatos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBGuardarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBGuardarDatos.Location = new System.Drawing.Point(0, 416);
            this.iBGuardarDatos.Name = "iBGuardarDatos";
            this.iBGuardarDatos.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBGuardarDatos.Size = new System.Drawing.Size(180, 70);
            this.iBGuardarDatos.TabIndex = 6;
            this.iBGuardarDatos.Text = "Guardar Datos";
            this.iBGuardarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBGuardarDatos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBGuardarDatos.UseVisualStyleBackColor = true;
            this.iBGuardarDatos.Click += new System.EventHandler(this.iBGuardarDatos_Click);
            // 
            // iBCargar
            // 
            this.iBCargar.Dock = System.Windows.Forms.DockStyle.Top;
            this.iBCargar.FlatAppearance.BorderSize = 0;
            this.iBCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBCargar.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBCargar.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.iBCargar.IconColor = System.Drawing.Color.Snow;
            this.iBCargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBCargar.Location = new System.Drawing.Point(0, 346);
            this.iBCargar.Name = "iBCargar";
            this.iBCargar.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBCargar.Size = new System.Drawing.Size(180, 70);
            this.iBCargar.TabIndex = 5;
            this.iBCargar.Text = "Cargar Datos";
            this.iBCargar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBCargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBCargar.UseVisualStyleBackColor = true;
            this.iBCargar.Click += new System.EventHandler(this.iBCargar_Click);
            // 
            // iBSalir
            // 
            this.iBSalir.FlatAppearance.BorderSize = 0;
            this.iBSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBSalir.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBSalir.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.iBSalir.IconColor = System.Drawing.Color.Snow;
            this.iBSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBSalir.Location = new System.Drawing.Point(3, 651);
            this.iBSalir.Name = "iBSalir";
            this.iBSalir.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBSalir.Size = new System.Drawing.Size(180, 70);
            this.iBSalir.TabIndex = 4;
            this.iBSalir.Text = "Salir";
            this.iBSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBSalir.UseVisualStyleBackColor = true;
            this.iBSalir.Click += new System.EventHandler(this.iBSalir_Click);
            // 
            // iBProductosTerminados
            // 
            this.iBProductosTerminados.Dock = System.Windows.Forms.DockStyle.Top;
            this.iBProductosTerminados.FlatAppearance.BorderSize = 0;
            this.iBProductosTerminados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBProductosTerminados.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBProductosTerminados.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.iBProductosTerminados.IconColor = System.Drawing.Color.Snow;
            this.iBProductosTerminados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBProductosTerminados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBProductosTerminados.Location = new System.Drawing.Point(0, 276);
            this.iBProductosTerminados.Name = "iBProductosTerminados";
            this.iBProductosTerminados.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBProductosTerminados.Size = new System.Drawing.Size(180, 70);
            this.iBProductosTerminados.TabIndex = 3;
            this.iBProductosTerminados.Text = "Productos Terminados";
            this.iBProductosTerminados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBProductosTerminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBProductosTerminados.UseVisualStyleBackColor = true;
            this.iBProductosTerminados.Click += new System.EventHandler(this.iBProductosTerminados_Click);
            // 
            // iBFabrica
            // 
            this.iBFabrica.Dock = System.Windows.Forms.DockStyle.Top;
            this.iBFabrica.FlatAppearance.BorderSize = 0;
            this.iBFabrica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBFabrica.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBFabrica.IconChar = FontAwesome.Sharp.IconChar.Industry;
            this.iBFabrica.IconColor = System.Drawing.Color.Snow;
            this.iBFabrica.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBFabrica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBFabrica.Location = new System.Drawing.Point(0, 206);
            this.iBFabrica.Name = "iBFabrica";
            this.iBFabrica.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBFabrica.Size = new System.Drawing.Size(180, 70);
            this.iBFabrica.TabIndex = 2;
            this.iBFabrica.Text = "Fabrica";
            this.iBFabrica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBFabrica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBFabrica.UseVisualStyleBackColor = true;
            this.iBFabrica.Click += new System.EventHandler(this.iBFabrica_Click);
            // 
            // iBInsumos
            // 
            this.iBInsumos.Dock = System.Windows.Forms.DockStyle.Top;
            this.iBInsumos.FlatAppearance.BorderSize = 0;
            this.iBInsumos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBInsumos.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBInsumos.IconChar = FontAwesome.Sharp.IconChar.Leaf;
            this.iBInsumos.IconColor = System.Drawing.Color.Snow;
            this.iBInsumos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBInsumos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBInsumos.Location = new System.Drawing.Point(0, 136);
            this.iBInsumos.Name = "iBInsumos";
            this.iBInsumos.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBInsumos.Size = new System.Drawing.Size(180, 70);
            this.iBInsumos.TabIndex = 1;
            this.iBInsumos.Text = "Insumos";
            this.iBInsumos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBInsumos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBInsumos.UseVisualStyleBackColor = true;
            this.iBInsumos.Click += new System.EventHandler(this.iBInsumos_Click);
            // 
            // panelTopIzq
            // 
            this.panelTopIzq.Controls.Add(this.pBoxLogo);
            this.panelTopIzq.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopIzq.Location = new System.Drawing.Point(0, 0);
            this.panelTopIzq.Name = "panelTopIzq";
            this.panelTopIzq.Size = new System.Drawing.Size(180, 136);
            this.panelTopIzq.TabIndex = 0;
            // 
            // pBoxLogo
            // 
            this.pBoxLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxLogo.BackgroundImage")));
            this.pBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBoxLogo.Location = new System.Drawing.Point(12, 6);
            this.pBoxLogo.Name = "pBoxLogo";
            this.pBoxLogo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pBoxLogo.Size = new System.Drawing.Size(146, 114);
            this.pBoxLogo.TabIndex = 0;
            this.pBoxLogo.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.DarkCyan;
            this.panelTop.Controls.Add(this.lblTitleChildForm);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(180, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1104, 71);
            this.panelTop.TabIndex = 3;
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lblTitleChildForm.Location = new System.Drawing.Point(0, 0);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.lblTitleChildForm.Size = new System.Drawing.Size(160, 65);
            this.lblTitleChildForm.TabIndex = 0;
            this.lblTitleChildForm.Text = "Titulo";
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.White;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(180, 71);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1104, 690);
            this.panelDesktop.TabIndex = 4;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLateralIzquierdo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panelLateralIzquierdo.ResumeLayout(false);
            this.panelTopIzq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogo)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLateralIzquierdo;
        private FontAwesome.Sharp.IconButton iBProductosTerminados;
        private FontAwesome.Sharp.IconButton iBFabrica;
        private FontAwesome.Sharp.IconButton iBInsumos;
        private System.Windows.Forms.Panel panelTopIzq;
        private System.Windows.Forms.PictureBox pBoxLogo;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Label lblTitleChildForm;
        private FontAwesome.Sharp.IconButton iBSalir;
        private FontAwesome.Sharp.IconButton iBGuardarDatos;
        private FontAwesome.Sharp.IconButton iBCargar;
        private FontAwesome.Sharp.IconButton iBGenerarReporte;
        private FontAwesome.Sharp.IconButton iBLogger;
    }
}

