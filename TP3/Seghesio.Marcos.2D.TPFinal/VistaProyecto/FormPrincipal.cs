using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaProyecto
{
    public partial class FormPrincipal : Form
    {
        public static Fabrica fabricaSingleton;

        private Form currentChildForm;

        public FormPrincipal()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fabricaSingleton = Fabrica.Instance;
        }

        private void OpenChildForm(Form childForm)
        {
            if(this.currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }



        private void iBInsumos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormInsumo());
        }

        private void iBProductosTerminados_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iBFabrica_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormFabrica());
        }
    }
}
