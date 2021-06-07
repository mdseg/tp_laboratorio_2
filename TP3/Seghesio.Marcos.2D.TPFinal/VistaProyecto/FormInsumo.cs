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
using static Entidades.Torre;

namespace VistaProyecto
{
    public partial class FormInsumo : Form
    {
        public Insumo bufferInsumo;
        
        public FormInsumo()
        {
            InitializeComponent();

            rbMadera.Checked = true;
            rbTablon.Checked = true;
            rbBarniz.Checked = true;
            cmbColorTela.DataSource = Enum.GetValues(typeof(EColor));
            cmbTipoTela.DataSource = Enum.GetValues(typeof(ETipoTela));
            cmbTipoMadera.DataSource = Enum.GetValues(typeof(ETipoMadera));
            tabControlInsumos.SelectedTab = tabPageListadoInsumos;
            ActualizarListaInsumos();
        }


        private void FormFabrica_Load(object sender, EventArgs e)
        {

        }     

        private void iBInsumos_Click(object sender, EventArgs e)
        {
            ActualizarListaInsumos();
            tabControlInsumos.SelectedTab = tabPageListadoInsumos;
        }

        private void iBAgregarInsumo_Click(object sender, EventArgs e)
        {
            tabControlInsumos.SelectedTab = tabPageAgregarInsumo;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

            if(rbMadera.Checked)
            {
                EForma formaMadera;
                if(rbTablon.Checked)
                {
                    formaMadera = EForma.Tablon;
                }
                else
                {
                    formaMadera = EForma.Tubo;
                }
                bufferInsumo = new Madera((ETipoMadera)cmbTipoMadera.SelectedItem, formaMadera, (int)nudCantidad.Value, dtpIngreso.Value.Date);
            }
            else if(rbTela.Checked)
            {
                bufferInsumo = new Tela((EColor)cmbColorTela.SelectedItem, (ETipoTela)cmbTipoTela.SelectedItem,(int)nudCantidad.Value, dtpIngreso.Value.Date);
            }
            else if(rbInsumoAccesorio.Checked)
            {
                ETipoAccesorio tipoInsumoAccesorio;
                if(rbBarniz.Checked)
                {
                    tipoInsumoAccesorio = ETipoAccesorio.Barniz;
                }
                else if (rbPegamento.Checked)
                {
                    tipoInsumoAccesorio = ETipoAccesorio.Pegamento;
                }
                else
                {
                    tipoInsumoAccesorio = ETipoAccesorio.Tornillo;
                }
                bufferInsumo = new InsumoAccesorio(tipoInsumoAccesorio, (int)nudCantidad.Value, dtpIngreso.Value.Date);
            }
            else if(rbYute.Checked)
            {
                bufferInsumo = new Yute((int)nudCantidad.Value, dtpIngreso.Value.Date);
            }

            FormPrincipal.fabricaSingleton.AgregarInsumosAStock(bufferInsumo);
            ActualizarListaInsumos();
            MessageBox.Show("Insumo agregado con éxito");
        }

        private void nudCantidadEstantes_ValueChanged(object sender, EventArgs e)
        {

        }
        
        private void VerificarOptionButtons()
        {
            if (rbTela.Checked)
            {
                gbInsumosAccesorios.Enabled = false;
                gbMadera.Enabled = false;
                gbTela.Enabled = true;
            }
            else if (rbMadera.Checked)
            {
                gbInsumosAccesorios.Enabled = false;
                gbMadera.Enabled = true;
                gbTela.Enabled = false;
            }
            else if (rbInsumoAccesorio.Checked)
            {
                gbInsumosAccesorios.Enabled = true;
                gbMadera.Enabled = false;
                gbTela.Enabled = false;
            }
            else if(rbYute.Checked)
            {
                gbInsumosAccesorios.Enabled = false;
                gbMadera.Enabled = false;
                gbTela.Enabled = false;
            }
        }

        private void rbGeneric_CheckedChanged(object sender, EventArgs e)
        {
            VerificarOptionButtons();
        }

        private void ActualizarListaInsumos()
        {
            if(FormPrincipal.fabricaSingleton.StockInsumos.Count > 0)
            { 
                dgStockInsumos.Rows.Clear();
                dgStockInsumos.Columns.Clear();
                dgStockInsumos.Columns.Add("tipoInsumo", "Tipo de Insumo");
                dgStockInsumos.Columns.Add("caracteristicas", "Características");

                foreach (Insumo i in FormPrincipal.fabricaSingleton.StockInsumos)
                {
                    string stringInsumo;
                    if (i is Madera)
                    {
                        stringInsumo = "Madera";
                    }
                    else if (i is Tela)
                    {
                        stringInsumo = "Tela";
                    }
                    else if (i is Yute)
                    {
                        stringInsumo = "Yute";
                    }
                    else
                    {
                        stringInsumo = "Insumo Accesorio";
                    }
                    dgStockInsumos.Rows.Add(stringInsumo, i.Mostrar());
                }
                dgStockInsumos.Visible = true;
                lblListaVacia.Visible = false;
            }
            else
            {
                dgStockInsumos.Visible = false;
                lblListaVacia.Visible = true;
            }
        }

    }

}
