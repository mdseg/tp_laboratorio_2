
namespace VistaProyecto
{
    partial class FormProductosTerminados
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProductosTerminados = new System.Windows.Forms.Label();
            this.dgProductosTerminados = new System.Windows.Forms.DataGridView();
            this.lblProductosTerminadosVacio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductosTerminados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 78);
            this.panel1.TabIndex = 16;
            // 
            // lblProductosTerminados
            // 
            this.lblProductosTerminados.AutoSize = true;
            this.lblProductosTerminados.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductosTerminados.Location = new System.Drawing.Point(30, 107);
            this.lblProductosTerminados.Name = "lblProductosTerminados";
            this.lblProductosTerminados.Size = new System.Drawing.Size(91, 29);
            this.lblProductosTerminados.TabIndex = 17;
            this.lblProductosTerminados.Text = "Listado";
            // 
            // dgProductosTerminados
            // 
            this.dgProductosTerminados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProductosTerminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductosTerminados.Location = new System.Drawing.Point(35, 159);
            this.dgProductosTerminados.Name = "dgProductosTerminados";
            this.dgProductosTerminados.Size = new System.Drawing.Size(927, 168);
            this.dgProductosTerminados.TabIndex = 18;
            // 
            // lblProductosTerminadosVacio
            // 
            this.lblProductosTerminadosVacio.AutoSize = true;
            this.lblProductosTerminadosVacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductosTerminadosVacio.Location = new System.Drawing.Point(101, 213);
            this.lblProductosTerminadosVacio.Name = "lblProductosTerminadosVacio";
            this.lblProductosTerminadosVacio.Size = new System.Drawing.Size(265, 24);
            this.lblProductosTerminadosVacio.TabIndex = 19;
            this.lblProductosTerminadosVacio.Text = "No hay productos Terminados";
            this.lblProductosTerminadosVacio.Visible = false;
            // 
            // FormProductosTerminados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 564);
            this.Controls.Add(this.lblProductosTerminadosVacio);
            this.Controls.Add(this.dgProductosTerminados);
            this.Controls.Add(this.lblProductosTerminados);
            this.Controls.Add(this.panel1);
            this.Name = "FormProductosTerminados";
            this.Text = "Productos Terminados";
            ((System.ComponentModel.ISupportInitialize)(this.dgProductosTerminados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProductosTerminados;
        private System.Windows.Forms.DataGridView dgProductosTerminados;
        private System.Windows.Forms.Label lblProductosTerminadosVacio;
    }
}