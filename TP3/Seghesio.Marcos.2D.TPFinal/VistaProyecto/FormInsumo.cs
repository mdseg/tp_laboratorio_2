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
        }

        /// <summary>
        /// Inicia los controles del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFabrica_Load(object sender, EventArgs e)
        {
            rbMadera.Checked = true;
            rbTablon.Checked = true;
            rbBarniz.Checked = true;
            cmbColorTela.DataSource = Enum.GetValues(typeof(EColor));
            cmbTipoTela.DataSource = Enum.GetValues(typeof(ETipoTela));
            cmbTipoMadera.DataSource = Enum.GetValues(typeof(ETipoMadera));
            tabControlInsumos.SelectedTab = tabPageListadoInsumos;
            ActualizarListaInsumos();
        }     
        /// <summary>
        /// Para cambiar la pestaña al listado de insumos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBInsumos_Click(object sender, EventArgs e)
        {
            ActualizarListaInsumos();
            tabControlInsumos.SelectedTab = tabPageListadoInsumos;
        }
        /// <summary>
        /// Para cambiar la pestaña al formulario de ingreso de nuevo insumo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBAgregarInsumo_Click(object sender, EventArgs e)
        {
            tabControlInsumos.SelectedTab = tabPageAgregarInsumo;
        }
        /// <summary>
        /// Verifica los datos ingresados en el formulario y agrega un nuevo Insumo al stock de Insumos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarInsumo_Click(object sender, EventArgs e)
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
                else if (rbYute.Checked)
                {
                    tipoInsumoAccesorio = ETipoAccesorio.Yute;
                }
                else
                {
                    tipoInsumoAccesorio = ETipoAccesorio.Tornillo;
                }
                bufferInsumo = new InsumoAccesorio(tipoInsumoAccesorio, (int)nudCantidad.Value, dtpIngreso.Value.Date);
            }


            FormPrincipal.fabricaSingleton.AgregarInsumosAStock(bufferInsumo);
            ActualizarListaInsumos();
            MessageBox.Show("Insumo agregado con éxito", "Agregar insumo", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        /// <summary>
        /// Activa o desactiva controles vinculados al ingreso de insumos
        /// </summary>
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
        /// <summary>
        /// Metodo genérico para habilitar o deshabilitar controles vinculados al ingreso de insumos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbGeneric_CheckedChanged(object sender, EventArgs e)
        {
            VerificarOptionButtons();
        }
        /// <summary>
        /// Método encargado actualizar todos los controles que muestran los insumos cargados.
        /// </summary>
        private void ActualizarListaInsumos()
        {
            int cantidadPegamento = Insumo.CountInsumoType(FormPrincipal.fabricaSingleton.StockInsumos, ETipoInsumo.Pegamento);
            int cantidadBarniz = Insumo.CountInsumoType(FormPrincipal.fabricaSingleton.StockInsumos, ETipoInsumo.Barniz);
            int cantidadTornillos = Insumo.CountInsumoType(FormPrincipal.fabricaSingleton.StockInsumos, ETipoInsumo.Tornillo);
            int cantidadYute = Insumo.CountInsumoType(FormPrincipal.fabricaSingleton.StockInsumos, ETipoInsumo.Yute);

            lblPegamento.Text = $"Stock Pegamento: {cantidadPegamento}";
            lblBarniz.Text = $"Stock Barniz: {cantidadBarniz}";
            lblTornillos.Text = $"Stock Tornillos: {cantidadTornillos}";
            lblYute.Text = $"Stock Yute: {cantidadYute}";

            if (Insumo.CountInsumoType(FormPrincipal.fabricaSingleton.StockInsumos,ETipoInsumo.Madera) > 0)
            { 
                dgStockMaderas.Rows.Clear();
                dgStockMaderas.Columns.Clear();
                dgStockMaderas.Columns.Add("tipoMadera", "Material");
                dgStockMaderas.Columns.Add("formaMadera", "Forma");
                dgStockMaderas.Columns.Add("cantidad", "Cantidad");
                dgStockMaderas.Columns.Add("fechaIngreso", "Fecha");

                foreach (Insumo i in FormPrincipal.fabricaSingleton.StockInsumos)
                {
                    if (i is Madera)
                    {
                        dgStockMaderas.Rows.Add(((Madera)i).TipoMadera, ((Madera)i).Forma, i.Cantidad, i.FechaIngreso.Date.ToString("MM/dd/yyyy"));
                    }

                }
                dgStockMaderas.Visible = true;
                lblListaVaciaMadera.Visible = false;
            }
            else
            {
                dgStockMaderas.Visible = false;
                lblListaVaciaMadera.Visible = true;
            }

            if (Insumo.CountInsumoType(FormPrincipal.fabricaSingleton.StockInsumos, ETipoInsumo.Tela) > 0)
            {
                dgStockTelas.Rows.Clear();
                dgStockTelas.Columns.Clear();
                dgStockTelas.Columns.Add("tipoTela", "Material");
                dgStockTelas.Columns.Add("colorTela", "Color");
                dgStockTelas.Columns.Add("cantidad", "Cantidad");
                dgStockTelas.Columns.Add("fechaIngreso", "Fecha");

                foreach (Insumo i in FormPrincipal.fabricaSingleton.StockInsumos)
                {
                    if (i is Tela)
                    {
                        dgStockTelas.Rows.Add(((Tela)i).TipoTela, ((Tela)i).Color, i.Cantidad, i.FechaIngreso.Date.ToString("MM/dd/yyyy"));
                    }                    
                }
                dgStockTelas.Visible = true;
                lblListaVaciaTela.Visible = false;
            }
            else
            {
                dgStockTelas.Visible = false;
                lblListaVaciaTela.Visible = true;
            }
        }

    }

}
