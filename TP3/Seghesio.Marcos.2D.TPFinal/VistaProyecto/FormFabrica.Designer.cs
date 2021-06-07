
namespace VistaProyecto
{
    partial class FormFabrica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlFabrica = new System.Windows.Forms.TabControl();
            this.tabPageLineaProduccion = new System.Windows.Forms.TabPage();
            this.dgLineaProduccionTodos = new System.Windows.Forms.DataGridView();
            this.lblListaVacia = new System.Windows.Forms.Label();
            this.lblLineaProduccion = new System.Windows.Forms.Label();
            this.tabPageAgregarProducto = new System.Windows.Forms.TabPage();
            this.nudCantidadInsumos = new System.Windows.Forms.NumericUpDown();
            this.lblPedido = new System.Windows.Forms.Label();
            this.btnSolicitarFaltantes = new System.Windows.Forms.Button();
            this.lblFaltantes = new System.Windows.Forms.Label();
            this.dgFaltantes = new System.Windows.Forms.DataGridView();
            this.gbProducto = new System.Windows.Forms.GroupBox();
            this.cmbColorTela = new System.Windows.Forms.ComboBox();
            this.lblColorTela = new System.Windows.Forms.Label();
            this.cmbTipoTela = new System.Windows.Forms.ComboBox();
            this.lblTela = new System.Windows.Forms.Label();
            this.cmbMaderaPrincipal = new System.Windows.Forms.ComboBox();
            this.lblMaderaPrincipal = new System.Windows.Forms.Label();
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.rbEstante = new System.Windows.Forms.RadioButton();
            this.rbTorre = new System.Windows.Forms.RadioButton();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.gbTorre = new System.Windows.Forms.GroupBox();
            this.lblCantidadYute = new System.Windows.Forms.Label();
            this.nudCantidadYute = new System.Windows.Forms.NumericUpDown();
            this.chkYute = new System.Windows.Forms.CheckBox();
            this.cmbMaderaColumna = new System.Windows.Forms.ComboBox();
            this.lblMaderaColumna = new System.Windows.Forms.Label();
            this.cmbModeloTorre = new System.Windows.Forms.ComboBox();
            this.lblModeloTorre = new System.Windows.Forms.Label();
            this.gbEstante = new System.Windows.Forms.GroupBox();
            this.nudCantidadEstantes = new System.Windows.Forms.NumericUpDown();
            this.lblCantidadEstantes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iBAgregarProducto = new FontAwesome.Sharp.IconButton();
            this.iBLineaProduccion = new FontAwesome.Sharp.IconButton();
            this.btnEjecutarProceso = new System.Windows.Forms.Button();
            this.lblProesoFabrica = new System.Windows.Forms.Label();
            this.cmbProcesoFabrica = new System.Windows.Forms.ComboBox();
            this.btnDespacharProductos = new System.Windows.Forms.Button();
            this.tabControlFabrica.SuspendLayout();
            this.tabPageLineaProduccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLineaProduccionTodos)).BeginInit();
            this.tabPageAgregarProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadInsumos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFaltantes)).BeginInit();
            this.gbProducto.SuspendLayout();
            this.gbTorre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadYute)).BeginInit();
            this.gbEstante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadEstantes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlFabrica
            // 
            this.tabControlFabrica.Controls.Add(this.tabPageLineaProduccion);
            this.tabControlFabrica.Controls.Add(this.tabPageAgregarProducto);
            this.tabControlFabrica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlFabrica.Location = new System.Drawing.Point(0, 0);
            this.tabControlFabrica.Name = "tabControlFabrica";
            this.tabControlFabrica.SelectedIndex = 0;
            this.tabControlFabrica.Size = new System.Drawing.Size(1161, 740);
            this.tabControlFabrica.TabIndex = 14;
            // 
            // tabPageLineaProduccion
            // 
            this.tabPageLineaProduccion.Controls.Add(this.btnDespacharProductos);
            this.tabPageLineaProduccion.Controls.Add(this.cmbProcesoFabrica);
            this.tabPageLineaProduccion.Controls.Add(this.lblProesoFabrica);
            this.tabPageLineaProduccion.Controls.Add(this.btnEjecutarProceso);
            this.tabPageLineaProduccion.Controls.Add(this.dgLineaProduccionTodos);
            this.tabPageLineaProduccion.Controls.Add(this.lblListaVacia);
            this.tabPageLineaProduccion.Controls.Add(this.lblLineaProduccion);
            this.tabPageLineaProduccion.Location = new System.Drawing.Point(4, 22);
            this.tabPageLineaProduccion.Name = "tabPageLineaProduccion";
            this.tabPageLineaProduccion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLineaProduccion.Size = new System.Drawing.Size(1153, 714);
            this.tabPageLineaProduccion.TabIndex = 0;
            this.tabPageLineaProduccion.Text = "Linea de Produccion";
            this.tabPageLineaProduccion.UseVisualStyleBackColor = true;
            // 
            // dgLineaProduccionTodos
            // 
            this.dgLineaProduccionTodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgLineaProduccionTodos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgLineaProduccionTodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLineaProduccionTodos.Location = new System.Drawing.Point(39, 153);
            this.dgLineaProduccionTodos.Name = "dgLineaProduccionTodos";
            this.dgLineaProduccionTodos.ReadOnly = true;
            this.dgLineaProduccionTodos.Size = new System.Drawing.Size(993, 224);
            this.dgLineaProduccionTodos.TabIndex = 6;
            this.dgLineaProduccionTodos.Visible = false;
            // 
            // lblListaVacia
            // 
            this.lblListaVacia.AutoSize = true;
            this.lblListaVacia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaVacia.Location = new System.Drawing.Point(54, 208);
            this.lblListaVacia.Name = "lblListaVacia";
            this.lblListaVacia.Size = new System.Drawing.Size(351, 25);
            this.lblListaVacia.TabIndex = 5;
            this.lblListaVacia.Text = "Aun no se han agregado Productos";
            this.lblListaVacia.Visible = false;
            // 
            // lblLineaProduccion
            // 
            this.lblLineaProduccion.AutoSize = true;
            this.lblLineaProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineaProduccion.Location = new System.Drawing.Point(34, 108);
            this.lblLineaProduccion.Name = "lblLineaProduccion";
            this.lblLineaProduccion.Size = new System.Drawing.Size(234, 29);
            this.lblLineaProduccion.TabIndex = 4;
            this.lblLineaProduccion.Text = "Linea de Producción";
            // 
            // tabPageAgregarProducto
            // 
            this.tabPageAgregarProducto.Controls.Add(this.nudCantidadInsumos);
            this.tabPageAgregarProducto.Controls.Add(this.lblPedido);
            this.tabPageAgregarProducto.Controls.Add(this.btnSolicitarFaltantes);
            this.tabPageAgregarProducto.Controls.Add(this.lblFaltantes);
            this.tabPageAgregarProducto.Controls.Add(this.dgFaltantes);
            this.tabPageAgregarProducto.Controls.Add(this.gbProducto);
            this.tabPageAgregarProducto.Controls.Add(this.btnAgregarProducto);
            this.tabPageAgregarProducto.Controls.Add(this.gbTorre);
            this.tabPageAgregarProducto.Controls.Add(this.gbEstante);
            this.tabPageAgregarProducto.Location = new System.Drawing.Point(4, 22);
            this.tabPageAgregarProducto.Name = "tabPageAgregarProducto";
            this.tabPageAgregarProducto.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAgregarProducto.Size = new System.Drawing.Size(1149, 641);
            this.tabPageAgregarProducto.TabIndex = 1;
            this.tabPageAgregarProducto.Text = "tabPage2";
            this.tabPageAgregarProducto.UseVisualStyleBackColor = true;
            // 
            // nudCantidadInsumos
            // 
            this.nudCantidadInsumos.Location = new System.Drawing.Point(370, 551);
            this.nudCantidadInsumos.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCantidadInsumos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidadInsumos.Name = "nudCantidadInsumos";
            this.nudCantidadInsumos.Size = new System.Drawing.Size(49, 20);
            this.nudCantidadInsumos.TabIndex = 19;
            this.nudCantidadInsumos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidadInsumos.Visible = false;
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Location = new System.Drawing.Point(326, 553);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(236, 13);
            this.lblPedido.TabIndex = 16;
            this.lblPedido.Text = "Solicitar                    veces los insumos faltantes.";
            this.lblPedido.Visible = false;
            this.lblPedido.Click += new System.EventHandler(this.lblPedido_Click);
            // 
            // btnSolicitarFaltantes
            // 
            this.btnSolicitarFaltantes.Location = new System.Drawing.Point(646, 543);
            this.btnSolicitarFaltantes.Name = "btnSolicitarFaltantes";
            this.btnSolicitarFaltantes.Size = new System.Drawing.Size(240, 33);
            this.btnSolicitarFaltantes.TabIndex = 15;
            this.btnSolicitarFaltantes.Text = "Realizar pedido de Insumos";
            this.btnSolicitarFaltantes.UseVisualStyleBackColor = true;
            this.btnSolicitarFaltantes.Visible = false;
            this.btnSolicitarFaltantes.Click += new System.EventHandler(this.btnSolicitarFaltantes_Click);
            // 
            // lblFaltantes
            // 
            this.lblFaltantes.AutoSize = true;
            this.lblFaltantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaltantes.Location = new System.Drawing.Point(45, 317);
            this.lblFaltantes.Name = "lblFaltantes";
            this.lblFaltantes.Size = new System.Drawing.Size(244, 24);
            this.lblFaltantes.TabIndex = 14;
            this.lblFaltantes.Text = "Listado de Insumos faltantes";
            this.lblFaltantes.Visible = false;
            // 
            // dgFaltantes
            // 
            this.dgFaltantes.AllowUserToAddRows = false;
            this.dgFaltantes.AllowUserToDeleteRows = false;
            this.dgFaltantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFaltantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgFaltantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFaltantes.Location = new System.Drawing.Point(49, 354);
            this.dgFaltantes.Name = "dgFaltantes";
            this.dgFaltantes.ReadOnly = true;
            this.dgFaltantes.Size = new System.Drawing.Size(837, 185);
            this.dgFaltantes.TabIndex = 13;
            this.dgFaltantes.Visible = false;
            // 
            // gbProducto
            // 
            this.gbProducto.Controls.Add(this.cmbColorTela);
            this.gbProducto.Controls.Add(this.lblColorTela);
            this.gbProducto.Controls.Add(this.cmbTipoTela);
            this.gbProducto.Controls.Add(this.lblTela);
            this.gbProducto.Controls.Add(this.cmbMaderaPrincipal);
            this.gbProducto.Controls.Add(this.lblMaderaPrincipal);
            this.gbProducto.Controls.Add(this.lblTipoProducto);
            this.gbProducto.Controls.Add(this.rbEstante);
            this.gbProducto.Controls.Add(this.rbTorre);
            this.gbProducto.Location = new System.Drawing.Point(49, 126);
            this.gbProducto.Name = "gbProducto";
            this.gbProducto.Size = new System.Drawing.Size(233, 170);
            this.gbProducto.TabIndex = 11;
            this.gbProducto.TabStop = false;
            this.gbProducto.Text = "Producto";
            // 
            // cmbColorTela
            // 
            this.cmbColorTela.FormattingEnabled = true;
            this.cmbColorTela.Location = new System.Drawing.Point(101, 133);
            this.cmbColorTela.Name = "cmbColorTela";
            this.cmbColorTela.Size = new System.Drawing.Size(93, 21);
            this.cmbColorTela.TabIndex = 10;
            // 
            // lblColorTela
            // 
            this.lblColorTela.AutoSize = true;
            this.lblColorTela.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblColorTela.Location = new System.Drawing.Point(6, 133);
            this.lblColorTela.Name = "lblColorTela";
            this.lblColorTela.Size = new System.Drawing.Size(58, 13);
            this.lblColorTela.TabIndex = 12;
            this.lblColorTela.Text = "Color Tela:";
            // 
            // cmbTipoTela
            // 
            this.cmbTipoTela.FormattingEnabled = true;
            this.cmbTipoTela.Location = new System.Drawing.Point(101, 92);
            this.cmbTipoTela.Name = "cmbTipoTela";
            this.cmbTipoTela.Size = new System.Drawing.Size(93, 21);
            this.cmbTipoTela.TabIndex = 9;
            // 
            // lblTela
            // 
            this.lblTela.AutoSize = true;
            this.lblTela.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblTela.Location = new System.Drawing.Point(7, 99);
            this.lblTela.Name = "lblTela";
            this.lblTela.Size = new System.Drawing.Size(31, 13);
            this.lblTela.TabIndex = 11;
            this.lblTela.Text = "Tela:";
            // 
            // cmbMaderaPrincipal
            // 
            this.cmbMaderaPrincipal.FormattingEnabled = true;
            this.cmbMaderaPrincipal.Location = new System.Drawing.Point(102, 51);
            this.cmbMaderaPrincipal.Name = "cmbMaderaPrincipal";
            this.cmbMaderaPrincipal.Size = new System.Drawing.Size(93, 21);
            this.cmbMaderaPrincipal.TabIndex = 8;
            // 
            // lblMaderaPrincipal
            // 
            this.lblMaderaPrincipal.AutoSize = true;
            this.lblMaderaPrincipal.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblMaderaPrincipal.Location = new System.Drawing.Point(7, 56);
            this.lblMaderaPrincipal.Name = "lblMaderaPrincipal";
            this.lblMaderaPrincipal.Size = new System.Drawing.Size(89, 13);
            this.lblMaderaPrincipal.TabIndex = 10;
            this.lblMaderaPrincipal.Text = "Madera Principal:";
            // 
            // lblTipoProducto
            // 
            this.lblTipoProducto.AutoSize = true;
            this.lblTipoProducto.Location = new System.Drawing.Point(7, 23);
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Size = new System.Drawing.Size(31, 13);
            this.lblTipoProducto.TabIndex = 9;
            this.lblTipoProducto.Text = "Tipo:";
            // 
            // rbEstante
            // 
            this.rbEstante.AutoSize = true;
            this.rbEstante.Location = new System.Drawing.Point(120, 22);
            this.rbEstante.Name = "rbEstante";
            this.rbEstante.Size = new System.Drawing.Size(66, 17);
            this.rbEstante.TabIndex = 8;
            this.rbEstante.TabStop = true;
            this.rbEstante.Text = "Estantes";
            this.rbEstante.UseVisualStyleBackColor = true;
            this.rbEstante.CheckedChanged += new System.EventHandler(this.rbEstante_CheckedChanged);
            // 
            // rbTorre
            // 
            this.rbTorre.AutoSize = true;
            this.rbTorre.Location = new System.Drawing.Point(64, 22);
            this.rbTorre.Name = "rbTorre";
            this.rbTorre.Size = new System.Drawing.Size(50, 17);
            this.rbTorre.TabIndex = 0;
            this.rbTorre.TabStop = true;
            this.rbTorre.Text = "Torre";
            this.rbTorre.UseVisualStyleBackColor = true;
            this.rbTorre.CheckedChanged += new System.EventHandler(this.rbTorre_CheckedChanged);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(639, 201);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(247, 37);
            this.btnAgregarProducto.TabIndex = 12;
            this.btnAgregarProducto.Text = "Agregar Producto a Linea de Produccion";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // gbTorre
            // 
            this.gbTorre.Controls.Add(this.lblCantidadYute);
            this.gbTorre.Controls.Add(this.nudCantidadYute);
            this.gbTorre.Controls.Add(this.chkYute);
            this.gbTorre.Controls.Add(this.cmbMaderaColumna);
            this.gbTorre.Controls.Add(this.lblMaderaColumna);
            this.gbTorre.Controls.Add(this.cmbModeloTorre);
            this.gbTorre.Controls.Add(this.lblModeloTorre);
            this.gbTorre.Enabled = false;
            this.gbTorre.Location = new System.Drawing.Point(288, 126);
            this.gbTorre.Name = "gbTorre";
            this.gbTorre.Size = new System.Drawing.Size(336, 170);
            this.gbTorre.TabIndex = 9;
            this.gbTorre.TabStop = false;
            this.gbTorre.Text = "Torre";
            // 
            // lblCantidadYute
            // 
            this.lblCantidadYute.AutoSize = true;
            this.lblCantidadYute.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblCantidadYute.Location = new System.Drawing.Point(112, 99);
            this.lblCantidadYute.Name = "lblCantidadYute";
            this.lblCantidadYute.Size = new System.Drawing.Size(52, 13);
            this.lblCantidadYute.TabIndex = 8;
            this.lblCantidadYute.Text = "Cantidad:";
            // 
            // nudCantidadYute
            // 
            this.nudCantidadYute.Location = new System.Drawing.Point(179, 92);
            this.nudCantidadYute.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidadYute.Name = "nudCantidadYute";
            this.nudCantidadYute.Size = new System.Drawing.Size(120, 20);
            this.nudCantidadYute.TabIndex = 6;
            this.nudCantidadYute.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkYute
            // 
            this.chkYute.AutoSize = true;
            this.chkYute.Location = new System.Drawing.Point(6, 99);
            this.chkYute.Name = "chkYute";
            this.chkYute.Size = new System.Drawing.Size(88, 17);
            this.chkYute.TabIndex = 9;
            this.chkYute.Text = "Agregar Yute";
            this.chkYute.UseVisualStyleBackColor = true;
            // 
            // cmbMaderaColumna
            // 
            this.cmbMaderaColumna.FormattingEnabled = true;
            this.cmbMaderaColumna.Location = new System.Drawing.Point(102, 53);
            this.cmbMaderaColumna.Name = "cmbMaderaColumna";
            this.cmbMaderaColumna.Size = new System.Drawing.Size(197, 21);
            this.cmbMaderaColumna.TabIndex = 7;
            // 
            // lblMaderaColumna
            // 
            this.lblMaderaColumna.AutoSize = true;
            this.lblMaderaColumna.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblMaderaColumna.Location = new System.Drawing.Point(3, 56);
            this.lblMaderaColumna.Name = "lblMaderaColumna";
            this.lblMaderaColumna.Size = new System.Drawing.Size(90, 13);
            this.lblMaderaColumna.TabIndex = 7;
            this.lblMaderaColumna.Text = "Madera Columna:";
            // 
            // cmbModeloTorre
            // 
            this.cmbModeloTorre.FormattingEnabled = true;
            this.cmbModeloTorre.Location = new System.Drawing.Point(101, 16);
            this.cmbModeloTorre.Name = "cmbModeloTorre";
            this.cmbModeloTorre.Size = new System.Drawing.Size(198, 21);
            this.cmbModeloTorre.TabIndex = 7;
            // 
            // lblModeloTorre
            // 
            this.lblModeloTorre.AutoSize = true;
            this.lblModeloTorre.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblModeloTorre.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblModeloTorre.Location = new System.Drawing.Point(3, 16);
            this.lblModeloTorre.Name = "lblModeloTorre";
            this.lblModeloTorre.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.lblModeloTorre.Size = new System.Drawing.Size(50, 23);
            this.lblModeloTorre.TabIndex = 7;
            this.lblModeloTorre.Text = "Modelo:";
            // 
            // gbEstante
            // 
            this.gbEstante.Controls.Add(this.nudCantidadEstantes);
            this.gbEstante.Controls.Add(this.lblCantidadEstantes);
            this.gbEstante.Location = new System.Drawing.Point(639, 126);
            this.gbEstante.Name = "gbEstante";
            this.gbEstante.Size = new System.Drawing.Size(247, 55);
            this.gbEstante.TabIndex = 10;
            this.gbEstante.TabStop = false;
            this.gbEstante.Text = "Estante";
            // 
            // nudCantidadEstantes
            // 
            this.nudCantidadEstantes.Location = new System.Drawing.Point(110, 19);
            this.nudCantidadEstantes.Name = "nudCantidadEstantes";
            this.nudCantidadEstantes.Size = new System.Drawing.Size(120, 20);
            this.nudCantidadEstantes.TabIndex = 6;
            // 
            // lblCantidadEstantes
            // 
            this.lblCantidadEstantes.AutoSize = true;
            this.lblCantidadEstantes.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCantidadEstantes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblCantidadEstantes.Location = new System.Drawing.Point(3, 16);
            this.lblCantidadEstantes.Name = "lblCantidadEstantes";
            this.lblCantidadEstantes.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.lblCantidadEstantes.Size = new System.Drawing.Size(101, 23);
            this.lblCantidadEstantes.TabIndex = 7;
            this.lblCantidadEstantes.Text = "Cantidad Estantes:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.iBAgregarProducto);
            this.panel1.Controls.Add(this.iBLineaProduccion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 78);
            this.panel1.TabIndex = 15;
            // 
            // iBAgregarProducto
            // 
            this.iBAgregarProducto.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iBAgregarProducto.Dock = System.Windows.Forms.DockStyle.Left;
            this.iBAgregarProducto.FlatAppearance.BorderSize = 0;
            this.iBAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBAgregarProducto.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBAgregarProducto.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iBAgregarProducto.IconColor = System.Drawing.Color.Snow;
            this.iBAgregarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBAgregarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBAgregarProducto.Location = new System.Drawing.Point(180, 0);
            this.iBAgregarProducto.Name = "iBAgregarProducto";
            this.iBAgregarProducto.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBAgregarProducto.Size = new System.Drawing.Size(180, 78);
            this.iBAgregarProducto.TabIndex = 3;
            this.iBAgregarProducto.Text = "Agregar Producto";
            this.iBAgregarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBAgregarProducto.UseVisualStyleBackColor = false;
            this.iBAgregarProducto.Click += new System.EventHandler(this.iBAgregarProducto_Click);
            // 
            // iBLineaProduccion
            // 
            this.iBLineaProduccion.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iBLineaProduccion.Dock = System.Windows.Forms.DockStyle.Left;
            this.iBLineaProduccion.FlatAppearance.BorderSize = 0;
            this.iBLineaProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBLineaProduccion.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iBLineaProduccion.IconChar = FontAwesome.Sharp.IconChar.List;
            this.iBLineaProduccion.IconColor = System.Drawing.Color.Snow;
            this.iBLineaProduccion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iBLineaProduccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBLineaProduccion.Location = new System.Drawing.Point(0, 0);
            this.iBLineaProduccion.Name = "iBLineaProduccion";
            this.iBLineaProduccion.Padding = new System.Windows.Forms.Padding(10, 20, 20, 0);
            this.iBLineaProduccion.Size = new System.Drawing.Size(180, 78);
            this.iBLineaProduccion.TabIndex = 2;
            this.iBLineaProduccion.Text = "Linea de Produccion";
            this.iBLineaProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBLineaProduccion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iBLineaProduccion.UseVisualStyleBackColor = false;
            this.iBLineaProduccion.Click += new System.EventHandler(this.IBLineaProduccion_Click);
            // 
            // btnEjecutarProceso
            // 
            this.btnEjecutarProceso.Location = new System.Drawing.Point(424, 397);
            this.btnEjecutarProceso.Name = "btnEjecutarProceso";
            this.btnEjecutarProceso.Size = new System.Drawing.Size(162, 40);
            this.btnEjecutarProceso.TabIndex = 7;
            this.btnEjecutarProceso.Text = "Ejecutar Proceso";
            this.btnEjecutarProceso.UseVisualStyleBackColor = true;
            this.btnEjecutarProceso.Visible = false;
            this.btnEjecutarProceso.Click += new System.EventHandler(this.btnEjecutarProceso_Click);
            // 
            // lblProesoFabrica
            // 
            this.lblProesoFabrica.AutoSize = true;
            this.lblProesoFabrica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProesoFabrica.Location = new System.Drawing.Point(35, 397);
            this.lblProesoFabrica.Name = "lblProesoFabrica";
            this.lblProesoFabrica.Size = new System.Drawing.Size(236, 20);
            this.lblProesoFabrica.TabIndex = 8;
            this.lblProesoFabrica.Text = "Seleccione el proceso a realizar:";
            this.lblProesoFabrica.Visible = false;
            // 
            // cmbProcesoFabrica
            // 
            this.cmbProcesoFabrica.FormattingEnabled = true;
            this.cmbProcesoFabrica.Location = new System.Drawing.Point(284, 397);
            this.cmbProcesoFabrica.Name = "cmbProcesoFabrica";
            this.cmbProcesoFabrica.Size = new System.Drawing.Size(121, 21);
            this.cmbProcesoFabrica.TabIndex = 9;
            this.cmbProcesoFabrica.Visible = false;
            // 
            // btnDespacharProductos
            // 
            this.btnDespacharProductos.Location = new System.Drawing.Point(606, 397);
            this.btnDespacharProductos.Name = "btnDespacharProductos";
            this.btnDespacharProductos.Size = new System.Drawing.Size(246, 40);
            this.btnDespacharProductos.TabIndex = 10;
            this.btnDespacharProductos.Text = "Despachar Productos terminados";
            this.btnDespacharProductos.UseVisualStyleBackColor = true;
            this.btnDespacharProductos.Click += new System.EventHandler(this.btnDespacharProductos_Click);
            // 
            // FormFabrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1161, 740);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlFabrica);
            this.Name = "FormFabrica";
            this.Text = "Fabrica";
            this.Load += new System.EventHandler(this.FormFabrica_Load);
            this.tabControlFabrica.ResumeLayout(false);
            this.tabPageLineaProduccion.ResumeLayout(false);
            this.tabPageLineaProduccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLineaProduccionTodos)).EndInit();
            this.tabPageAgregarProducto.ResumeLayout(false);
            this.tabPageAgregarProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadInsumos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFaltantes)).EndInit();
            this.gbProducto.ResumeLayout(false);
            this.gbProducto.PerformLayout();
            this.gbTorre.ResumeLayout(false);
            this.gbTorre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadYute)).EndInit();
            this.gbEstante.ResumeLayout(false);
            this.gbEstante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadEstantes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlFabrica;
        private System.Windows.Forms.TabPage tabPageLineaProduccion;
        private System.Windows.Forms.TabPage tabPageAgregarProducto;
        private System.Windows.Forms.GroupBox gbProducto;
        private System.Windows.Forms.ComboBox cmbColorTela;
        private System.Windows.Forms.Label lblColorTela;
        private System.Windows.Forms.ComboBox cmbTipoTela;
        private System.Windows.Forms.Label lblTela;
        private System.Windows.Forms.ComboBox cmbMaderaPrincipal;
        private System.Windows.Forms.Label lblMaderaPrincipal;
        private System.Windows.Forms.Label lblTipoProducto;
        private System.Windows.Forms.RadioButton rbEstante;
        private System.Windows.Forms.RadioButton rbTorre;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.GroupBox gbTorre;
        private System.Windows.Forms.Label lblCantidadYute;
        private System.Windows.Forms.NumericUpDown nudCantidadYute;
        private System.Windows.Forms.CheckBox chkYute;
        private System.Windows.Forms.ComboBox cmbMaderaColumna;
        private System.Windows.Forms.Label lblMaderaColumna;
        private System.Windows.Forms.ComboBox cmbModeloTorre;
        private System.Windows.Forms.Label lblModeloTorre;
        private System.Windows.Forms.GroupBox gbEstante;
        private System.Windows.Forms.NumericUpDown nudCantidadEstantes;
        private System.Windows.Forms.Label lblCantidadEstantes;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iBAgregarProducto;
        private FontAwesome.Sharp.IconButton iBLineaProduccion;
        private System.Windows.Forms.DataGridView dgFaltantes;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Button btnSolicitarFaltantes;
        private System.Windows.Forms.Label lblFaltantes;
        private System.Windows.Forms.NumericUpDown nudCantidadInsumos;
        private System.Windows.Forms.Label lblListaVacia;
        private System.Windows.Forms.Label lblLineaProduccion;
        private System.Windows.Forms.DataGridView dgLineaProduccionTodos;
        private System.Windows.Forms.ComboBox cmbProcesoFabrica;
        private System.Windows.Forms.Label lblProesoFabrica;
        private System.Windows.Forms.Button btnEjecutarProceso;
        private System.Windows.Forms.Button btnDespacharProductos;
    }
}