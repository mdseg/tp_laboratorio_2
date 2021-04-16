
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;




namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        Numero numeroUno;
        Numero numeroDos;
        string operador;
        double resultado = 0;
        /// <summary>
        /// Constructor por defecto que inicializa el formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// metodo que carga el formulario asignandole valores a los label y los textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
        }
        /// <summary>
        /// Consulta si se quiere cerrar la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que quiere cerrar el programa? ", "Cierre de aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }
        /// <summary>
        /// Llama a los métodos que validan los input para luego realizar las operaciones.
        /// En caso de éxito se mostrará el valor por el lblResultado. De no pasar la validación
        /// o en el caso de la división por cero se emitira el mensjae de error por un MessageBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string inputTxtUno = txtNumero1.Text;
            string inputTxtDos = txtNumero2.Text;                
            numeroUno = new Numero(txtNumero1.Text);
            numeroDos = new Numero(txtNumero2.Text);
            operador = cmbOperador.Text;
            resultado = Calculadora.Operar(numeroUno, numeroDos, operador);
                
            /* Como el resultado de la división por cero retorna minValue lo cual genera
            un valor que puede dar lugar a confusión, decidí enviar una ventana que le indica
            al usuario que no se puede dividir por cero.

            */
            if (operador.Equals("/") && resultado.Equals(Double.MinValue))
            {
                MessageBox.Show("No se puede dividir por cero.");
            }
            else
            {               
                lblResultado.Text = resultado.ToString();
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
                if(!lblResultado.Visible)
                {
                    lblResultado.Visible = true;
                }

            }           
        }
        /// <summary>
        /// Limpia los campos de input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            lblResultado.Text = "";
            cmbOperador.Items.Clear();
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }
        /// <summary>
        /// Convierte el valor mostrado en lblResultado y lo convierte en un
        /// string binario para luego mostrarlos por el mismo label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = Numero.DecimalBinario(lblResultado.Text);
            lblResultado.Text = resultado;
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
        }
        /// <summary>
        /// Convierte el valor mostrado en lblResultado y lo convierte en un
        /// string decimal tomando los datos del label como binario para luego mostrarlos por el mismo label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado = Numero.BinarioDecimal(lblResultado.Text);
            lblResultado.Text = resultado;
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }
        /// <summary>
        /// Consulta si se quiere cerrar la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }
    }
}
