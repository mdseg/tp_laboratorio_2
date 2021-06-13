﻿using Entidades;
using Entidades.Exceptions;
using Entidades.Logger;
using Entidades.Reportes;
using Files;
using Files.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private static Fabrica fabricaSingleton;
        private FabricaXmlService serviceXmlFabrica;
        private Logger logger;

        private Form currentChildForm;

        public FormPrincipal()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Método encargado de cargar la unica instancia de la clase Fabrica, ejecutar el logger donde se guardaran las Excepciones al leer y guardar archivos,
        /// además del serviceXml para leer y abrir los datos de fábrica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            fabricaSingleton = Fabrica.Instance;
            logger = new Logger(AppDomain.CurrentDomain.BaseDirectory + "Logging.txt");
            serviceXmlFabrica = new FabricaXmlService(AppDomain.CurrentDomain.BaseDirectory);
            OpenChildForm(new FormIntro());


        }
        /// <summary>
        /// Método encargado de gestionar los formularios hijos y anexarlos dentro del FormPrincipal
        /// </summary>
        /// <param name="childForm"></param>
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


        /// <summary>
        /// Crea una instancia de FormInsumo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBInsumos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormInsumo(fabricaSingleton));
        }
        /// <summary>
        /// Crea una instancia de FormProductosTerminados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBProductosTerminados_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormProductosTerminados(fabricaSingleton));
        }
        /// <summary>
        /// Crea una instancia de FormFabrica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBFabrica_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormFabrica(fabricaSingleton));
        }

        /// <summary>
        /// Método que consulta antes de cerrar la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿ Desea Salir de la Aplicacion?",
                      "Salir de Aplicacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogo != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Salir de la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Método que permite cargar los datos del archivo Xml e informar de los eventuales errores al leer archivos que pudieran surgir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        OpenChildForm(new FormIntro());
                    }
                }
                catch (ReadFactoryException ex)
                {
                    MessageBox.Show("Hubo errores al abrir los archivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.saveReport(ex);
                }
               

       
            }


        }
        /// <summary>
        /// Método que permite guardar los datos en un archivo Xml e informar de los eventuales errores al leer archivos que pudieran surgir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                }

                catch (SaveFactoryException ex)
                {
                    MessageBox.Show("Hubo errores al guardar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.saveReport(ex);
                }
            }
        }

        /// <summary>
        /// Genera un reporte de los campos de fábrica e informa de los resultados de la creación de este archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                FabricaReporte fs = new FabricaReporte();
                fs.CrearReporte($"{AppDomain.CurrentDomain.BaseDirectory}reporte.pdf", fabricaSingleton);
                Process.Start($"{AppDomain.CurrentDomain.BaseDirectory}reporte.pdf");
            }
            catch (SavePdfException ex)
            {
                MessageBox.Show("Hubo errores al crear el Pdf del reporte. Verifique que no tenga un reporte abierto actualmente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.saveReport(ex);
            }

        }
        /// <summary>
        /// Abre el formulario de Bitacora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBLogger_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormBitacora(logger));
        }
    }
}
