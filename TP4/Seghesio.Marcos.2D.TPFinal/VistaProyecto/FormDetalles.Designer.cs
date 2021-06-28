
namespace VistaProyecto
{
    partial class FormDetalles
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
            this.dgLineaProduccion = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnEjecutarProceso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgLineaProduccion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLineaProduccion
            // 
            this.dgLineaProduccion.AllowUserToAddRows = false;
            this.dgLineaProduccion.AllowUserToDeleteRows = false;
            this.dgLineaProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLineaProduccion.Location = new System.Drawing.Point(41, 100);
            this.dgLineaProduccion.Name = "dgLineaProduccion";
            this.dgLineaProduccion.ReadOnly = true;
            this.dgLineaProduccion.Size = new System.Drawing.Size(809, 150);
            this.dgLineaProduccion.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(41, 58);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(342, 24);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Listados de productos disponibles para ";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(41, 277);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(153, 31);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnEjecutarProceso
            // 
            this.btnEjecutarProceso.Location = new System.Drawing.Point(220, 277);
            this.btnEjecutarProceso.Name = "btnEjecutarProceso";
            this.btnEjecutarProceso.Size = new System.Drawing.Size(153, 31);
            this.btnEjecutarProceso.TabIndex = 3;
            this.btnEjecutarProceso.Text = "Ejecutar Proceso";
            this.btnEjecutarProceso.UseVisualStyleBackColor = true;
            this.btnEjecutarProceso.Click += new System.EventHandler(this.btnEjecutarProceso_Click);
            // 
            // FormDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 476);
            this.Controls.Add(this.btnEjecutarProceso);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgLineaProduccion);
            this.Name = "FormDetalles";
            this.Text = "FormDetalles";
            this.Load += new System.EventHandler(this.FormDetalles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLineaProduccion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgLineaProduccion;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnEjecutarProceso;
    }
}