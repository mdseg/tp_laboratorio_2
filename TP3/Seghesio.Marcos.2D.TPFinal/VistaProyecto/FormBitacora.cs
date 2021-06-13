using Entidades.Logger;
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
    public partial class FormBitacora : Form
    {
        private Logger logger;

        public FormBitacora(Logger logger)
        {
            this.logger = logger;
            InitializeComponent();
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            string textoLogger = logger.readReport();
            richTextBoxBitacora.Text = textoLogger;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
