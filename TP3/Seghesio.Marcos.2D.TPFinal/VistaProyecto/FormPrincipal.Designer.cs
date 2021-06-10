
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.iBGuardarDatos = new FontAwesome.Sharp.IconButton();
            this.iBCargar = new FontAwesome.Sharp.IconButton();
            this.iBSalir = new FontAwesome.Sharp.IconButton();
            this.iBProductosTerminados = new FontAwesome.Sharp.IconButton();
            this.iBFabrica = new FontAwesome.Sharp.IconButton();
            this.iBInsumos = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.iBGuardarDatos);
            this.panel1.Controls.Add(this.iBCargar);
            this.panel1.Controls.Add(this.iBSalir);
            this.panel1.Controls.Add(this.iBProductosTerminados);
            this.panel1.Controls.Add(this.iBFabrica);
            this.panel1.Controls.Add(this.iBInsumos);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 664);
            this.panel1.TabIndex = 2;
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
            this.iBGuardarDatos.Location = new System.Drawing.Point(0, 400);
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
            this.iBCargar.Location = new System.Drawing.Point(0, 330);
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
            this.iBSalir.Location = new System.Drawing.Point(-3, 547);
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
            this.iBProductosTerminados.Location = new System.Drawing.Point(0, 260);
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
            this.iBFabrica.Location = new System.Drawing.Point(0, 190);
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
            this.iBInsumos.Location = new System.Drawing.Point(0, 120);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 120);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pictureBox1.Size = new System.Drawing.Size(147, 114);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkCyan;
            this.panel3.Controls.Add(this.lblTitleChildForm);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(180, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1059, 71);
            this.panel3.TabIndex = 3;
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
            this.panelDesktop.BackColor = System.Drawing.Color.Aquamarine;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(180, 71);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1059, 593);
            this.panelDesktop.TabIndex = 4;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 664);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iBProductosTerminados;
        private FontAwesome.Sharp.IconButton iBFabrica;
        private FontAwesome.Sharp.IconButton iBInsumos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Label lblTitleChildForm;
        private FontAwesome.Sharp.IconButton iBSalir;
        private FontAwesome.Sharp.IconButton iBGuardarDatos;
        private FontAwesome.Sharp.IconButton iBCargar;
    }
}

