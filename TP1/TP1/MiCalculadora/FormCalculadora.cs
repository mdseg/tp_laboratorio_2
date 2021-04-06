
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
        double resultado;

        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {

            cmbOperador.SelectedIndex = 0;
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";

        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que quiere cerrar el programa? ", "cerrando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;

        }



        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            
            

            
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {

            if(!(System.Text.RegularExpressions.Regex.IsMatch(txtNumero1.Text, @"[-]?[0-9]*\.?,?[0-9]+")))
            {
                MessageBox.Show("Error");
            }

            /*
            if (!(System.Text.RegularExpressions.Regex.IsMatch(txtNumero1.Text, @"/(^[\+]?\d+[,]?\d+$)|(^[-]?\d+[,]?\d+$)|(^\d+[,]?\d+$)|(^[0-9\ ]+$)/gm")) || !(System.Text.RegularExpressions.Regex.IsMatch(txtNumero2.Text, @"/(^[\+]?\d+[,]?\d+$)|(^[-]?\d+[,]?\d+$)|(^\d+[,]?\d+$)|(^[0-9\ ]+$)/gm")))
            {
                MessageBox.Show("Por favor, ingrese sólo números (puede usar el punto '.' si desea ingresar decimales");
            }
            */
            /*
            bool prueba = System.Text.RegularExpressions.Regex.IsMatch("0", @"/(^[\+]?\d+[,]?\d+$)|(^[-]?\d+[,]?\d+$)|(^\d+[,]?\d+$)|(^[0-9\ ]+$)/gm");

            if (!(System.Text.RegularExpressions.Regex.IsMatch(txtNumero1.Text, @"/(^[\+]?\d+[,]?\d+$)|(^[-]?\d+[,]?\d+$)|(^\d+[,]?\d+$)|(^[0-9\ ]+$)/gm")))
            {
                MessageBox.Show("Por favor, ingrese sólo números (puede usar el punto '.' si desea ingresar decimales");
                // mandar a hacer operacion
                // mostrar en el label
            }*/
            //Tomar los datos
            numeroUno = new Numero(txtNumero1.Text);
            numeroDos = new Numero(txtNumero2.Text);
            /*
            string numeroStringUno = txtNumero1.Text;
            string numeroStringDos = txtNumero2.Text;
            numeroUno.setNumero(numeroStringUno);
            numeroDos.setNumero(numeroStringDos);
            */




            operador = cmbOperador.Text;
            resultado = Calculadora.Operar(numeroUno, numeroDos, operador);
            if (operador.Equals("/") && resultado.Equals(Double.MinValue))
            {
                MessageBox.Show("No se puede dividir por cero.");

            }
            else
            {
                lblResultado.Text = Math.Round(resultado,2).ToString();
            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
        }

        private int VerificarCampos()
        {
            int output = 0;
            if (!(System.Text.RegularExpressions.Regex.IsMatch(txtNumero1.Text, @"/(^[\+]?\d+[,]?\d+$)|(^[-]?\d+[,]?\d+$)|(^\d+[,]?\d+$)|(^[0-9\ ]+$)/gm")) || !(System.Text.RegularExpressions.Regex.IsMatch(txtNumero2.Text, @"/(^[\+]?\d+[,]?\d+$)|(^[-]?\d+[,]?\d+$)|(^\d+[,]?\d+$)|(^[0-9\ ]+$)/gm")))
            {
                output = -1;
            }
            else if(cmbOperador.SelectedIndex == 3 && txtNumero2.Text == "0")
            {
                output = -2;
            }
            return output;

        }

    }
}
