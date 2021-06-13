
namespace VistaProyecto
{
    partial class FormBitacora
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
            this.richTextBoxBitacora = new System.Windows.Forms.RichTextBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblBitacora = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxBitacora
            // 
            this.richTextBoxBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxBitacora.Location = new System.Drawing.Point(67, 166);
            this.richTextBoxBitacora.Name = "richTextBoxBitacora";
            this.richTextBoxBitacora.Size = new System.Drawing.Size(721, 259);
            this.richTextBoxBitacora.TabIndex = 1;
            this.richTextBoxBitacora.Text = "";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 78);
            this.panelTop.TabIndex = 30;
            // 
            // lblBitacora
            // 
            this.lblBitacora.AutoSize = true;
            this.lblBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBitacora.Location = new System.Drawing.Point(61, 119);
            this.lblBitacora.Name = "lblBitacora";
            this.lblBitacora.Size = new System.Drawing.Size(244, 31);
            this.lblBitacora.TabIndex = 31;
            this.lblBitacora.Text = "Bitacora de errores";
            this.lblBitacora.Click += new System.EventHandler(this.label1_Click);
            // 
            // FormBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblBitacora);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.richTextBoxBitacora);
            this.Name = "FormBitacora";
            this.Text = "Bitacora";
            this.Load += new System.EventHandler(this.FormBitacora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxBitacora;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblBitacora;
    }
}