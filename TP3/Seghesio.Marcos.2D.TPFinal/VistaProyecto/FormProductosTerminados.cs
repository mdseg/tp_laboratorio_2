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

namespace VistaProyecto
{
    public partial class FormProductosTerminados : Form
    {
        public FormProductosTerminados()
        {
            InitializeComponent();
            dgProductosTerminados.Columns.Clear();
            dgProductosTerminados.Columns.Add("tipoProducto", "Tipo de Producto");
            dgProductosTerminados.Columns.Add("modelo", "Modelo");
            dgProductosTerminados.Columns.Add("maderaPrincipal", "Madera Principal");
            dgProductosTerminados.Columns.Add("maderaSecundaria", "Madera Secundaria");
            dgProductosTerminados.Columns.Add("tipoTela", "Material Tela");
            dgProductosTerminados.Columns.Add("colorTela", "Color Tela");
            dgProductosTerminados.Columns.Add("detalles", "Detalles");
            ActualizarVistaLineaProduccion();
         }

        private void ActualizarVistaLineaProduccion()
        {
            if (FormPrincipal.fabricaSingleton.StockProductosTerminados.Count > 0)
            {
                dgProductosTerminados.Rows.Clear();

                foreach (Producto p in FormPrincipal.fabricaSingleton.StockProductosTerminados)
                {
                    string tipoProducto;
                    string maderaPrincipal;
                    string maderaSecundaria;
                    string modelo;
                    string tipoTelaProducto;
                    string colorTelaProducto;
                    string adicional;

                    maderaPrincipal = p.MaderaPrincipal.TipoMadera.ToString();
                    tipoTelaProducto = p.TelaProducto.TipoTela.ToString();
                    colorTelaProducto = p.TelaProducto.Color.ToString();

                    if (p is Torre)
                    {
                        maderaSecundaria = ((Torre)p).MaderaPrincipal.TipoMadera.ToString();
                        modelo = ((Torre)p).Modelo.ToString();
                        tipoProducto = "Torre";
                        if (((Torre)p).MetrosYute > 0)
                        {
                            adicional = $"Agregado de Yute: {((Torre)p).MetrosYute} metros";
                        }
                        else
                        {
                            adicional = "Sin adicionales";
                        }
                    }
                    else
                    {
                        modelo = "Unico";
                        tipoProducto = "Estante";
                        maderaSecundaria = "No aplica";
                        adicional = $"Cantidad: {((Estante)p).CantidadEstantes}";
                    }
                    dgProductosTerminados.Rows.Add(tipoProducto, modelo, maderaPrincipal, maderaSecundaria, tipoTelaProducto, colorTelaProducto, adicional);
                }
                CambiarVisibilidadControles(true);

            }
            else
            {
                CambiarVisibilidadControles(false);

            }
        }

        private void CambiarVisibilidadControles(bool visibilidad)
        {
            dgProductosTerminados.Visible = visibilidad;
            lblProductosTerminadosVacio.Visible = !visibilidad;
        }
    }
}