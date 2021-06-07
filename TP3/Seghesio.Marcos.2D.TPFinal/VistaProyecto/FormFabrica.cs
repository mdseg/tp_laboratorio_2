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
    public partial class FormFabrica : Form
    {
        List<Insumo> insumosFaltantes;

        public FormFabrica()
        {
            InitializeComponent();
            rbTorre.Checked = true;
            cmbColorTela.DataSource = Enum.GetValues(typeof(EColor));
            cmbTipoTela.DataSource = Enum.GetValues(typeof(ETipoTela));
            cmbMaderaPrincipal.DataSource = Enum.GetValues(typeof(ETipoMadera));
            cmbMaderaColumna.DataSource = Enum.GetValues(typeof(ETipoMadera));
            cmbModeloTorre.DataSource = Enum.GetValues(typeof(EModeloTorre));
            tabControlFabrica.SelectedTab = tabPageLineaProduccion;
            cambiarVisibilidadControlesFaltantes(false);
            ActualizarVistaLineaProduccion();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormFabrica_Load(object sender, EventArgs e)
        {

        }



        private void rbTorre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTorre.Checked)
            {
                gbTorre.Enabled = true;
                gbEstante.Enabled = false;
            }
        }

        private void rbEstante_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEstante.Checked)
            {
                gbTorre.Enabled = false;
                gbEstante.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iBInsumos_Click(object sender, EventArgs e)
        {
            ActualizarVistaLineaProduccion();
            tabControlFabrica.SelectedTab = tabPageLineaProduccion;
        }

        private void iBAgregarProducto_Click(object sender, EventArgs e)
        {
            tabControlFabrica.SelectedTab = tabPageAgregarProducto;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            
            insumosFaltantes = new List<Insumo>();

            Producto bufferProducto = CargarCamposProducto();



            if (FormPrincipal.fabricaSingleton.AgregarProductoLineaProduccion(bufferProducto, out insumosFaltantes))
            {
                MessageBox.Show("Producto agregado a linea de Producción con éxito");
                cambiarVisibilidadControlesFaltantes(false);
                ActualizarVistaLineaProduccion();
            }
            else
            {

                MessageBox.Show("No se puede ingresar el producto, dado que hay faltantes");
                LimpiarDataGridFaltantes();
                dgFaltantes.Columns.Add("tipoInsumo", "Tipo de Insumo");
                dgFaltantes.Columns.Add("caracteristicas", "Características");
                foreach (Insumo i in insumosFaltantes)
                {
                    string stringInsumo;
                    if(i is Madera)
                    {
                        stringInsumo = "Madera";
                    }
                    else if(i is Tela)
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
                    dgFaltantes.Rows.Add(stringInsumo, i.Mostrar());
                }
                cambiarVisibilidadControlesFaltantes(true);


            }
        }

        private void SolicitarInsumosFaltantes(List<Insumo> insumosFaltantes)
        {
            FormPrincipal.fabricaSingleton.AgregarInsumosAStock(insumosFaltantes);
        }

        private Producto CargarCamposProducto()
        {

            Producto producto;

            ETipoMadera tipoMaderaPrincipal = (ETipoMadera)cmbMaderaPrincipal.SelectedItem;
            ETipoTela tipoTela = (ETipoTela)cmbTipoTela.SelectedItem;
            EColor colorTela = (EColor)cmbColorTela.SelectedItem;

            Madera maderaPrincipal = new Madera(tipoMaderaPrincipal, EForma.Tablon, 4);
            Tela telaProducto = new Tela(colorTela, tipoTela, 2);

            if (rbTorre.Checked)
            {
                EModeloTorre modeloTorre = (EModeloTorre)cmbModeloTorre.SelectedItem;
                ETipoMadera tipoMaderaColumna = (ETipoMadera)cmbMaderaColumna.SelectedItem;

                Madera maderaColumna = new Madera(tipoMaderaColumna, EForma.Tubo, 1);

                if (chkYute.Checked)
                {
                    int metrosYute = (int)nudCantidadYute.Value;
                    producto = new Torre(maderaPrincipal, telaProducto, modeloTorre, maderaColumna, metrosYute);
                }
                else
                {
                    producto = new Torre(maderaPrincipal, telaProducto, modeloTorre, maderaColumna);
                }
            }
            else
            {
                producto = new Estante(maderaPrincipal, telaProducto, (int)nudCantidadEstantes.Value);
            }
            return producto;
        }

        private void lblPedido_Click(object sender, EventArgs e)
        {

        }

        private void cambiarVisibilidadControlesFaltantes(bool visibilidad)
        {
            lblFaltantes.Visible = visibilidad;
            dgFaltantes.Visible = visibilidad;
            nudCantidadInsumos.Visible = visibilidad;
            lblPedido.Visible = visibilidad;
            btnSolicitarFaltantes.Visible = visibilidad;
        }

        private void btnSolicitarFaltantes_Click(object sender, EventArgs e)
        {
            int multiplicadorInsumos = (int)nudCantidadInsumos.Value;
            

            foreach(Insumo insumo in insumosFaltantes)
            {
                insumo.Cantidad *= multiplicadorInsumos;
            }

            FormPrincipal.fabricaSingleton.AgregarInsumosAStock(insumosFaltantes);

            insumosFaltantes.Clear();
            cambiarVisibilidadControlesFaltantes(false);
            MessageBox.Show("Pedido de insumos faltantes realizado correctamente");
        }

        private void LimpiarDataGridFaltantes()
        {
                dgFaltantes.Rows.Clear();
            dgFaltantes.Columns.Clear();
        }

        private void ActualizarVistaLineaProduccion()
        {
            if (FormPrincipal.fabricaSingleton.LineaProduccion.Count > 0)
            {
                dgLineaProduccionTodos.Rows.Clear();
                dgLineaProduccionTodos.Columns.Clear();
                dgLineaProduccionTodos.Columns.Add("tipoProducto", "Tipo de Producto");
                dgLineaProduccionTodos.Columns.Add("modelo", "Modelo");
                dgLineaProduccionTodos.Columns.Add("maderaPrincipal", "Madera Principal");
                dgLineaProduccionTodos.Columns.Add("maderaSecundaria", "Madera Secundaria");
                dgLineaProduccionTodos.Columns.Add("tipoTela", "Material Tela");
                dgLineaProduccionTodos.Columns.Add("colorTela", "Color Tela");
                dgLineaProduccionTodos.Columns.Add("detalles", "Detalles");
                dgLineaProduccionTodos.Columns.Add("estado", "Estado");

                foreach (Producto p in FormPrincipal.fabricaSingleton.LineaProduccion)
                {
                    string tipoProducto;
                    string maderaPrincipal;
                    string maderaSecundaria;
                    string modelo;
                    string tipoTelaProducto;
                    string colorTelaProducto;
                    string estado;
                    string adicional;

                    maderaPrincipal = p.MaderaPrincipal.TipoMadera.ToString();
                    tipoTelaProducto = p.TelaProducto.TipoTela.ToString();
                    colorTelaProducto = p.TelaProducto.Color.ToString();
                    estado = p.EstadoProducto.ToString();

                    if (p is Torre)
                    {
                        maderaSecundaria = ((Torre)p).MaderaPrincipal.TipoMadera.ToString();
                        modelo = ((Torre)p).Modelo.ToString();
                        tipoProducto = "Torre";
                        if(((Torre)p).MetrosYute > 0)
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

                    dgLineaProduccionTodos.Rows.Add(tipoProducto, modelo, maderaPrincipal, maderaSecundaria, tipoTelaProducto,colorTelaProducto, adicional, estado);
                }
                dgLineaProduccionTodos.Visible = true;
                lblListaVacia.Visible = false;
            }
            else
            {
                dgLineaProduccionTodos.Visible = false;
                lblListaVacia.Visible = true;
            }
        }
    }

}
