﻿using Entidades;
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

                foreach (Insumo i in FormPrincipal.fabricaSingleton.StockInsumos)
                {
                    if (i is Madera)
                    {
                        dgStockMaderas.Rows.Add(((Madera)i).TipoMadera, ((Madera)i).Forma, i.Cantidad);
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

                foreach (Insumo i in FormPrincipal.fabricaSingleton.StockInsumos)
                {
                    if (i is Tela)
                    {
                        dgStockTelas.Rows.Add(((Tela)i).TipoTela, ((Tela)i).Color, i.Cantidad);
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
