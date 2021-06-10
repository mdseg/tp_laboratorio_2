using Entidades;
using Entidades.Exceptions;
using Entidades.Logger;
using Entidades.Reportes;
using Files;
using Files.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaProyecto
{
    public partial class FormPrincipal : Form
    {
        public static Fabrica fabricaSingleton;
        FabricaXmlService serviceXmlFabrica;
        Logger logger;

        private Form currentChildForm;

        public FormPrincipal()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fabricaSingleton = Fabrica.Instance;
            logger = new Logger(AppDomain.CurrentDomain.BaseDirectory + "Logging.txt");
            serviceXmlFabrica = new FabricaXmlService(AppDomain.CurrentDomain.BaseDirectory);


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
            OpenChildForm(new FormProductosTerminados());
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void iBFabrica_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormFabrica());
        }


        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿ Desea Salir de la Aplicacion?",
                      "Salir de Aplicacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogo != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void iBSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iBCargar_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿ Desea cargar los datos? Todo cambio no guardado se perderá",
                     "Cargar datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogo == DialogResult.OK)
            {
                try
                {
                    fabricaSingleton = serviceXmlFabrica.ReadXmlFabrica();
                    MessageBox.Show("Datos cargados correctamente", "Cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!(currentChildForm is null) && currentChildForm.Visible)
                    {
                        currentChildForm.Close();
                    }
                }
                catch (ReadFactoryException ex)
                {
                    MessageBox.Show("Hubo errores al abrir los archivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.saveReport(ex);
                }
               

       
            }


        }

        private void iBGuardarDatos_Click(object sender, EventArgs e)
        {

            DialogResult dialogo = MessageBox.Show("¿ Desea guardar la información actual?",
                     "Guardar datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogo == DialogResult.OK)
            {
                try
                {
                    serviceXmlFabrica.SaveXmlFabrica(fabricaSingleton);
                    MessageBox.Show("Datos guardados correctamente","Guardar datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FabricaReporte fs = new FabricaReporte();
                    fs.CrearReporte(AppDomain.CurrentDomain.BaseDirectory, fabricaSingleton);
                }
                catch (SaveFactoryException ex)
                {
                    MessageBox.Show("Hubo errores al guardar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.saveReport(ex);
                }
            }
        }
    }
}
